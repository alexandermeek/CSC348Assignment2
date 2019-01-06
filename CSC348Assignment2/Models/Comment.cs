using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        public string ApplicationUserId { get; set; }

        public int PostId { get; set; }

        [Display(Name = "Commented On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser Commenter { get; set; }

        public virtual Post Post { get; set; }
    }
}
