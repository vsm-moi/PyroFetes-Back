namespace PyroFetes.DTO.SettingDTO.Request;

public class CreateSettingDto
{
    public IFormFile? ElectronicSignature { get; set; }
    public IFormFile? Logo { get; set; }
}