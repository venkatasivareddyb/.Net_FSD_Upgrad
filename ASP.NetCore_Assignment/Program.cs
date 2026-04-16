
using Asp.net_Core_Assignment_1.Data;
using Asp.net_Core_Assignment_1.Helpers;
using Asp.net_Core_Assignment_1.Middleware;
using Asp.net_Core_Assignment_1.Repositories;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // -------------------- Services Registration --------------------

            // Add DbContext
            builder.Services.AddDbContext<HealthcareDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Repositories
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

            // Add Services
            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<DoctorService>();
            builder.Services.AddScoped<AppointmentService>();
            builder.Services.AddScoped<PrescriptionService>();

            // Add Helpers
            builder.Services.AddScoped<JwtTokenGenerator>();

            // Add Controllers
            builder.Services.AddControllers();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // -------------------- JWT Authentication --------------------
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            // -------------------- Build App --------------------
            var app = builder.Build();

            // -------------------- Middleware Pipeline --------------------

            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Custom Logging Middleware
            app.UseRequestLogging();

            // Global Exception Handling Middleware
            app.UseGlobalExceptionHandler();

            // HTTPS Redirection
            app.UseHttpsRedirection();

            // Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Map Controllers
            app.MapControllers();

            // Run Application
            app.Run();
        }
    }
}
