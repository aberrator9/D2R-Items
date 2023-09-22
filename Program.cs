using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using D2RItems.Data;
using D2RItems.Models;
using System.Diagnostics;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<D2RItemsContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("D2RItemsContext") ?? throw new InvalidOperationException("Connection string 'D2RItemsContext' not found.")));

builder.Services.AddSingleton(builder.Environment);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    PopulateData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
