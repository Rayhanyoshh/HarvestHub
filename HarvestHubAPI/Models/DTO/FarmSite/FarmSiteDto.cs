
using System.ComponentModel.DataAnnotations;

namespace HarvestHubProjectAPI.Models.DTO.FarmSite
{
    public class FarmSiteDTO
    {
        public int FarmSiteId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FarmSiteName { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        public int? CreatedUserId { get; set; }

        [Required]
        public DateTimeOffset ModifiedDate { get; set; }

        [Required]
        public int ModifiedUserId { get; set; }

        [Required]
        public int DefaultPrimaryCropId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }

    public class CreateFarmSiteDto
    {
        [Required]
        [MaxLength(255)]
        public string FarmSiteName { get; set; }

        [Required]
        public int DefaultPrimaryCropId { get; set; }

        public int? CreatedUserId { get; set; }  // Tambahkan properti ini jika diperlukan
    }
}

