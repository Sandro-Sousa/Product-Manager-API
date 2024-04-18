using Microsoft.Extensions.Configuration;

namespace Cross
{
    public class AppSettings
    {
        public string? _appSettingValue { get; set; }

        public AppSettings(IConfiguration config, string Key)
        {
            this._appSettingValue = config.GetValue<string>(Key);
        }
        public static string? GetConnectionString(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString(key);
        }


        public static string GetAppSettingsDevelopmentFilePath()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            // Obtém o diretório do projeto
            string basePath = Directory.GetCurrentDirectory();

            // Configuração do ConfigurationBuilder para carregar o appsettings.Development.json
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            // Obter o caminho completo do appsettings.Development.json
            string appSettingsDevelopmentFilePath = Path.Combine(basePath, $"appsettings.{environmentName}.json");

            return appSettingsDevelopmentFilePath;
        }
    }
}
