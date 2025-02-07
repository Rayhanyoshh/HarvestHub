namespace HarvestHubProjectAPI.Models.DTO.FarmField;

public class FarmFieldDTO
{
    public int FarmFieldId { get; set; }
    public int FarmSiteId { get; set; }
    public string FarmFieldName { get; set; }
    public string FarmFieldCode { get; set; }
    public float RowWidth { get; set; }
    public string FarmFieldRowDirection { get; set; }
    public string FarmFieldColorHexCode { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public int CreatedUserId { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
    public int ModifiedUserId { get; set; }
    public bool IsDeleted { get; set; }
}