using GestionResidencia.Components.Shared;
using GestionResidencia.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddSingleton<GestionResidencia.Services.SessionService>();
builder.Services.AddScoped<GestionResidencia.Services.AuthService>();

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run(); app.UseAntiforgery();