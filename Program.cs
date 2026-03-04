using Microsoft.EntityFrameworkCore;
using StageWise.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// builder.Services.AddAWSService<IAmazonS3>();
// builder.Services.AddScoped<IS3Service, S3Service>();
// builder.Services.AddScoped<IMessageQueue, RabbitMQService>();
// builder.Services.AddScoped<ICacheService, RedisService>();
// builder.Services.AddScoped<IEmailService, EmailService>();
// builder.Services.AddScoped<IJwtService, JwtService>();
// builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = "localhost:6379";
// });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
