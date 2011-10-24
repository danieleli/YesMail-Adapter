using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SC.YesMailAdapter;

namespace SC.YesmailAdapter._Test
{
    [TestFixture]
    public class EmailHelper_Fixture
    {
        public EmailHelper_Fixture()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        [Test]
        public void Test1()
        {
            // Arrange
            var emailHelper = new Emailer();
            var dto = new EmailMessageDto() {Email = "email@test.ocm", Generic1 = "www.yahoo.com", MessageMasterId = "4324", Url1 = "www.google.com"};

            // Act
            var response = emailHelper.SendEmail(dto);

            // Assert
        }
    }
}
