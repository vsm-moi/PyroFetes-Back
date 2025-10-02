using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Show
{
    [Key] public int Id { get; set; }

    [Required, MaxLength(120)]
    public string? Place { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    // Lien (chemin/URL/nom de fichier) vers le plan d’implémentation pyrotechnique
    [Required, MaxLength(500)]
    public string? PyrotechnicImplementationPlan { get; set; }

    public DateTime? Date { get; set; }

    public ICollection<Staff> Staff { get; set; } = new List<Staff>();
    public ICollection<Truck> Trucks { get; set; } = new List<Truck>();
    public ICollection<SoundTimecode> SoundCues { get; set; } = new List<SoundTimecode>();
}