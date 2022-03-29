using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;
using MessageService.Publisher.DTOs.Request;

namespace MessageService.Publisher.Service
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IQueueClient _queue;
        public MessagePublisher(IQueueClient queue)
        {
            _queue = queue;
        }

        public async Task CancelMessage(long sequence)
        {
            await _queue.CancelScheduledMessageAsync(sequence);
        }

        public async Task<long> Publish(SendMessageRequest obj)
        {
            var messageAsString = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(messageAsString));

            long seq = await _queue.ScheduleMessageAsync(message, obj.EndTime);

            return seq;
        }
    }
}
