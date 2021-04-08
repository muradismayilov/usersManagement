using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersManagement.Models
{
    public class User
    {
       
        [Required]
        public int Id { get; set; }

        [Required]
        
        public string Firstname { get; set; }
        
        [Required]
        public string Lastname { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
