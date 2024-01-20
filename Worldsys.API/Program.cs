using Autofac;
using Worldsys.Infrastructure.Bootstrap;
using Worldsys.Application;

var builder = WebApplication.CreateBuilder(args);

var builderConfiguration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builderConfiguration.Build();


ApplicationStartup.Startup(configuration);


builder.Services.AddApplicationServices(true);
builder.Services.ConfigureServices();

var app = builder.Build();


ApplicationStartup.ConfigureApp(app);

app.Run();

