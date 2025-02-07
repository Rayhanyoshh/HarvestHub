using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }

    public bool IsCustomerUser { get; set; }

    [Required, MaxLength(255)]
    public string Username { get; set; }

    public string UserPassword { get; set; }

    [Required, MaxLength(255)]
    public string UserGivenName { get; set; }

    [Required, MaxLength(255)]
    [EmailAddress]
    public string UserEmailAddress { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    [Required]
    public DateTimeOffset CreatedDate { get; set; }

    public int? CreatedUserId { get; set; }

    [Required]
    public DateTimeOffset ModifiedDate { get; set; }

    [Required]
    public int ModifiedUserId { get; set; }

    [Required, MaxLength(255)]
    public string UserStatus { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    public int? FarmSiteId { get; set; }

    // Navigational Properties
    public virtual FarmSite FarmSite { get; set; }


}
