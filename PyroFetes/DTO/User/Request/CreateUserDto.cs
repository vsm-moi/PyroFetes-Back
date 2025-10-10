namespace PyroFetes.DTO.User.Request;

public class CreateUserDto
{
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Salt { get; set; }
    public string? Fonction { get; set; }
    public string? Email { get; set; }
}