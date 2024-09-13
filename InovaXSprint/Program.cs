using InovaXSprint.API.Configuration;
using InovaXSprint.API.Extensions;
using InovaXSprint.Database;
using InovaXSprint.Models;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger(apiConfiguration);
builder.Services.AddContext(apiConfiguration);
builder.Services.AddServices();

builder.Services.AddDbContext<FIAPDbContext>(options =>
{
    options.UseConfiguredOracle(apiConfiguration.OracleFIAP.ConnectionString);
});


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