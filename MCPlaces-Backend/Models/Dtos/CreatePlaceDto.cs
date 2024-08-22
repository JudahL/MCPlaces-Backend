using MCPlaces_Backend.Utilities.Structs;
using System.ComponentModel.DataAnnotations;

namespace MCPlaces_Backend.Models.Dtos
{
    public class CreatePlaceDto
    {
        public CreatePlaceDto(int serverId, string name, string desc, string imgName, Coordinates coords)
        {
            ServerId = serverId;
            Name = name;
            Description = desc;
            ImageName = imgName;
            Coordinates = coords;
        }
        [Required]
        public int ServerId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageName { get; set; } = String.Empty;
        public Coordinates Coordinates { get; set; }
    }
}
