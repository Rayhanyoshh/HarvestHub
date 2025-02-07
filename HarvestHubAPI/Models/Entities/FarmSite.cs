using System;
using System.ComponentModel.DataAnnotations;


namespace HarvestHubAPI.Models.Entities;
public class FarmSite
{
    [Key]
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

    // Navigational Properties
    public virtual ICollection<FarmField> FarmFields { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
