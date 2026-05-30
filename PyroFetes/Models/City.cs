using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class City
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required] public int ZipCode { get; set; }

    public List<Show>? Shows { get; set; }
}