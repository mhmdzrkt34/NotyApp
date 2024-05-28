using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class Contact
    {

        [Key]
        public string id {  get; set; }


        public string name { get; set; }

        //senderContact
        public virtual User Sender { get; set; }

        public string sender_id { get; set; }



        //recieverContact

        public virtual User reciever { get; set; }

        public string reciever_id {  get; set; }

        public bool status { get; set; }

        public DateTime time { get; set; }


        public Contact()
        {
            id= Guid.NewGuid().ToString();

            time = DateTime.UtcNow;
            status = false;
        }



    }
}
