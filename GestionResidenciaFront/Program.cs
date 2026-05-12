using GestionResidenciaFront.Components.Shared;
using GestionResidenciaFront.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddSingleton<GestionResidenciaFront.Services.SessionService>();
builder.Services.AddScoped<GestionResidenciaFront.Services.AuthService>();

// En Program.cs del proyecto Front
builder.Services.AddScoped(sp => new HttpClient
{
    // Asegúrate de que este puerto sea el mismo donde corre tu API (míralo en el proyecto API)
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

app.Run(); app.UseAntiforgery();