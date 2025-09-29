using Microsoft.OpenApi.Models;
using MtxApp.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("mediamtx",
    client =>
    {
        client.BaseAddress = new Uri("http://localhost:9997");
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "MediaMTX Proxy API",
            Version = "v1",
            Description = "Minimal API proxy do MediaMTX",
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediaMTX Proxy API v1");
        c.RoutePrefix = "swagger"; // available at /swagger
    });
}

app.UseHttpsRedirection();

app.MapMediaMtxEndpoints();

app.Run();
