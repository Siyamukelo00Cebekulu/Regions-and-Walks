namespace NzWalksApi.Models.DTO
{
    public class WalksDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
    
        public RegionDto RegionDto { get; set; }

        public DifficultyDto DifficultyDto { get; set; }
    }
}