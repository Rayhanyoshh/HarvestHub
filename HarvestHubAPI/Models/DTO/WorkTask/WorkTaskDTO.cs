namespace HarvestHubProjectAPI.Models.DTO.WorkTask;

public class WorkTaskDTO
{
    public int WorkTaskId { get; set; }
    public int FarmFieldId { get; set; }
    public string WorkTaskTypeCode { get; set; }
    public string WorkTaskStatusCode { get; set; }
    public DateTimeOffset StartedDate { get; set; }
    public DateTimeOffset? CanceledDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsStarted { get; set; }
    public bool IsCancelled { get; set; }
    // Tambahkan properti lain jika diperlukan
}
