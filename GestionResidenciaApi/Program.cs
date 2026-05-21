var builder = WebApplication.CreateBuilder(args);

// Servicios — AuthService solo una vez
IServiceCollection serviceCollection = builder.Services.AddSingleton<GestionResidenciaFront.Services.SessionService>();
builder.Services.AddScoped<GestionResidenciaFront.Services.AuthService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001")
});

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();