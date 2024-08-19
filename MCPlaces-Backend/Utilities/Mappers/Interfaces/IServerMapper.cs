using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Models;

namespace MCPlaces_Backend.Utilities.Mappers.Interfaces
{
    public interface IServerMapper
    {
        GetServerDto ServerToGetDto(Server server);
        CreateServerDto ServerToCreateDto(Server server);

        UpdateServerDto ServerToUpdateDto(Server server);

        Server GetDtoToServer(GetServerDto getServerDto);

        Server CreateDtoToServer(CreateServerDto createServerDto);

        Server UpdateDtoToServer(UpdateServerDto updateServerDto);
    }
}
