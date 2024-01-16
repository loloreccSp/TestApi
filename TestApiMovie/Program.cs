using Asp.Versioning;
using CorrelationId.DependencyInjection;
using CorrelationId;
using TestApiMovie.Middleware;
using TestApiMovie.Modules;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(x =>
{
    x.ApiVersionReader = new UrlSegmentApiVersionReader();
    x.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen();
builder.Services.AddCore(builder.Configuration);
builder.Services.AddHttpLogging(x => { });
builder.Services.AddLogging();
builder.Services.AddDefaultCorrelationId();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("v1/swagger.json", "Internet Shop API v1");
        x.OAuthAppName("Internet Shop API");
    });
}

app.UseCorrelationId();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
