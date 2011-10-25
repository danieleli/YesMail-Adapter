using System.Xml.Serialization;
using System.IO;
using System;

namespace SC.YesMailAdapter.Factory 
{
    public class YesMailSerializer
    {
        private  const string NAMESPACE_PREFIX = "yesws";
        private const string NAMESPACE = "https://services.yesmail.com";

        public static string CreateRequestBody(subscribeAndSend messageBody)
        {
            var requestBody = string.Empty;

            using (var stream = new MemoryStream())
            {
                requestBody = ReadStream(messageBody, stream);
            }
            return requestBody;
        }

        private static string ReadStream(subscribeAndSend messageBody, MemoryStream stream)
        {
            string requestBody;
            InitializeStream(messageBody, stream);

            
            using (var reader = new StreamReader(stream))
            {
                requestBody = reader.ReadToEnd();
            }
            return requestBody;
        }

        private static void InitializeStream(subscribeAndSend messageBody, MemoryStream stream)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(NAMESPACE_PREFIX, NAMESPACE);

            var serializer = new XmlSerializer(typeof(subscribeAndSend));
            serializer.Serialize(stream, messageBody, namespaces);
            //serializer.Serialize(stream, messageBody);
            stream.Seek(0, SeekOrigin.Begin);
        }

    }
}
