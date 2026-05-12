using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using GestionResidenciaApi.Data;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

//using GestionResidenciaApi.Services.ApartamentosService;

var builder = WebApplication.CreateBuilder(args);

// configurar servicios
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



// register services implementations
builder.Services.AddScoped<IApartamentos, ApartamentosService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IAuditoriaLogin, AuditoriaLoginService>();
builder.Services.AddScoped<IBitacoraVigilancia, BitacoraVigilanciaService>();
builder.Services.AddScoped<IConjunto, ConjuntoService>();
builder.Services.AddScoped<ICuotaAdministracion, CuotaAdministracionService>();
//builder.Services.AddScoped<IEmpleEstadoCuotaado, EmpleEstadoCuotaadoService>();
builder.Services.AddScoped<IEstado, EstadoService>();
builder.Services.AddScoped<IIngreso, IngresoService>();
builder.Services.AddScoped<IMantenimiento, MantenimientoService>();
builder.Services.AddScoped<IMensajeria, MensajeriaService>();
builder.Services.AddScoped<IMetodoPago, MetodoPagoService>();
builder.Services.AddScoped<IPago, PagoService>();
builder.Services.AddScoped<IPagoDetalle, PagoDetalleService>();
builder.Services.AddScoped<IParqueadero, ParqueaderoService>();
builder.Services.AddScoped<IParqueaderoVisitante, ParqueaderoVisitanteService>();
builder.Services.AddScoped<IPermiso, PermisoService>();
builder.Services.AddScoped<IPersona, PersonaService>();
builder.Services.AddScoped<IReserva, ReservaService>();
builder.Services.AddScoped<IResidenteUnidad, ResidenteUnidadService>();
builder.Services.AddScoped<IRol, RolService>();
builder.Services.AddScoped<IRolPermiso, RolPermisoService>();
builder.Services.AddScoped<ITipoEvento, TipoEventoService>();
builder.Services.AddScoped<ITipoIngreso, TipoIngresoService>();
builder.Services.AddScoped<ITipoMantenimiento, TipoMantenimientoService>();
builder.Services.AddScoped<ITipoParqueadero, TipoParqueaderoService>();
builder.Services.AddScoped<ITorre, TorreService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<IVisitante, VisitanteService>();
builder.Services.AddScoped<IZonaComun, ZonaComunService>();

//for authentication
var _key = builder.Configuration["Jwt:Key"];
var _issuer = builder.Configuration["Jwt:Issuer"];
var _audience = builder.Configuration["Jwt:Audience"];
var _expireMinutes =builder.Configuration["Jwt:ExpireMinutes"];

//configurar servicios

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//configurar jwt
var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"])
        )
    };
});

builder.Services.AddAuthorization();

//configurar swagger para aut de jwt
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GestionResidenciaApi", Version = "v1" });
//config de seguridad para jwt en swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
    In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Ingrese 'Bearer' seguido de un espacio y luego su token JWT en el campo de texto. Ejemplo: 'Bearer {token}'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.

// 1. Manejo de excepciones primero
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 2. Routing DEBE ir antes de Auth
app.UseRouting();

// 3. Cors DEBE ir después de Routing pero antes de Auth
app.UseCors("CorsPolicy");

// 4. Autenticación y Autorización SIEMPRE en este orden
app.UseAuthentication();
app.UseAuthorization();

// 5. Finalmente mapear los controladores
app.MapControllers();

app.Run();

//app.UseDeveloperExceptionPage();
//app.UseSwagger();
//app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseCors("CorsPolicy");
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
