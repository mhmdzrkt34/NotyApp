namespace NotyAppHub.api.models
{
    public class Message
    {

        public string id { get; set; }



        public string sender_id { get; set; }



        public string reciever_id { get; set; }
   

        public string type { get; set; }

        public DateTime time { get; set; }


        public string message { get; set; }
    }
}
