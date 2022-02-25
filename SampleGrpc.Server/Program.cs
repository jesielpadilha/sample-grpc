using SampleGrpc.Server.Configuration;
using SampleGrpc.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpc();
builder.Services.AddJwtAuthentication(builder.Configuration);
//builder.Services.AddBearerAuthentication(builder.Configuration);


var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(x =>
{
    x.MapGrpcService<CityService>();
    x.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Server running...");
    });
});

app.Run();