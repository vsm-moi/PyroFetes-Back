using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Show
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(100)] public string? Name { get; set; }
    [Required, MaxLength(120)] public string? Place { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    public DateOnly? Date { get; set; }
    
    // Link (path/URL/file name) to the pyrotechnic implementation plan
    [Required, MaxLength(500)] public string? PyrotechnicImplementationPlan { get; set; }
    
    [Required] public int CityId { get; set; }
    public City? City { get; set; }
    
    public List<ShowStaff>? ShowStaffs { get; set; }
    public List<ShowTruck>? ShowTrucks { get; set; }
    public List<SoundTimecode>? SoundTimecodes { get; set; }
}