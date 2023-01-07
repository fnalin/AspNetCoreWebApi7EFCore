namespace Fansoft.Catalog.API.Models;

public class CatalogItemVM {
     public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
