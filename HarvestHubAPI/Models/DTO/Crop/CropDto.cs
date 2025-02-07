using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubProjectAPI.Models.DTO.Crop
{
    public class CropDTO
    {
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
    }

    public class CreateCropDto
    {
        [Required]
        [MaxLength(255)]
        public string CropCode { get; set; }
    }
}