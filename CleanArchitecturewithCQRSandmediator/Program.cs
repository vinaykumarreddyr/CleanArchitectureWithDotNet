using Mediator.Infrastructure;
using Mediator.Application;
using Microsoft.EntityFrameworkCore;
using Mediator.Application.Common.Mappings;
using Serilog;
using Mediator.Domain.Repository;
using Mediator.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers with JSON options
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Configure logging with Serilog (uncomment if using Serilog)
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Alternatively, use default logging (comment out Serilog if not needed)
// builder.Logging.AddConsole();
// builder.Logging.AddDebug();
// builder.Logging.SetMinimumLevel(LogLevel.Information);
// builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
// builder.Logging.AddFilter("Microsoft.NetCore", LogLevel.Warning);
// builder.Logging.AddFilter("System", LogLevel.Warning);
// builder.Logging.AddFilter("DefaultLogging", LogLevel.Trace);

// Add application services (includes MediatR)
builder.Services.AddApplicationServices(builder.Configuration);

// Add API exploration and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add repository
builder.Services.AddScoped<IBlogAuthorRepository, BlogAuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseAuthentication(); // Uncomment if authentication is needed
app.UseAuthorization();
app.MapControllers();

app.Run();