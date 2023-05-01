using CMS.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CMS.Data.ViewModel
{
    public class VMRoleAssign
    {
        //get Role
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; } //jin ko  role milaa ho gaa

        //User
        public string RoleName { get; set; }
        public IEnumerable<IdentityUser> NonMembers{ get; set; } //jin ko   Role nhn millaa


        //ids for Add in Role 
        //(emploee role  1_time me   --> Multiple user ko Assin ho gaa)
        public string[] AddIds { get; set; }


        //ids for delete from Role
        //(emploee role  1_time me   --> Multiple user ko Assin ho gaa)
        public string[] DeleteIds { get; set; }
    }
}
