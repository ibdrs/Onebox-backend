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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
