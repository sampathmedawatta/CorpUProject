using CorpU.API.Auth;
using CorpU.API.Auth.Interfaces;
using CorpU.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Serilog;
using CorpU.Data.Repository.Interfaces;
using CorpU.Data.Repository;
using CorpU.Data.Profiles;
using CorpU.Business.Interfaces;
using CorpU.Business;
using Microsoft.EntityFrameworkCore;
using CorpU.Data;
using CorpU.Common.Communication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<JwtTokenSettings>(builder.Configuration.GetSection("JwtTokenSettings"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer
                 (builder.Configuration.GetConnectionString("ConnectionStrings")));

builder.Services.Configure<PasswordSettings>(builder.Configuration.GetSection("PasswordSettings"));
//var PasswordSettings = builder.Configuration
//   .GetSection("PasswordSettings")
//   .Get<EmailSettings>();
//builder.Services.AddSingleton(PasswordSettings);

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
var emailSettings = builder.Configuration
   .GetSection("EmailSettings")
   .Get<EmailSettings>();
builder.Services.AddSingleton(emailSettings);

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IEmailManager, EmailManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IApplicantManager, ApplicantManager>();
builder.Services.AddScoped<IApplicantContactManager, ApplicantContactManager>();
builder.Services.AddScoped<IApplicantQualificationManager, ApplicantQualificationManager>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<ITokenGenerator, TokenGenerator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "CorpU API",
            Description = "CorpU API",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "CorpU Solutions",
                Email = string.Empty,
                Url = new Uri("https://twitter.com/spboyer"),
            },
            License = new OpenApiLicense
            {
                Name = "CorpU Solutions",
                Url = new Uri("https://example.com/license"),
            }
        });

        c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "Enter the Api Key below:",
            Name = "ApiKey",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {

            {
                 new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "ApiKey"
                                },
                                  Scheme = "oauth2",
                                  Name = "ApiKey",
                                  In = ParameterLocation.Header,
                            },
                            new List<string>()
            }
        });

       
    });

builder.Services.AddCors(options => options.AddPolicy(name :"corpU",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
    ));

var _logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corpU");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
