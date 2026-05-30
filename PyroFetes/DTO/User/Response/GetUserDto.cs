namespace PyroFetes.DTO.User.Response;

public class GetUserDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Fonction { get; set; }
    public string? Email { get; set; }
}