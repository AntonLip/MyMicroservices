using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySerrver4.Views.Admin
{
    public class EditUserClaim
    {
        [Required]
        public string given_name { get; set; }
        [Required]
        public string middle_name { get; set; }
        [Required]
        public string family_name { get; set; }
        [Required]
        public string addres { get; set; }
        [Required]
        public string position { get; set; }



        [Required]
        [EmailAddress]
        [Remote(action: "EmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password's didn't match")]
        public string ConfirmPassword { get; set; }


        [Phone]
        public string phoneNumber { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
