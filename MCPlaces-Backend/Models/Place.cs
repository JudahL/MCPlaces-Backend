
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCPlaces_Backend.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Server")]
        //public int ServerId { get; set; }
        //public MCServer Server { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageName { get; set; } = String.Empty;
        public int CoordsX { get; set; }
        public int CoordsY { get; set; }
        public int CoordsZ { get; set; }
    }
}
