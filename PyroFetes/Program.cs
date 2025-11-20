using AutoMapper;
using AutoMapper.EquivalencyExpression;
using PyroFetes;
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using PyroFetes.MappingProfiles;
using PyroFetes.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// On ajoute ici FastEndpoints, un framework REPR et Swagger aux services disponibles dans le projet
builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "ThisIsASuperSecretJwtKeyThatIsAtLeast32CharsLong")
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

// On ajoute ici la configuration de la base de données
builder.Services.AddDbContext<PyroFetesDbContext>();

builder.Services.AddScoped<DeliverersRepository>();
builder.Services.AddScoped<DeliveryNotesRepository>();
builder.Services.AddScoped<PricesRepository>();
builder.Services.AddScoped<ProductDeliveriesRepository>();
builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<PurchaseOrdersRepository>();
builder.Services.AddScoped<PurchaseProductsRepository>();
builder.Services.AddScoped<QuotationProductsRepository>();
builder.Services.AddScoped<QuotationsRepository>();
builder.Services.AddScoped<SuppliersRepository>();
builder.Services.AddScoped<SettingsRepository>();

MapperConfiguration mappingConfig = new(mc =>
{
    mc.AddCollectionMappers();
    mc.AddProfile(new DtoToEntityMappings());
    mc.AddProfile(new EntityToDtoMappings());
}, new LoggerFactory());


AutoMapper.IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// On construit l'application en lui donnant vie
WebApplication app = builder.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();