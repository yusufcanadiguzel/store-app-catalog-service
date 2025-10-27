namespace CatalogService.Application.DTOs
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int UnitsInStock { get; init; }
        public bool IsActive { get; init; }
    }
}
