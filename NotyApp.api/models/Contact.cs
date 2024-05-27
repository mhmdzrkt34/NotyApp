using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class Contact
    {

        [Key]
        public Guid id {  get; set; }


        public string name { get; set; }

        //senderContact
        public virtual User Sender { get; set; }

        public Guid sender_id { get; set; }



        //recieverContact

        public virtual User reciever { get; set; }

        public Guid reciever_id {  get; set; }

        public bool status { get; set; }

        public DateTime time { get; set; }


        public Contact()
        {
            id= Guid.NewGuid();

            time = DateTime.UtcNow;
            status = false;
        }



    }
}
