using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Setting
{
    [Key] public int Id { get; set; }
    [Required] public string? Logo { get; set; }
    [Required] public string? ElectronicSignature { get; set; }
}