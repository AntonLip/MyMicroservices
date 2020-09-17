using Microsoft.AspNetCore.Identity;


namespace IdentitySerrver4.Models
{
    public class AppUser:IdentityUser
    {
        public string family_name { get; set; }
        public string middle_name { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
    }
}
