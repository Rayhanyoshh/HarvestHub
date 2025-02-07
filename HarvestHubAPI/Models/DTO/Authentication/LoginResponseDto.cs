namespace HarvestHubAPI.Models.DTO.Authentication;

public class LoginResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
