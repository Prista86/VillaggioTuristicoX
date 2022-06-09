using Microsoft.AspNetCore.Identity;

namespace MVC_TDPC13.DB.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}