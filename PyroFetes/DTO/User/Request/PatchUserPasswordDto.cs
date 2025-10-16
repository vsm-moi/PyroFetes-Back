namespace PyroFetes.DTO.User.Request;

public class PatchUserPasswordDto
{
    public int Id { get; set; }
    public string? Password { get; set; }
}