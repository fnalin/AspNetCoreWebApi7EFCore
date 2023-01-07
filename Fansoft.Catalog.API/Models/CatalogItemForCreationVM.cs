using System.ComponentModel.DataAnnotations;

namespace Fansoft.Catalog.API.Models;

public class CatalogItemForCreationVM {
    [Required]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
