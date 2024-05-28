using System.ComponentModel.DataAnnotations;

namespace NotyApp.api.models
{
    public class Role
    {
        [Key]
        public string id { get; set; }

        public string name { get; set; }


        public DateTime time { get; set; }

        public virtual ICollection<UserRole> users { get; set; }

        


        public Role()
        {

            id = Guid.NewGuid().ToString();
            time = DateTime.UtcNow;
        }
    }
}
