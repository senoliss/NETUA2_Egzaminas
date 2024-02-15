using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using NETUA2_Egzaminas.DAL;
using NETUA2_Egzaminas.DAL.Extensions;
using NETUA2_Egzaminas.API.Extensions;
using Microsoft.AspNetCore.Builder;

namespace NETUA2_Egzaminas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAPIServices();
            builder.Services.AddBLLServices();
            builder.Services.AddDatabaseServices();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)     // nurodome kad musu autentikacijos schema busu jwt nesiotojo schema (kas nesa jwt tokena tas prisistato)
                    .AddJwtBearer(options =>
                    {
                        var secretKey = builder.Configuration.GetSection("Jwt:Key").Value;
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                            IssuerSigningKey = key
                        };
                    });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));

                // Enable logging of sql querries
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NETUA2 Final Exam - Users",
                    Description = "NETUA2 Final Examp WEB ASP.NET Core API for User Registration and User Information creation",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter valid JWT token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }},
                        new List<string>()
                    }
                });

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.MapControllers();

            app.Run();
        }
    }
}
