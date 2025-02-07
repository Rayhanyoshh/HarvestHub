using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.Entities;
public class WorkTaskType
{
    [Key]
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

    // Navigational Properties
    public virtual ICollection<WorkTask> WorkTasks { get; set; }
}
