namespace DemoVS.MeuMiddleware;

public class TemplateMiddleware
{
    private readonly RequestDelegate _next;

    public TemplateMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // faz algo antes

        // faz a chamada
        await _next(context);

        // faz algo depois
    }
}
