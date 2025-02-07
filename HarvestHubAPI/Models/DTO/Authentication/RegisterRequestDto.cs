using System.ComponentModel.DataAnnotations;

namespace HarvestHubAPI.Models.DTO.Authentication;

public class RegisterRequestDto
{
    [Required]
    [MaxLength(255)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public string Password { get; set; }

    [Required]
    [MaxLength(255)]
    public string UserGivenName { get; set; }
}
