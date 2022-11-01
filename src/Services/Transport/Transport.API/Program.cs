using Transport.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// General Configuration
builder.Services.AddScoped<ITransportRepository, TransportRepository>();

// Redis Configuration
string RedisConnectionString = builder.Configuration["RedisSettings:ConnectionString"];
RedisConnectionString = "transportdb:6379";
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = RedisConnectionString;
    options.InstanceName = "inventorydb";
});


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
