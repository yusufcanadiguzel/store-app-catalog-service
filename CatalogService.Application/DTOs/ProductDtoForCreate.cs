namespace CatalogService.Application.DTOs
{
    public record ProductDtoForCreate
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int UnitsInStock { get; init; }
        public bool IsActive { get; init; }
    }
}
