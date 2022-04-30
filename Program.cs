using ArmyAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ArmyContext>( options => options.UseSqlite ("Data Source=ArmyAPI.db"));

builder.Services.AddCors(
    options => {
        options.AddPolicy("AllowAnyOrigin",
            policies => policies
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
        );
    }
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DefaultFilesOptions newOptions = new DefaultFilesOptions();
newOptions.DefaultFileNames.Add("index.html");

app.UseDefaultFiles(newOptions);

app.UseStaticFiles();

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
