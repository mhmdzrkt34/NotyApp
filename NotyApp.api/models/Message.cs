using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class Message
    {
        [Key]
        public string id { get; set; }

        
        //sender
        public User sender { get; set; }

        public string sender_id { get; set; }
        //

        //reiever
        public User reciever {  get; set; }


        public string reciever_id {  get; set; }
        //

        public string type { get; set; }

        public DateTime time { get; set; }


        public string message { get; set; }


        public Message()
        {
            id = Guid.NewGuid().ToString();

            time = DateTime.UtcNow;



        }


    }
}
