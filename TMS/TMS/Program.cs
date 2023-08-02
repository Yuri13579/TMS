using Data.Context;
using Data.Repo;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TMS.Service;
using TMS.Service.Impl;
using TMS.Service.Impl.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowCorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
string conn = Environment.GetEnvironmentVariable("sqlTaskConnectionString");
builder.Services.AddDbContext<TaskDbContext>(o => o.UseSqlServer(conn));

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

                // ignore omitted parameters on models to enable optional params (e.g. User update)
                x.JsonSerializerOptions.IgnoreNullValues = true;
            });
builder.Services.AddScoped<IServiceBusSender, ServiceBusSender>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowCorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
