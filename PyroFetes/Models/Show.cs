using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Show
{
    [Key] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required, MaxLength(120)] public string? Place { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    
    // Lien (chemin/URL/nom de fichier) vers le plan d’implémentation pyrotechnique
    [Required, MaxLength(500)]
    public string? PyrotechnicImplementationPlan { get; set; }

    public DateTime? Date { get; set; }
    public ICollection<Staff>? Staff { get; set; }
    public ICollection<Truck>? Trucks { get; set; }
    public ICollection<SoundTimecode>? SoundCues { get; set; }
}