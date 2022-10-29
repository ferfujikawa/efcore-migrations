using efcore_migrations.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


var builder = new ConfigurationBuilder();
builder.LoadConfiguration();
var configuration = builder.Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

var host = Host.CreateDefaultBuilder();
host.InjectConnection(connectionString);

host.RunConsoleAsync();