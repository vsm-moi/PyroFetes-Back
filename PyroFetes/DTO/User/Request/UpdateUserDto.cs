namespace PyroFetes.DTO.User.Request;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Fonction { get; set; }
    public string? Email { get; set; }
}