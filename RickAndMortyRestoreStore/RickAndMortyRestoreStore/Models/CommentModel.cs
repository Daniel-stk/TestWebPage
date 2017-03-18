using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public virtual JobModel Job { get; set; }
    }
}