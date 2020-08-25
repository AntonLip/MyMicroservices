using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerHost.Quickstart.UI
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleManager { get; set; }
    }
}
