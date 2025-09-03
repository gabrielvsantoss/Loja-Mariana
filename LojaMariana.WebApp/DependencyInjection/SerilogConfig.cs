using Serilog.Events;
using Serilog;
namespace LojaMariana.WebApp.DependencyInjection;

public static class SerilogConfig
{

    public static void AddSerilogConfig(this IServiceCollection services, ILoggingBuilder logging)
    {
        var caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        var caminhoArquivosLogs = Path.Combine(caminhoAppData, "Duobingo", "Erro.Log");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(caminhoArquivosLogs, LogEventLevel.Error)
            .CreateLogger();

        logging.ClearProviders();
        services.AddSerilog();

    }
}
