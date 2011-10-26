using NUnit.Framework;
using SC.YesMailAdapter.Factory;
using SC.YesmailAdapter._Test.Helpers;
using log4net;

namespace SC.YesmailAdapter._Test.Fixtures
{
    [TestFixture]
    public class Serialization_Fixture
    {
        public static ILog _logger = LogManager.GetLogger(typeof(Serialization_Fixture));
        [Test]
        public void Serialization()
        {
            // Arrange
            var messageId = 3332324;
            var dto = DtoFactory.CreateTestMessageDto("test1");

            // Act
            var sendAndSubscribe = SubscribeAndSendMapper.CreateSendAndSubcribeMessage(dto, messageId);
            var serializedObject = YesMailSerializer.CreateRequestBody(sendAndSubscribe);
            _logger.Info(serializedObject);
        }
    }
}
