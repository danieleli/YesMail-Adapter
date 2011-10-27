using System.Xml.Serialization;
using System.IO;

namespace SC.YesMailAdapter.Mappers
{
    public class YesMailSerializer
    {
        private const string NAMESPACE_PREFIX = "yesws";
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

        public static statusType DeserializeStatus(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(statusType));
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            var bytes = encoding.GetBytes(xmlString);
            var stream = new MemoryStream(bytes);
            var statusType = (statusType)xmlSerializer.Deserialize(stream);
            return statusType;
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
