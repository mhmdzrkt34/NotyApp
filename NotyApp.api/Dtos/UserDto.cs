using NotyApp.api.models;

namespace NotyApp.api.Dtos
{
    public class UserDto
    {

        public string id { get; set; }

        public string email { get; set; }

        public virtual ICollection<UserRoleDto> roles { get; set; }

        public virtual ICollection<MessageDto> sendedMessages { get; set; }


        public virtual ICollection<MessageDto> recievedMessages { get; set; }


        public virtual ICollection<ContactDto> addedContacts { get; set; }

        public virtual ICollection<ContactDto> recievedContacts { get; set; }
    }
}
