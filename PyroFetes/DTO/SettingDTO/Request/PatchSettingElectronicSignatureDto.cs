namespace PyroFetes.DTO.SettingDTO.Request;

public class PatchSettingElectronicSignatureDto
{
    public int Id { get; set; }
    public IFormFile? ElectronicSignature { get; set; }
}