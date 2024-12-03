using Kursinis.IRepositories;
using Kursinis.IServices;
using Kursinis.Repositories;
using Kursinis.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Konfig?ruoti Serilog
Log.Logger = new LoggerConfiguration() 
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext() .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IKnygosRepository, KnygosRepository>();
builder.Services.AddScoped<INaudotojaiRepository, NaudotojaiRepository>();
builder.Services.AddScoped<INuomaRepository, NuomosRepository>();

builder.Services.AddScoped<IKnygosService, KnygosService>();
builder.Services.AddScoped<INaudotojaiService, NaudotojaiService>();
builder.Services.AddScoped<INuomaService, NuomaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
