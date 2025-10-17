using PyroFetes;
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// On ajoute ici FastEndpoints, un framework REPR et Swagger aux services disponibles dans le projet
builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "ThisIsASuperSecretJwtKeyThatIsAtLeast32CharsLong")
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

// On ajoute ici la configuration de la base de données
builder.Services.AddDbContext<PyroFetesDbContext>();

// On construit l'application en lui donnant vie
WebApplication app = builder.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();