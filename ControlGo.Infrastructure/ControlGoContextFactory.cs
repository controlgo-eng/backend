using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ControlGo.Infrastructure
{
    public class ControlGoContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        /// <summary>
        /// Genera la configuración necesaria para obtener los parámetros de configuración del proyecto principal.
        /// </summary>
        /// <returns></returns>
        private static IConfigurationRoot BuildConfiguration()
        {
            // Buscar appsettings.json en la carpeta de ControlGo.API si existe
            var currentDir = Directory.GetCurrentDirectory();
            var apiDir = Path.Combine(currentDir, "..", "ControlGo.API");
            string configPath;
            if (File.Exists(Path.Combine(apiDir, "appsettings.json")))
            {
                configPath = Path.GetFullPath(apiDir);
            }
            else
            {
                configPath = currentDir;
            }
            var builder = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile("appsettings.json", optional: true);
            return builder.Build();
        }
            
        /// <summary>
        /// Crea el contexto de datos.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
