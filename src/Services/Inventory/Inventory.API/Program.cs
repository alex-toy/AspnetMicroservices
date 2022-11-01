using Inventory.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// General Configuration
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

// Redis Configuration
string RedisConnectionString = builder.Configuration["RedisSettings:ConnectionString"];
RedisConnectionString = "inventorydb:6379";
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
