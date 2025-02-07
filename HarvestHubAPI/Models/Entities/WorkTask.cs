using System;
using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.Entities;
public class WorkTask
{
    [Key]
    public int WorkTaskId { get; set; }

    [Required]
    public int FarmFieldId { get; set; }

    [Required]
    [MaxLength(50)]
    public string WorkTaskTypeCode { get; set; }

    [Required]
    [MaxLength(50)]
    public string WorkTaskStatusCode { get; set; }

    [Required]
    public DateTimeOffset StartedDate { get; set; }

    public DateTimeOffset CanceledDate { get; set; }

    [Required]
    public DateTimeOffset DueDate { get; set; }

    [Required]
    public DateTimeOffset CreatedDate { get; set; }

    [Required]
    public int CreatedUserId { get; set; }

    [Required]
    public DateTimeOffset ModifiedDate { get; set; }

    [Required]
    public int ModifiedUserId { get; set; }

    [Required]
    public bool IsCompleted { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public bool IsStarted { get; set; }

    [Required]
    public bool IsCancelled { get; set; }

    // Navigational Properties
    public virtual FarmField FarmField { get; set; }
    public virtual WorkTaskType WorkTaskType { get; set; }

}
