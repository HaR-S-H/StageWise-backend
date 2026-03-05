using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Helpers.Exceptions;
using StageWise.Helpers.Implementations;
using StageWise.Helpers.Interfaces;
using StageWise.Mappings;
using StageWise.Repositories.Implementations;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Implementations;
using StageWise.Services.Business.Interfaces;
using StageWise.Services.Infrastructure.Implementations;
using StageWise.Services.Infrastructure.Interfaces;
using StageWise.Services.Infrastructure.Workers;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Add Services / DI
// =====================

// JWT, password hasher, Auth service
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IMessageQueue, RabbitMqService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IHodRepository, HodRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();


builder.Services.AddHostedService<EmailWorker>();
// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

// Authorization & Controllers
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================
// Build the app
// =====================
var app = builder.Build();

// =====================
// Global Exception Handler Middleware
// =====================
app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            var ex = exceptionHandlerFeature.Error;

            int statusCode = ex switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                InvalidOperationException => StatusCodes.Status409Conflict,
                AppException appEx => appEx.StatusCode, // custom exception
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;

            var response = new
            {
                message = ex.Message,
                stack = app.Environment.IsDevelopment() ? ex.StackTrace : null
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    });
});

// =====================
// Middleware pipeline
// =====================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // If you have authentication
app.UseAuthorization();

app.MapControllers();

app.Run();
