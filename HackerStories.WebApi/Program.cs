using HackerStories.BLL.IServices;
using HackerStories.BLL.Services;
using HackerStories.DAL;
using HackerStories.DAL.DataContext;
using HackerStories.DAL.Interface;
using HackerStories.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoryDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HackerStoryDB")));

//Repository
builder.Services.AddScoped<IStoryRepository, StoryRepository>();

//Services
builder.Services.AddScoped<IStoryService, StoryService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider=new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Resources/images")),
    RequestPath="/story-images"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
