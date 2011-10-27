#region Usings

using System;
using System.Net;
using System.Threading;
using NUnit.Framework;
using SC.YesMailAdapter;
using SC.YesMailAdapter.Configuration;
using SC.YesMailAdapter.Mappers;
using SC.YesmailAdapter._Test.Helpers;
using log4net;
using log4net.Config;

#endregion

namespace SC.YesmailAdapter._Test.Fixtures
{
    [TestFixture]
    public class Emailer_Fixture
    {
        public static ILog _logger = LogManager.GetLogger(typeof (Emailer));

        public Emailer_Fixture()
        {
            XmlConfigurator.Configure();
        }

        [Test, Ignore]
        public void PingTest()
        {
            // Arrange
            var emailHelper = new Emailer();

            var stop = false;

            // Act
            while (stop)
            {
                try
                {
                    var checkedStatus =
                        emailHelper.CheckStatus(
                            "https://services.yesmail.com/enterprise/status/0fb77aa1-7335-4101-847f-f18aa82a5866");
                    Thread.Sleep(45000);
                    stop = true;
                }
                catch (Exception e)
                {
                }
            }
        }


        [Test]
        public void _1_InvalidApiCredentials_Should_Throw401Exception()
        {
            var settings = new ApiSettings();
            settings.Password = "badpassword";
            var emailHelper = new Emailer(settings);
            var messageId = 1256210;
            var dto = DtoFactory.CreateEr1Message(RandomGenerator.RandomString(6));

            var sendAndSubscribe = YesMailMapper.CreateSendAndSubcribeMessage(dto, messageId);

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
        public void _2_CheckStatusForEmailWithBadPayload_Should_Return_StatusCodeError()
        {
            // Arrange
            var emailHelper = new Emailer();

            // Act
            var checkedStatus =
                emailHelper.CheckStatus(
                    @"https://services.yesmail.com/enterprise/status/0fb77aa1-7335-4101-847f-f18aa82a5866");


            // Assert
            _logger.Info("\nCheckStatus.Status\n-------------\n" + checkedStatus.statusMessage);
            Assert.That(checkedStatus.statusCode, Is.EqualTo(StatusCode.ERROR), "StatusCode");
        }

        [Test]
        public void _3_SendMail_Should_Return_StatusSubmitted()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateEr1Message(RandomGenerator.RandomString(6));

            var sendAndSubscribe = YesMailMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var statusType = emailHelper.SendEmail(sendAndSubscribe);

            // Assert
            _logger.Info("\nStatusNoWaitUrl\n-------------\n" + statusType.statusNoWaitURI);
            Assert.That(statusType.statusNoWaitURI,
                        Contains.Substring(@"https://services.yesmail.com/enterprise/statusNoWait"));
            Assert.That(statusType.statusCode, Is.EqualTo(StatusCode.SUBMITTED), "StatusCode");
        }

        [Test]
        public void _4_CheckStatusForValidPayload_Should_Not_Return_Error()
        {
            var emailHelper = new Emailer();
            var messageId = 1256210;
            var dto = DtoFactory.CreateEr1Message(RandomGenerator.RandomString(6));

            var sendAndSubscribe = YesMailMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var initialStatus = emailHelper.SendEmail(sendAndSubscribe);
            var checkStatus = emailHelper.CheckStatus(initialStatus.statusURI);

            // Assert
            _logger.Info("\nStatusMessage: " + checkStatus.statusMessage);
            _logger.Info("\nStatusNoWaitUrl\n-------------\n" + checkStatus.statusNoWaitURI);
            _logger.Info("\nStatusNoWaitUrl\n-------------\n" + checkStatus.statusCode);
            Assert.That(checkStatus.statusCode, Is.Not.EqualTo(StatusCode.ERROR), "StatusCode");
        }
    }
}