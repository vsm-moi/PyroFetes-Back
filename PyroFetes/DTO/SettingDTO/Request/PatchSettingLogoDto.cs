namespace PyroFetes.DTO.SettingDTO.Request;

public class PatchSettingLogoDto
{
    public int Id { get; set; }
    public IFormFile? Logo { get; set; }
}