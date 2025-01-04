using Microsoft.EntityFrameworkCore;
using Onebox_backend.Models;
using Onebox_backend.Models.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OneboxDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OneboxDB")));

builder.Services.AddScoped<BoxModel>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowLocalhost");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AllowLocalhost");
app.MapControllers();

app.Run();
