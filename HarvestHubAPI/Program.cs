using System.Text;
using HarvestHubAPI.Models;
using HarvestHubAPI.Repositories.Implementations;
using HarvestHubAPI.Repositories.Interfaces;
using HarvestHubAPI.Services.Implementations;
using HarvestHubAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Mendapatkan connection string dari konfigurasi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Mendapatkan konfigurasi JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                // Log kesalahan autentikasi
                Console.WriteLine("Authentication failed: " + context.Exception.Message);
                context.Response.Headers.Add("Token-Invalid", "true");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                // Log validasi token berhasil
                Console.WriteLine("Token valid");
                return Task.CompletedTask;
            }
        };
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]))
        };
    });

// Menambahkan konfigurasi DbContext
builder.Services.AddDbContext<HarvestHubContext>(options =>
    options.UseSqlServer(connectionString));

// Menambahkan konfigurasi AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Menambahkan konfigurasi CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});



builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IWorkTaskService, WorkTaskService>();
builder.Services.AddScoped<IFarmFieldService, FarmFieldService>();
builder.Services.AddScoped<IFarmSiteService, FarmSiteService>();
builder.Services.AddScoped<IWorkTaskTypeService, WorkTaskTypeService>();
builder.Services.AddScoped<ICropService, CropService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage(); // Tambahkan ini untuk menangani pengecualian di lingkungan pengembangan
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Middleware untuk menangani pengecualian di produksi
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();