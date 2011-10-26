#region Usings

using System;
using log4net;

#endregion

namespace SC.YesmailAdapter._Test.Helpers
{
    public static class DtoFactory
    {
        public static ILog _logger = LogManager.GetLogger(typeof (DtoFactory));

        public static TestMessageDto CreateTestMessageDto(string seed)
        {
            var dto = new TestMessageDto
                          {
                              ExpirationDate = DateTime.Now.ToString("ddhhmmssff"),
                              Generic1 = "www.generic1" + seed + ".com",
                              Generic2 = "www.generic2" + seed + ".com",
                              Name1 = "name1" + seed,
                              Url1 = "www.url1" + seed + ".com",
                              ConsumerId = 343223,
                          };

            return dto;
        }

        public static TestMessageDto CreateEr1Message(string seed)
        {
            var dto = new TestMessageDto
                          {
                              Brand = seed,
                              Generic1 = seed,
                              Generic3 = seed,
                              Name1 = seed,
                              Email = seed + "@tester.com",
                              Generic2 = seed,
                              Url1 = seed,
                              ConsumerId = 12345678,
                              ExpirationDate = seed,
                              MasterMessageId = seed,
                              //MessageType = seed,
                              Name2 = seed,
                              ProductDesc = seed,
                              RedemptionCode = seed,
                              SecurityCode = seed,
                              Url2 = seed,
                              Url3 = seed
                          };

            return dto;
        }
    }
}