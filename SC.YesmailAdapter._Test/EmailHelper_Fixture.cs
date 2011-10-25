using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SC.YesMailAdapter;
using SC.YesMailAdapter.Factory;
using log4net;

namespace SC.YesmailAdapter._Test
{
    [TestFixture]
    public class EmailHelper_Fixture
    {
        public static ILog _logger = LogManager.GetLogger(typeof(Emailer));
        public EmailHelper_Fixture()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test]
        public void SendMail()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = GetTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var response = emailHelper.SendEmail(sendAndSubscribe);
            //var response = emailHelper.SendEmail(dto, messageId);
        }

        [Test]
        public void Serialization()
        {
            // Arrange
            var emailHelper = new Emailer();
            var messageId = 3332324;
            var dto = GetTestMessageDto("test1");

            // Act
            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);
            var serializedObject = YesMailSerializer.CreateRequestBody(sendAndSubscribe);
            _logger.Info(serializedObject);
        }

        public TestMessageDto GetTestMessageDto(string seed)
        {
            var dto = new TestMessageDto()
            {
                ExpirationDate = DateTime.Now.ToString("ddhhmmssff"),
                Generic1 = "www.generic1" + seed + ".com",
                Generic2 = "www.generic2" + seed + ".com",
                Name1 = "name1" + seed,
                Url1 = "www.url1" + seed + ".com",
                ConsumerId = "343223",
            };

            return dto;
        }
    }
}
