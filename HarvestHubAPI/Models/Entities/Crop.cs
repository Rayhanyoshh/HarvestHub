using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.Entities
{
    public class Crop
    {
        [Key]
        public int CropId { get; set; }

        [Required]
        [MaxLength(255)]
        public string CropCode { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        [Required]
        public DateTimeOffset ModifiedDate { get; set; }

        [Required]
        public int ModifiedUserId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        // Navigational Properties
        public virtual ICollection<FarmField> FarmFields { get; set; }  // Pastikan ini ada
    }
}