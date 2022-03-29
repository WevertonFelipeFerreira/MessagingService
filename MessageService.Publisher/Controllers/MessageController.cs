using MessageService.Publisher.DTOs.Request;
using MessageService.Publisher.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MessageService.Publisher.Controllers
{
    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;
        public MessageController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Request contract to send message to the queue</param>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            var seq = await _messagePublisher.Publish(request);
            return Ok(seq);
        }

        /// <summary>
        /// Cancel a message in the queue
        /// </summary>
        /// <param name="id">Message indentifier</param>
        /// <returns></returns>
        [HttpDelete("send/{id}")]
        public async Task<IActionResult> DeleteMessage(long id)
        {
            await _messagePublisher.CancelMessage(id);
            return NoContent();
        }
    }
}
