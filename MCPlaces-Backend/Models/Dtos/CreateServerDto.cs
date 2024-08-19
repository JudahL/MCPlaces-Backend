using System.ComponentModel.DataAnnotations;

namespace MCPlaces_Backend.Models.Dtos
{
    public class CreateServerDto
    {
        public CreateServerDto(string name, string description, string patch, string seed)
        {            
            Name = name;
            Description = description;
            Patch = patch;
            Seed = seed;
        }
        [Required]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Patch { get; set; } = String.Empty;
        public string Seed { get; set; } = String.Empty;
    }
}
