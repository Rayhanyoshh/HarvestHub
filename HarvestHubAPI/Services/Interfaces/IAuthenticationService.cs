using HarvestHubAPI.Models.DTO.Authentication;

namespace HarvestHubAPI.Services.Interfaces;

public interface IAuthenticationService
{
    Task<LoginResponseDto> Authenticate(LoginRequestDto loginRequest);
    Task<bool> Register(RegisterRequestDto registerRequest);
}