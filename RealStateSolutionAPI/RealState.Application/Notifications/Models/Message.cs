using System.Collections.Generic;

namespace RealState.Application.Notifications.Models
{
    public class Message
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}