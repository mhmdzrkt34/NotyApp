using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class UserRole
    {
        [Key]
        public Guid id { get; set; }


        public virtual Role role { get; set; }

        public Guid role_id { get; set; }

        public User user { get; set; }
        public Guid user_id { get; set; }

 
        public DateTime time {  get; set; }



        public UserRole()
        {

            id = Guid.NewGuid();

            time = DateTime.Now;




        }
    }
}
