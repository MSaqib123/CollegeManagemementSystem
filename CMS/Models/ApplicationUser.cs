using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Student = new HashSet<TblStudent>();
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }


        [InverseProperty("user")]
        public virtual ICollection<TblStudent> Student{ get; set; }


        [NotMapped]
        public IFormFile iImage { get; set; }
    }
}
