using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RickAndMortyRestoreStore.Models
{
    public class JobModel
    {
        [Required]
        [Key]
        [ForeignKey("Request")]
        public int JobId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string MediaBefore { get; set; }
        public string MediaAfter { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public decimal Amount { get; set; }
        public virtual RequestModel Request{ get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }

    }
}