using MCPlaces_Backend.Utilities.Structs;

namespace MCPlaces_Backend.Models.Dtos
{
    public class CreatePlaceDto
    {
        public CreatePlaceDto(string name, string desc, string imgName, Coordinates coords)
        {
            Name = name;
            Description = desc;
            ImageName = imgName;
            Coordinates = coords;
        }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageName { get; set; } = String.Empty;
        public Coordinates Coordinates { get; set; }
    }
}
