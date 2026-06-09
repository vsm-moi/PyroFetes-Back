using Amazon.S3;
using Amazon.S3.Model;

namespace PyroFetes.Services;

public class StorageService(IAmazonS3 amazonS3, IConfiguration config)
{
    private readonly string _bucket = config["RustFs:BucketName"]!;
    private readonly string _url = config["RustFs:ServiceUrl"]!;
    
    public async Task<string> UploadFile(IFormFile file, string type, CancellationToken ct)
    {
        if (file.Length == 0) throw new Exception("Fichier vide");
        
        string key = $"settings/{type}/{Guid.NewGuid()}";

        using MemoryStream memoryStream = new();
        await file.CopyToAsync(memoryStream, ct);
        memoryStream.Position = 0;

        PutObjectRequest uploadRequest = new()
        {
            BucketName = _bucket,
            ContentType = file.ContentType,
            InputStream = memoryStream,
            Key = key,
        };
        
        await amazonS3.PutObjectAsync(uploadRequest, ct);
        return key;
    }

    public string? GetUrl(string key)
    {
        return string.IsNullOrEmpty(key) ? null : $"{_url}/{_bucket}/{key}";
    }
}