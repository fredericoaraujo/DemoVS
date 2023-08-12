using Serilog;
using System.Diagnostics;

namespace DemoVS.MeuMiddleware;

public class LogTempoMiddleware
{
    private readonly RequestDelegate _next;

    public LogTempoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // faz algo antes
        var sw = Stopwatch.StartNew();

        // faz a chamada
        await _next(context);

        // faz algo depois
        sw.Stop();
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        Log.Information($"A execução demorou {sw.Elapsed.TotalMilliseconds}ms ({sw.Elapsed.TotalSeconds}s)");
    }
}
