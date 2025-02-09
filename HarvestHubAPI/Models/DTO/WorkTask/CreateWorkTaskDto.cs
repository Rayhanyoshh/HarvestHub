using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubProjectAPI.Models.DTO.WorkTask
{
    public class CreateWorkTaskDto
    {
        [Required]
        public int FarmFieldId { get; set; }

        [Required]
        [MaxLength(50)]
        public string WorkTaskTypeCode { get; set; }

        [Required]
        public DateTimeOffset DueDate { get; set; }

        public string Instruction { get; set; }
        public string WorkTaskName { get; set; }
        public string Attachment { get; set; }
    }
}