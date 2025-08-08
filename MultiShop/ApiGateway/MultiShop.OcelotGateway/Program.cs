using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddJwtBearer("OcelotAuthenticationScheme", options =>
    {
        options.Authority = "http://localhost:5001"; // IdentityServer URL
        options.Audience = "ResourceOcelot"; // API resource name
        options.RequireHttpsMetadata = false; // For development purposes, set to true in production
    });


IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();


builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();
app.MapGet("/", () => "Hello World!");

app.Run();
