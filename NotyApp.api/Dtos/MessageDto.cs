using NotyApp.api.models;

namespace NotyApp.api.Dtos
{
    public class MessageDto
    {
        public string id { get; set; }

        public string type { get; set; }

        public DateTime time { get; set; }

        public UserDto reciever { get; set; }

        public string reciever_id { get; set; }
        public string sender_id { get; set; }


        public string message { get; set; }
    }
}
