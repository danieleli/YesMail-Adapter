using System.Xml.Serialization;
using System.IO;

namespace SC.YesMailAdapter.Mappers
{
    public class YesMailSerializer
    {
        public static string Serialize(subscribeAndSend snsMessage)
        {
            var requestBody = string.Empty;

            using (var stream = new MemoryStream())
            {
                StreamHelper.InitializeStream(snsMessage, stream);
                requestBody = StreamHelper.ReadStream(stream);
            }
            return requestBody;
        }

        public static statusType DeserializeStatus(string xmlString)
        {
            statusType rtnStatus = null;

            using (var stream = StreamHelper.GetStream(xmlString))
            {
                var xmlSerializer = new XmlSerializer(typeof(statusType));
                rtnStatus = (statusType)xmlSerializer.Deserialize(stream);    
            }

            return rtnStatus;
        }

        private static class StreamHelper
        {
            private const string NAMESPACE_PREFIX = "yesws";
            private const string NAMESPACE = "https://services.yesmail.com";

            internal static MemoryStream GetStream(string xmlString)
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                var bytes = encoding.GetBytes(xmlString);
                return new MemoryStream(bytes);
            }

            internal static string ReadStream(MemoryStream stream)
            {
                string requestBody;

                using (var reader = new StreamReader(stream))
                {
                    requestBody = reader.ReadToEnd();
                }

                return requestBody;
            }

            internal static void InitializeStream(subscribeAndSend messageBody, MemoryStream stream)
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(NAMESPACE_PREFIX, NAMESPACE);

                var serializer = new XmlSerializer(typeof (subscribeAndSend));
                serializer.Serialize(stream, messageBody, namespaces);

                stream.Seek(0, SeekOrigin.Begin);
            }
        }

    }
}
