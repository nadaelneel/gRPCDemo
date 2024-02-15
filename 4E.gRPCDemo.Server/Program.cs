using _4E.gRPCDemo.Server.Services;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication()
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthen", op => { });
builder.Services.AddGrpc();

builder.Services.AddGrpcReflection();
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
app.MapGrpcService<TelemetryTrackingService>();
if(app.Environment.IsDevelopment()) // to development only 
{
    app.MapGrpcReflectionService();
}
app.MapControllers();

app.Run();
