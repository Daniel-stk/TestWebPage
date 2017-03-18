using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models
{
    public class RequestModel
    {
        [Key]
        public int RequestId { get; set; }
        public string Media { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Only chars and whitespaces are allowed")]
        [StringLength(25, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Description { get; set; }
        public virtual JobModel Job { get; set; }
    }
}