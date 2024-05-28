using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.requests.UserRequest
{
    public class MessageRequest
    {
        [Required]
        public string sender_id { get; set; }

        [Required]

        public string reciever_id { get; set; }

        [Required]
        [AllowedValues("text","audio","video")]

        public string type { get; set; }

        [Required]

        public string message { get; set; }
    }
}
