using Microsoft.EntityFrameworkCore;
using StageWise.Data;
using StageWise.Helpers.Implementations;
using StageWise.Helpers.Interfaces;
using StageWise.Mappings;
using StageWise.Repositories.Implementations;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Implementations;
using StageWise.Services.Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// builder.Services.AddAWSService<IAmazonS3>();
// builder.Services.AddScoped<IS3Service, S3Service>();
// builder.Services.AddScoped<IMessageQueue, RabbitMQService>();
// builder.Services.AddScoped<ICacheService, RedisService>();
// builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IHodRepository, HodRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = "localhost:6379";
// });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
app.UseAuthorization();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
