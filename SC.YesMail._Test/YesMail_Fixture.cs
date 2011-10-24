using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SC.YesMail;

namespace SC.YesMail._Test
{
    [TestFixture]
    public class YesMail_Fixture
    {
        [Test]
        public void Test1()
        {
            var users = new USERS();
            var transactions = new API_TRANSACTIONS();
            var promos = new API_PROMOS();

            log4net.Config.XmlConfigurator.Configure();

            // Act
            var response = SC.YesMail.Object.TriggerMail(users, transactions, null, promos);

            // Assert
            Assert.That(response, Is.EqualTo(1), "Response");
        }

        //public void setup()
        //{
        //    var trans = GetTransaction("test@ymail.com", "ER1_DefaultPackReceiver", 1256210);
        //    var promos = GetEr1Promos(pack, _defaultPackReceiver);
        //    var curUser = GetApiUser(pack.UserOcdConsumerId, pack.EmailAddress, _defaultPackReceiver);
        //    var curEmail = CreateMail(curUser, promos, trans);
        //    TriggerEmailSend(curEmail);
        //}

        public API_TRANSACTIONS GetTransaction(string email, string emailName, int _mmid)
        {
            var trans = new API_TRANSACTIONS
                            {
                                brand = "Kleenex",
                                email = email,
                                mmid = _mmid,
                                type = emailName
                            };
            return trans;
        }
    }
}
