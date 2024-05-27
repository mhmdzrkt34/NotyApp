using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class Message
    {
        [Key]
        public Guid id { get; set; }

        
        //sender
        public User sender { get; set; }

        public Guid sender_id { get; set; }
        //

        //reiever
        public User reciever {  get; set; }


        public Guid reciever_id {  get; set; }
        //

        public string type { get; set; }

        public DateTime time { get; set; }


        public string message { get; set; }


        public Message()
        {
            id = Guid.NewGuid();

            time = DateTime.UtcNow;



        }


    }
}
