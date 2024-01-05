using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using D2RItems.Data;
using D2RItems.Models;
using System.Diagnostics;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

var connection = builder.Configuration.GetConnectionString("D2RItemsContext");
builder.Services.AddDbContext<D2RItemsContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddSingleton(builder.Environment);

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    PopulateData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
	app.UseExceptionHandler("/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
