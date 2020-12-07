using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySerrver4.Quickstart
{
    public class ClaimStore :IEnumerable
    {
        public string _given_name { get; set; }
        public string _middle_name { get; set; }
        public string _family_name { get; set; }
        public string _Adress { get; set; }
        public string _Position { get; set; }
        public IFormFile _Picture { get; set; }
        public List<Claim> Claims { get; set; }

        public ClaimStore(string family_name, string Gender, string Adress, string given_name , string middle_name /*IFormFile picture*/)
        {
            _given_name = given_name;
            _Position = Gender;
            _middle_name = middle_name;
            _family_name = family_name;
            _Adress = Adress;
            //_Picture = picture;
            Claims = new List<Claim>();
        }

        public void SetClaims()
        {
            if (_given_name != null)
            {
                Claims.Add(new Claim("family_name", _family_name));
                Claims.Add(new Claim("position", _Position));
                Claims.Add(new Claim("Adress", _Adress));
                Claims.Add(new Claim("given_name", _given_name));
                Claims.Add(new Claim("middle_name", _middle_name));
                //Claims.Add(new Claim("picture", _Picture.ContentDisposition));
            }
           
        }    
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("family_name", " "),
            new Claim("position", " "),
            new Claim("Adress", " "),
            new Claim("given_name"," "),
            new Claim("middle_name"," ")
        };

        public IEnumerator GetEnumerator()
        {
            return Claims.GetEnumerator();
        }
    }
}
