using System.ComponentModel.DataAnnotations;

namespace PyroFetes.Models;

public class Product
{
    [Key] public int Id { get; set; }
}