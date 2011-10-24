#region Usings

using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using SC.YesMail;
using log4net;

#endregion

namespace SC.YesMail
{
    public class Object
    {
        internal static string email = string.Empty;
        internal static string proxyAddress = ConfigurationManager.AppSettings["proxyAddress"];
        internal static string proxyDomain = ConfigurationManager.AppSettings["proxyDomain"];
        internal static string proxyPassword = ConfigurationManager.AppSettings["proxyPassword"];
        internal static string proxyUsername = ConfigurationManager.AppSettings["proxyUsername"];
        internal static string statusURL = "";
        internal static string transactionID = string.Empty;
        internal static string transactionTable = "";
        internal static string ysApiDomain = ConfigurationManager.AppSettings["yesmailDomain"];
        internal static string ysApiPassword = ConfigurationManager.AppSettings["yesmailPassword"];
        internal static string ysApiURL = ConfigurationManager.AppSettings["yesmailApiURL"];
        internal static string ysApiUsername = ConfigurationManager.AppSettings["yesmailUsername"];
        private static readonly ILog _logger = LogManager.GetLogger("SC.YesMail.Object");

        internal static string CreateXMLData(USERS userDetails, API_TRANSACTIONS apiTransactions,
                                             API_CONFIRMATIONS apiConfirmations, API_PROMOS apiPromos)
        {
            string str2;
            try
            {
                email = userDetails.email;
                if (apiConfirmations != null)
                {
                    transactionTable = Constants.ApiConfirmationsTable;
                }
                else if (apiPromos != null)
                {
                    transactionTable = Constants.ApiPromosTable;
                }
                var sb = new StringBuilder();
                var w = new StringWriter(sb);
                var oXmlTextWriter = new XmlTextWriter(w);
                string str = null;
                oXmlTextWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                oXmlTextWriter.WriteStartElement("yesws:subscribeAndSend");
                oXmlTextWriter.WriteAttributeString("xmlns:yesws", "https://services.yesmail.com");
                oXmlTextWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                oXmlTextWriter.WriteAttributeString("xsi:schemaLocation",
                                                    "https://services.yesmail.com docs/xsd/subscribeandsend.xsd");
                oXmlTextWriter.WriteAttributeString("schemaVersion", "1.0");
                WriteSubscriberNode(oXmlTextWriter, userDetails);
                oXmlTextWriter.WriteStartElement("yesws:sideTable");
                WriteApiTransactionsNode(oXmlTextWriter, apiTransactions);
                if (transactionTable == Constants.ApiConfirmationsTable)
                {
                    WriteApiConfirmationsNode(oXmlTextWriter, apiConfirmations);
                }
                else if (transactionTable == Constants.ApiPromosTable)
                {
                    WriteApiPromosNode(oXmlTextWriter, apiPromos);
                }
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteStartElement("yesws:subscriberMessage");
                oXmlTextWriter.WriteElementString("yesws:masterId", Convert.ToString(apiTransactions.mmid));
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                str = w.ToString();
                oXmlTextWriter.Close();
                w.Flush();
                sb.Length = 0;
                str2 = str;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            _logger.Debug("CreateXML: " + str2);
            return str2;
        }

        public static int TriggerMail(USERS userDetails, API_TRANSACTIONS apiTransactions,
                                      API_CONFIRMATIONS apiConfirmations, API_PROMOS apiPromos)
        {
            transactionID = DateTime.Now.ToString("ddhhmmssff");
            HttpWebRequest request = null;
            HttpWebRequest request2 = null;
            var num = 0;
            var num2 = 0;
            try
            {
                var s = CreateXMLData(userDetails, apiTransactions, apiConfirmations, apiPromos);
                request = (HttpWebRequest) WebRequest.Create(ysApiURL);
                request.Method = "POST";
                request.ContentType = "application/xml; charset=UTF-8; type=entry";
                request.Timeout = 0x30d40;
                var cache = new CredentialCache();
                cache.Add(new Uri(ysApiURL), "Basic",
                          new NetworkCredential(ysApiDomain + "/" + ysApiUsername, ysApiPassword));
                request.Credentials = cache;
                var proxy = new WebProxy(proxyAddress)
                                {
                                    Credentials = new NetworkCredential(proxyUsername, proxyPassword, proxyDomain)
                                };
                request.Proxy = proxy;
                var requestStream = request.GetRequestStream();
                var bytes = new UTF8Encoding().GetBytes(s);
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Flush();
                requestStream.Close();
                var response = request.GetResponse();
                var response2 = (HttpWebResponse) response;
                var responseStream = response.GetResponseStream();
                var reader2 = new StreamReader(responseStream);
                var reader3 = XmlReader.Create(new StringReader(reader2.ReadToEnd()));
                while (reader3.Read())
                {
                    _logger.Debug("\nReader3 Value: " + reader3.Value + "\n");
                    if (reader3.IsStartElement() && ((reader3.Name == "yesws:statusCode") && reader3.Read()))
                    {
                        if (reader3.Value.ToLower().Trim() == Constants.submittedText)
                        {
                            num = 1;
                        }
                        else
                        {
                            num = 0;
                        }
                    }
                    if (((num == 1) && reader3.IsStartElement()) &&
                        ((reader3.Name == "yesws:statusURI") && reader3.Read()))
                    {
                        statusURL = reader3.Value.ToLower().Trim();
                        request2 = (HttpWebRequest) WebRequest.Create(statusURL);
                        request2.Method = "GET";
                        request2.Timeout = 0x30d40;
                        var cache2 = new CredentialCache();
                        cache2.Add(new Uri(statusURL), "Basic",
                                   new NetworkCredential(ysApiDomain + "/" + ysApiUsername, ysApiPassword));
                        request2.Credentials = cache2;
                        request2.Proxy = proxy;
                        var response3 = request2.GetResponse();
                        var response4 = (HttpWebResponse) response3;
                        var stream = response3.GetResponseStream();
                        var reader4 = new StreamReader(stream);
                        var reader = XmlReader.Create(new StringReader(reader4.ReadToEnd()));
                        while (reader.Read())
                        {
                            _logger.Debug("\n InnerReader Value: " + reader.Value + "\n");
                            
                            if (reader.IsStartElement() && ((reader.Name == "yesws:statusCode") && reader.Read()))
                            {
                                if (reader.Value.ToLower().Trim() == Constants.CompletedText)
                                {
                                    num2 = 1;
                                }
                                else
                                {
                                    num2 = 0;
                                }
                            }
                        }
                        reader.Close();
                        stream.Close();
                        response3.Close();
                    }
                }
                reader2.Close();
                responseStream.Close();
                response.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num2;
        }

        internal static void WriteApiConfirmationsNode(XmlWriter oXmlTextWriter, API_CONFIRMATIONS apiConfirmations)
        {
            try
            {
                oXmlTextWriter.WriteStartElement("yesws:table");
                oXmlTextWriter.WriteElementString("yesws:name", "API_CONFIRMATIONS");
                oXmlTextWriter.WriteStartElement("yesws:rows");
                oXmlTextWriter.WriteStartElement("yesws:row");
                oXmlTextWriter.WriteStartElement("yesws:columns");
                WriteColumnNode(oXmlTextWriter, "transactionid", transactionID);
                WriteColumnNode(oXmlTextWriter, "email", email);
                if (!string.IsNullOrEmpty(apiConfirmations.type))
                {
                    WriteColumnNode(oXmlTextWriter, "type", apiConfirmations.type);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.name))
                {
                    WriteColumnNode(oXmlTextWriter, "name", apiConfirmations.name);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.pointvalue))
                {
                    WriteColumnNode(oXmlTextWriter, "pointvalue", apiConfirmations.pointvalue);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.url1))
                {
                    WriteColumnNode(oXmlTextWriter, "url1", apiConfirmations.url1);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.url2))
                {
                    WriteColumnNode(oXmlTextWriter, "url2", apiConfirmations.url2);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.url3))
                {
                    WriteColumnNode(oXmlTextWriter, "url3", apiConfirmations.url3);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.childage))
                {
                    WriteColumnNode(oXmlTextWriter, "childage", apiConfirmations.childage);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.subscribedto))
                {
                    WriteColumnNode(oXmlTextWriter, "subscribedto", apiConfirmations.subscribedto);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.verificationcode))
                {
                    WriteColumnNode(oXmlTextWriter, "verificationcode", apiConfirmations.verificationcode);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.personalmessage))
                {
                    WriteColumnNode(oXmlTextWriter, "personalmessage", apiConfirmations.personalmessage);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.generic1))
                {
                    WriteColumnNode(oXmlTextWriter, "generic1", apiConfirmations.generic1);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.generic2))
                {
                    WriteColumnNode(oXmlTextWriter, "generic2", apiConfirmations.generic2);
                }
                if (!string.IsNullOrEmpty(apiConfirmations.generic3))
                {
                    WriteColumnNode(oXmlTextWriter, "generic3", apiConfirmations.generic3);
                }
                WriteColumnNode(oXmlTextWriter, "lastupdatedate", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.f"));
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal static void WriteApiPromosNode(XmlWriter oXmlTextWriter, API_PROMOS apiPromos)
        {
            try
            {
                oXmlTextWriter.WriteStartElement("yesws:table");
                oXmlTextWriter.WriteElementString("yesws:name", "API_PROMOS");
                oXmlTextWriter.WriteStartElement("yesws:rows");
                oXmlTextWriter.WriteStartElement("yesws:row");
                oXmlTextWriter.WriteStartElement("yesws:columns");
                WriteColumnNode(oXmlTextWriter, "transactionid", transactionID);
                WriteColumnNode(oXmlTextWriter, "email", email);
                if (!string.IsNullOrEmpty(apiPromos.type))
                {
                    WriteColumnNode(oXmlTextWriter, "type", apiPromos.type);
                }
                if (!string.IsNullOrEmpty(apiPromos.name1))
                {
                    WriteColumnNode(oXmlTextWriter, "name1", apiPromos.name1);
                }
                if (!string.IsNullOrEmpty(apiPromos.name2))
                {
                    WriteColumnNode(oXmlTextWriter, "name2", apiPromos.name2);
                }
                if (!string.IsNullOrEmpty(apiPromos.productdesc))
                {
                    WriteColumnNode(oXmlTextWriter, "productdesc", apiPromos.productdesc);
                }
                if (!string.IsNullOrEmpty(apiPromos.url1))
                {
                    WriteColumnNode(oXmlTextWriter, "url1", apiPromos.url1);
                }
                if (!string.IsNullOrEmpty(apiPromos.url2))
                {
                    WriteColumnNode(oXmlTextWriter, "url2", apiPromos.url2);
                }
                if (!string.IsNullOrEmpty(apiPromos.url3))
                {
                    WriteColumnNode(oXmlTextWriter, "url3", apiPromos.url3);
                }
                if (!string.IsNullOrEmpty(apiPromos.redemptioncode))
                {
                    WriteColumnNode(oXmlTextWriter, "redemptioncode", apiPromos.redemptioncode);
                }
                if (!string.IsNullOrEmpty(apiPromos.expirationdate))
                {
                    WriteColumnNode(oXmlTextWriter, "expirationdate", apiPromos.expirationdate);
                }
                if (!string.IsNullOrEmpty(apiPromos.securitycode))
                {
                    WriteColumnNode(oXmlTextWriter, "securitycode", apiPromos.securitycode);
                }
                if (!string.IsNullOrEmpty(apiPromos.generic1))
                {
                    WriteColumnNode(oXmlTextWriter, "generic1", apiPromos.generic1);
                }
                if (!string.IsNullOrEmpty(apiPromos.generic2))
                {
                    WriteColumnNode(oXmlTextWriter, "generic2", apiPromos.generic2);
                }
                if (!string.IsNullOrEmpty(apiPromos.generic3))
                {
                    WriteColumnNode(oXmlTextWriter, "generic3", apiPromos.generic3);
                }
                WriteColumnNode(oXmlTextWriter, "lastupdatedate", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.f"));
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal static void WriteApiTransactionsNode(XmlWriter oXmlTextWriter, API_TRANSACTIONS apiTransactions)
        {
            try
            {
                oXmlTextWriter.WriteStartElement("yesws:table");
                oXmlTextWriter.WriteElementString("yesws:name", "api_transactions");
                oXmlTextWriter.WriteStartElement("yesws:rows");
                oXmlTextWriter.WriteStartElement("yesws:row");
                oXmlTextWriter.WriteStartElement("yesws:columns");
                WriteColumnNode(oXmlTextWriter, "transactionid", transactionID);
                WriteColumnNode(oXmlTextWriter, "email", email);
                if (!string.IsNullOrEmpty(apiTransactions.type))
                {
                    WriteColumnNode(oXmlTextWriter, "type", apiTransactions.type);
                }
                if (!string.IsNullOrEmpty(apiTransactions.brand))
                {
                    WriteColumnNode(oXmlTextWriter, "brand", apiTransactions.brand);
                }
                WriteColumnNode(oXmlTextWriter, "mmid", Convert.ToString(apiTransactions.mmid));
                WriteColumnNode(oXmlTextWriter, "lastupdatedate", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.f"));
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
                oXmlTextWriter.WriteEndElement();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal static void WriteAttributeNode(XmlWriter oXmlTextWriter, string name, string value)
        {
            try
            {
                oXmlTextWriter.WriteStartElement("yesws:attribute");
                oXmlTextWriter.WriteElementString("yesws:name", name);
                oXmlTextWriter.WriteElementString("yesws:value", value);
                oXmlTextWriter.WriteEndElement();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal static void WriteColumnNode(XmlWriter oXmlTextWriter, string name, string value)
        {
            try
            {
                oXmlTextWriter.WriteStartElement("yesws:column");
                oXmlTextWriter.WriteElementString("yesws:name", name);
                oXmlTextWriter.WriteElementString("yesws:value", value);
                oXmlTextWriter.WriteEndElement();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        internal static void WriteSubscriberNode(XmlWriter oXmlTextWriter, USERS userDetails)
        {
            try
            {
                try
                {
                    oXmlTextWriter.WriteStartElement("yesws:subscriber");
                    oXmlTextWriter.WriteElementString("yesws:subscriptionState", "SUBSCRIBED");
                    oXmlTextWriter.WriteElementString("yesws:allowResubscribe", "true");
                    oXmlTextWriter.WriteElementString("yesws:division", "Transactional");
                    oXmlTextWriter.WriteStartElement("yesws:attributes");
                    WriteAttributeNode(oXmlTextWriter, "email", email);
                    WriteAttributeNode(oXmlTextWriter, "consumerid", Convert.ToString(userDetails.consumerid));
                    if (transactionTable == Constants.ApiConfirmationsTable)
                    {
                        WriteAttributeNode(oXmlTextWriter, "api_conf_transactionid", Convert.ToString(transactionID));
                    }
                    else if (transactionTable == Constants.ApiPromosTable)
                    {
                        WriteAttributeNode(oXmlTextWriter, "api_promo_transactionid", Convert.ToString(transactionID));
                    }
                    oXmlTextWriter.WriteEndElement();
                    oXmlTextWriter.WriteEndElement();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
            }
        }
    }
}