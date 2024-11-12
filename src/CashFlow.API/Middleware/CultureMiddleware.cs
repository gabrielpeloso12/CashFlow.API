using System.Globalization;

namespace CashFlow.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var suportedLanguage = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();
        var cultureinfo = new CultureInfo("pt-BR");

        if(string.IsNullOrWhiteSpace(requestCulture) == false &&
           suportedLanguage.Exists(language => language.Name.Equals(requestCulture)))
        {
            cultureinfo = new CultureInfo(requestCulture);
        }

        CultureInfo.CurrentCulture = cultureinfo;
        CultureInfo.CurrentUICulture = cultureinfo;
        await _next(context);
    }
}
