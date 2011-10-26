using System;
using NUnit.Framework;
using SC.YesMailAdapter;
using SC.YesMailAdapter.Factory;
using SC.YesmailAdapter._Test.Helpers;
using log4net;
using SC.YesMailAdapter.Configuration;
using System.Net;

namespace SC.YesmailAdapter._Test.Fixtures
{
    [TestFixture]
    public class Emailer_Fixture
    {
        public static ILog _logger = LogManager.GetLogger(typeof(Emailer));
        public Emailer_Fixture()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [Test]
        public void SendMail_Should_Return_StatusValidMessageStatusUrl()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var statusType = emailHelper.SendEmail(sendAndSubscribe);

            // Assert
            Assert.That(statusType.statusNoWaitURI, Contains.Substring(@"https://services.yesmail.com/enterprise/statusNoWait"));
        }

        [Test]
        public void InvalidCredentials_Should_Throw401Exception()
        {
            var settings = new ApiSettings();
            settings.Password = "badpassword";
            var emailHelper = new Emailer(settings);
            var messageId = 1256210;
            var dto = DtoFactory.CreateTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            try
            {
                var response = emailHelper.SendEmail(sendAndSubscribe);
            }
            catch (WebException we)
            {
                if (we.Message.Contains("401")) return;
                throw;
            }
            
            Assert.Fail("401 Not thrown.");
            //var response = emailHelper.SendEmail(dto, messageId);
        }


        [Test]
        public void SendMailWithInvalidPayload_Should_ReturnStatusWithError()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var response = emailHelper.SendEmail(sendAndSubscribe);
            //var response = emailHelper.SendEmail(dto, messageId);

            throw new NotImplementedException();
        }

    }
}
