using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubProjectAPI.Models.DTO.WorkTaskType
{
    public class WorkTaskTypeDTO
    {
        [Required]
        [MaxLength(50)]
        public string WorkTaskTypeCode { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        [Required]
        public int CreatedUserId { get; set; }

        [Required]
        public DateTimeOffset ModifiedDate { get; set; }

        [Required]
        public int ModifiedUserId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }

    public class CreateWorkTaskTypeDto
    {
        [Required]
        [MaxLength(50)]
        public string WorkTaskTypeCode { get; set; }
    }
}