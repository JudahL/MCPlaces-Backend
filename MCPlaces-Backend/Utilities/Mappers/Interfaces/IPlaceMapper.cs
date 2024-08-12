using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Models;

namespace MCPlaces_Backend.Utilities.Mappers.Interfaces
{
    public interface IPlaceMapper
    {
        GetPlaceDto PlaceToGetDto(Place place);
        CreatePlaceDto PlaceToCreateDto(Place place);

        UpdatePlaceDto PlaceToUpdateDto(Place place);

        Place GetDtoToPlace(GetPlaceDto getPlaceDto);

        Place CreateDtoToPlace(CreatePlaceDto createPlaceDto);

        Place UpdateDtoToPlace(UpdatePlaceDto updatePlaceDto);
    }
}
