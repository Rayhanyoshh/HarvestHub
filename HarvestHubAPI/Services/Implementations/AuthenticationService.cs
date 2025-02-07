namespace HarvestHubAPI.Services.Implementations;
using HarvestHubAPI.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HarvestHubAPI.Models.DTO.Authentication;
using HarvestHubAPI.Models.Entities;
using HarvestHubAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public AuthenticationService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> Authenticate(LoginRequestDto loginRequest)
    {
        try
        {
            var user = await _unitOfWork.Users.AsQueryable()
                .FirstOrDefaultAsync(u => u.UserEmailAddress == loginRequest.Email);

            if (user == null)
                throw new Exception("Invalid credentials");

            if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Invalid credentials");

            var token = GenerateJwtToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryMinutes"]))
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Error during authentication: {ex.Message}", ex);
        }
    }

    public async Task<bool> Register(RegisterRequestDto registerRequest)
    {
        try
        {
            // Cek apakah email sudah digunakan
            var existingUser = await _unitOfWork.Users.AsQueryable()
                .AnyAsync(u => u.UserEmailAddress == registerRequest.Email);

            if (existingUser)
                throw new Exception("Email already registered");

            // Buat hash password
            CreatePasswordHash(registerRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Username = registerRequest.Username,
                UserEmailAddress = registerRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserPassword = registerRequest.Password, // Tambahkan ini
                UserGivenName = registerRequest.UserGivenName,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow,
                IsDeleted = false,
                UserStatus = "Active"
            };

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.Save();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error during registration: {ex.Message}", ex);
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        try
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating password hash: {ex.Message}", ex);
        }
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        try
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error verifying password hash: {ex.Message}", ex);
        }
    }

    private string GenerateJwtToken(User user)
    {
        try
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error generating JWT token: {ex.Message}", ex);
        }
    }
}

