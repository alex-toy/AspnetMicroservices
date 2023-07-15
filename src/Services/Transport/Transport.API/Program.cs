using Transport.API.GrpcServices;
using Transport.API.Repositories;
using Vehicles.Grpc.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// General Configuration
builder.Services.AddScoped<ITransportRepository, TransportRepository>();

// Grpc Configuration
string GrpcSettingsConnectionString = builder.Configuration["GrpcSettings:SlotUrl"];
builder.Services.AddGrpcClient<VehicleProtoService.VehicleProtoServiceClient>(o => o.Address = new Uri(GrpcSettingsConnectionString));
builder.Services.AddScoped<VehicleGrpcService>();

// Redis Configuration
string RedisConnectionString = builder.Configuration["RedisSettings:ConnectionString"];
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = RedisConnectionString;
    options.InstanceName = "transportdb";
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
