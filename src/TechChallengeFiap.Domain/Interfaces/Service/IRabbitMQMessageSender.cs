using TechChallengeFiap.Core;

namespace TechChallengeFiap.Domain.Interfaces.Service
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
