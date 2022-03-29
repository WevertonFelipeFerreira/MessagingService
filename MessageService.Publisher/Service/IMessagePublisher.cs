using MessageService.Publisher.DTOs.Request;
using System.Threading.Tasks;

namespace MessageService.Publisher.Service
{
    public interface IMessagePublisher
    {
        public Task<long> Publish(SendMessageRequest obj);
        public Task CancelMessage(long sequence);
    }
}
