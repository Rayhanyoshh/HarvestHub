using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.Entities
{
    public class FarmField
    {
        [Key]
        public int FarmFieldId { get; set; }

        [Required]
        public int FarmSiteId { get; set; }

        [Required]
        public int PrimaryCropId { get; set; }  // Foreign key to Crop

        [Required]
        [MaxLength(255)]
        public string FarmFieldName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FarmFieldCode { get; set; }

        [Required]
        public float RowWidth { get; set; }

        [Required]
        [MaxLength(50)]
        public string FarmFieldRowDirection { get; set; }

        [Required]
        [MaxLength(6)]
        public string FarmFieldColorHexCode { get; set; }

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
        public virtual FarmSite FarmSite { get; set; }
        public virtual Crop PrimaryCrop { get; set; }  // Navigasi ke Crop
        public virtual ICollection<WorkTask> WorkTasks { get; set; }
    }
}