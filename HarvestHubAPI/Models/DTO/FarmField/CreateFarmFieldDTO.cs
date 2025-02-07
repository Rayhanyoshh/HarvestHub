using System.ComponentModel.DataAnnotations;

namespace HarvestHubProjectAPI.Models.DTO.FarmField;

public class CreateFarmFieldDto
{
    [Required]
    public int FarmSiteId { get; set; }

    [Required]
    public string FarmFieldName { get; set; }

    public float RowWidth { get; set; }
    public string FarmFieldRowDirection { get; set; }
    public string FarmFieldColorHexCode { get; set; }
    public int PrimaryCropId { get; set; }

    // Tambahkan properti lain jika diperlukan
}
