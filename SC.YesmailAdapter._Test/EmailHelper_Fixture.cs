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
            var dto = DtoFactory.CreateTestMessageDto("test1");

            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);

            // Act
            var response = emailHelper.SendEmail(sendAndSubscribe);
            //var response = emailHelper.SendEmail(dto, messageId);
        }




    }
}
