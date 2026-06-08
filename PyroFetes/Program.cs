using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using PyroFetes;
using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using Microsoft.Net.Http.Headers;
using PyroFetes.MappingProfiles;
using PyroFetes.Repositories;
using PyroFetes.Services;
using PyroFetes.Services.Pdf;
using QuestPDF.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configurer la licence QuestPDF
QuestPDF.Settings.License = LicenseType.Community;

// On ajoute ici FastEndpoints, un framework REPR et Swagger aux services disponibles dans le projet
builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "v9!Qx7#Lk2@pZ8$wR6!tN5%uF3&cD9^mH1*eY4")
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument(options => { options.ShortSchemaNames = true; })
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policyBuilder =>
        {
            policyBuilder
                .WithOrigins("http://localhost:4200")
                .WithMethods("GET", "POST", "PUT", "DELETE", "PATCH")
                .AllowAnyHeader()
                .WithExposedHeaders(HeaderNames.ContentDisposition);
        });
    });

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
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<WarehouseProductsRepository>();
builder.Services.AddScoped<WareHouseRepository>();
builder.Services.AddScoped<CustomersRepository>();

// Ajout des services
builder.Services.AddScoped<IDeliveryNotePdfService, DeliveryNotePdfService>();
builder.Services.AddScoped<IPurchaseOrderPdfService, PurchaseOrderPdfService>();
builder.Services.AddScoped<IQuotationPdfService, QuotationPdfService>();
builder.Services.AddScoped<StorageService>();

MapperConfiguration mappingConfig = new(mc =>
{
    mc.AddCollectionMappers();
    mc.AddProfile(new DtoToEntityMappings());
    mc.AddProfile(new EntityToDtoMappings());
}, new LoggerFactory());


AutoMapper.IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// RUSTFS
IConfigurationSection config = builder.Configuration.GetSection("RustFS");

AmazonS3Client s3Client = new(
    config["AccessKey"],
    config["SecretKey"],
    new AmazonS3Config
    {
        ServiceURL = config["ServiceUrl"],
        ForcePathStyle = true
    }
);

ListBucketsResponse? buckets = await s3Client.ListBucketsAsync();
bool exist = buckets?.Buckets?.Any(x => x.BucketName == config["BucketName"]) == true;
if (!exist)
{
    await s3Client.PutBucketAsync(new PutBucketRequest
    {
        BucketName = config["BucketName"]
    });
}

builder.Services.AddSingleton<IAmazonS3>(s3Client);

// On construit l'application en lui donnant vie
WebApplication app = builder.Build();
app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(options =>
    {
        options.Endpoints.ShortNames = true;
        options.Endpoints.RoutePrefix = "API";
    })
    .UseSwaggerGen();

// app.UseHttpsRedirection();

app.UseCors();

app.Run();