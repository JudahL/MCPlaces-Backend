namespace MCPlaces_Backend.Models.Dtos
{
    public class GetServerDto
    {
        public GetServerDto(int id, string name, string description, string patch, string seed)
        {
            Id = id;
            Name = name;
            Description = description;
            Patch = patch;
            Seed = seed;
        }
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Patch { get; set; } = String.Empty;
        public string Seed { get; set; } = String.Empty;
    }
}
