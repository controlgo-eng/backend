using Worldsys.Infrastructure.Bootstrap;
using Worldsys.Application;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment;

var builderConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
var configuration = builderConfiguration.Build();


ApplicationStartup.Startup(configuration);


builder.Services.AddApplicationServices(configuration);
builder.Services.ConfigureServices();

var app = builder.Build();


ApplicationStartup.ConfigureApp(app);

app.Run();

