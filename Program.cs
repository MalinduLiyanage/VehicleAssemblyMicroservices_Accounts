using AccountsService.Attributes;
using AccountsService;
using Microsoft.EntityFrameworkCore;
using AccountsService.Services.VehicleService;
using AccountsService.Services.WorkerService;
using AccountsService.Services.InternalAccountsService;
using AccountsService.Services.ValidationService;

var builder = WebApplication.CreateBuilder(args);

var server = Environment.GetEnvironmentVariable("DB_SERVER");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("DB_USER");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
//var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};";
var connectionString = $"Server=localhost;Port=3306;Database=vehicleaccountsdb;User=root;Password=;";

GlobalAttributes.mySQLConfig.connectionString = connectionString;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IInternalAccountsService, InternalAccountsService>();
builder.Services.AddScoped<ICreateWorkerValidationService, CreateWorkerValidationService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
