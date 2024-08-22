using MCPlaces_Backend.Utilities.Structs;
using System.ComponentModel.DataAnnotations;

namespace MCPlaces_Backend.Models.Dtos
{
    public class UpdatePlaceDto
    {
        public UpdatePlaceDto(int id, int serverId, string name, string desc, string imgName, Coordinates coords)
        {
            Id = id;
            ServerId = serverId;
            Name = name;
            Description = desc;
            ImageName = imgName;
            Coordinates = coords;
        }
        public int Id { get; set; }
        [Required]
        public int ServerId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageName { get; set; } = String.Empty;
        public Coordinates Coordinates { get; set; }
    }
}
