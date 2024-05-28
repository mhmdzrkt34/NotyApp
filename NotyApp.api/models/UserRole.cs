using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class UserRole
    {
        [Key]
        public string id { get; set; }


        public virtual Role role { get; set; }

        public string role_id { get; set; }

        public User user { get; set; }
        public string user_id { get; set; }

 
        public DateTime time {  get; set; }



        public UserRole()
        {

            id = Guid.NewGuid().ToString();

            time = DateTime.Now;




        }
    }
}
