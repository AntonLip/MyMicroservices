using Microsoft.AspNetCore.Identity;


namespace IdentitySerrver4.Models
{
    public class AppUser:IdentityUser
    {
        public string FamilyName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string address { get; set; }
    }
}
