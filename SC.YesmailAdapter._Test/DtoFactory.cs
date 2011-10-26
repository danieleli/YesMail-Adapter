using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace SC.YesmailAdapter._Test
{
    public static class DtoFactory
    {
        public static ILog _logger = LogManager.GetLogger(typeof(DtoFactory));
        public static TestMessageDto CreateTestMessageDto(string seed)
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
