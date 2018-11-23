using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(15)]
        public string Username { get; set; }

        public 
    }
}
