using GestionResidenciaFront.Components.Shared;
using GestionResidenciaFront.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddSingleton<GestionResidenciaFront.Services.SessionService>();
builder.Services.AddScoped<GestionResidenciaFront.Services.AuthService>();

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