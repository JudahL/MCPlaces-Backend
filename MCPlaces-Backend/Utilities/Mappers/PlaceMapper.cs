using MCPlaces_Backend.Models;
using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;
using MCPlaces_Backend.Utilities.Structs;

namespace MCPlaces_Backend.Utilities.Mappers
{
    public class PlaceMapper : IPlaceMapper
    {
        public GetPlaceDto PlaceToGetDto(Place place) 
        {
            return new GetPlaceDto(
                place.Id,
                place.ServerId,
                place.Name,
                place.Description,
                place.ImageName,
                new Coordinates(place.CoordsX, place.CoordsY, place.CoordsZ));
        }
        public CreatePlaceDto PlaceToCreateDto(Place place)
        {
            return new CreatePlaceDto(
                place.ServerId,
                place.Name,
                place.Description,
                place.ImageName,
                new Coordinates(place.CoordsX, place.CoordsY, place.CoordsZ));
        }

        public UpdatePlaceDto PlaceToUpdateDto(Place place)
        {
            return new UpdatePlaceDto(
                place.Id,
                place.ServerId,
                place.Name,
                place.Description,
                place.ImageName,
                new Coordinates(place.CoordsX, place.CoordsY, place.CoordsZ));
        }

        public Place GetDtoToPlace(GetPlaceDto getPlaceDto) 
        {
            Place place = new Place();
            place.Id = getPlaceDto.Id;
            place.ServerId = getPlaceDto.ServerId;
            place.Name = getPlaceDto.Name;
            place.Description = getPlaceDto.Description;
            place.ImageName = getPlaceDto.ImageName;
            place.CoordsX = getPlaceDto.Coordinates.X;
            place.CoordsY = getPlaceDto.Coordinates.Y;
            place.CoordsZ = getPlaceDto.Coordinates.Z;
            return place;
        }

        public Place CreateDtoToPlace(CreatePlaceDto createPlaceDto)
        {
            Place place = new Place();
            place.ServerId = createPlaceDto.ServerId;
            place.Name = createPlaceDto.Name;
            place.Description = createPlaceDto.Description;
            place.ImageName = createPlaceDto.ImageName;
            place.CoordsX = createPlaceDto.Coordinates.X;
            place.CoordsY = createPlaceDto.Coordinates.Y;
            place.CoordsZ = createPlaceDto.Coordinates.Z;
            return place;
        }

        public Place UpdateDtoToPlace(UpdatePlaceDto updatePlaceDto)
        {
            Place place = new Place();
            place.Id = updatePlaceDto.Id;
            place.ServerId = updatePlaceDto.ServerId;
            place.Name = updatePlaceDto.Name;
            place.Description = updatePlaceDto.Description;
            place.ImageName = updatePlaceDto.ImageName;
            place.CoordsX = updatePlaceDto.Coordinates.X;
            place.CoordsY = updatePlaceDto.Coordinates.Y;
            place.CoordsZ = updatePlaceDto.Coordinates.Z;
            return place;
        }
    }
}
