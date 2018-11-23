using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSC348Assignment2.Models
{
    public class Post
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Title { get; set; }

        [Required, StringLength(300)]
        public string Body { get; set; }

        [Required]
        public User Poster { get; set; }

        [Display(Name = "Posted On")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date
        {
            get
            {
                return Date;
            }
            set
            {
                Date = DateTime.Now;
            }
        }

        public Comment[] Comments { get; set; }
    }
}
