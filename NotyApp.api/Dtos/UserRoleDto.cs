using NotyApp.api.models;

namespace NotyApp.api.Dtos
{
    public class UserRoleDto
    {

        public string id { get; set; }


        public virtual RoleDto role { get; set; }
    }
}
