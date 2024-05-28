using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class User
    {
        [Key]
        public string id {  get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public DateTime time {  get; set; }


        public virtual ICollection<UserRole> roles { get; set; }

        public virtual ICollection<Message> sendedMessages { get; set; }


        public virtual ICollection<Message> recievedMessages {  get; set; } 


        public virtual ICollection<Contact> addedContacts { get; set; }

        public virtual ICollection<Contact> recievedContacts { get; set; }





        public User() {
            id = Guid.NewGuid().ToString();

            time = DateTime.UtcNow;
        }
    }
}
