using Microsoft.EntityFrameworkCore;
using N5Test.Database;
using N5TLTest.Database.repositories;
using N5TLTest.Handlers;
using N5TLTest.Handlers.ports;
using N5TLTest.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<N5CompanyContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// external services
builder.Services.AddScoped<ISearchEngineService, ElasticSearchService>();
builder.Services.AddScoped<IEventBrokerService, KafkaProducerService>();
// own repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoty>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<PermissionTypeRepository>();
// own services
builder.Services.AddScoped<EmployeesCommandHandler>();
builder.Services.AddScoped<PermissionCommandHandler>();
builder.Services.AddScoped<PermissionTypeCommandHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
