using Microsoft.AspNetCore.Identity;

namespace AuditorAPI.Domain
{
    public class ClientUser:IdentityUser
    {
        public string Name { get; set; }
        //public string Username;
    }
}