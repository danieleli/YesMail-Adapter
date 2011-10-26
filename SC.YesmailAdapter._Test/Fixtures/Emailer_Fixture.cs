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
        public void SendMail_Should_Return_StatusSubmitted()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var statusType = emailHelper.SendEmail(sendAndSubscribe);

            // Assert
            _logger.Info("\nStatusNoWaitUrl\n-------------\n" + statusType.statusNoWaitURI);
            Assert.That(statusType.statusNoWaitURI, Contains.Substring(@"https://services.yesmail.com/enterprise/statusNoWait"));
            Assert.That(statusType.statusCode, Is.EqualTo(StatusCode.SUBMITTED), "StatusCode");
            
        }

        [Test]
        public void CheckStatusForEmailWithBadPayload_Should_Return_StatusCodeError()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateEr1Message("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var initialStatus = emailHelper.SendEmail(sendAndSubscribe);
            var checkedStatus = emailHelper.CheckStatus(initialStatus.statusNoWaitURI);
            
            
            // Assert
            _logger.Info("\nCheckStatus.Status\n-------------\n" + checkedStatus.statusMessage);
            Assert.That(checkedStatus.statusCode, Is.EqualTo(StatusCode.ERROR), "StatusCode");

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

    }
}
