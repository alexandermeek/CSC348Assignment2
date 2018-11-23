using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Models
{
    public class Comment
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Body { get; set; }

        [Required]
        public ApplicationUser Commenter { get; set; }

        [Display(Name = "Commented On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }


    }
}
