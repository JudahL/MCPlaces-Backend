using MCPlaces_Backend.Models;
using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;

namespace MCPlaces_Backend.Utilities.Mappers
{
    public class ServerMapper : IServerMapper
    {
        public GetServerDto ServerToGetDto(Server server) 
        {
            return new GetServerDto(
                server.Id,
                server.Name,
                server.Description,
                server.Patch,
                server.Seed);
        }
        public CreateServerDto ServerToCreateDto(Server server)
        {
            return new CreateServerDto(
                server.Name,
                server.Description,
                server.Patch,
                server.Seed);
        }

        public UpdateServerDto ServerToUpdateDto(Server server)
        {
            return new UpdateServerDto(
                server.Id,
                server.Name,
                server.Description,
                server.Patch,
                server.Seed);
        }

        public Server GetDtoToServer(GetServerDto getServerDto) 
        {
            Server server = new Server();
            server.Id = getServerDto.Id;
            server.Name = getServerDto.Name;
            server.Description = getServerDto.Description;
            server.Patch = getServerDto.Patch;
            server.Seed = getServerDto.Seed;
            return server;
        }

        public Server CreateDtoToServer(CreateServerDto createServerDto)
        {
            Server server = new Server();
            server.Name = createServerDto.Name;
            server.Description = createServerDto.Description;
            server.Patch = createServerDto.Patch;
            server.Seed = createServerDto.Seed;
            return server;
        }

        public Server UpdateDtoToServer(UpdateServerDto updateServerDto)
        {
            Server server = new Server();
            server.Id = updateServerDto.Id;
            server.Name = updateServerDto.Name;
            server.Description = updateServerDto.Description;
            server.Patch = updateServerDto.Patch;
            server.Seed = updateServerDto.Seed;
            return server;
        }
    }
}
