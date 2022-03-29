using System;

namespace MessageService.Publisher.DTOs.Request
{
    public class SendMessageRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsPremium { get; set; }
    }
}
