using MCPlaces_Backend.Models.ApiResponse.Interfaces;
using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Models;
using MCPlaces_Backend.Utilities.ActionFilters.Interfaces;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MCPlaces_Backend.Repository.ServerRepository.Interfaces;

namespace MCPlaces_Backend.Controllers
{
    [Route("api/Server")]
    [ApiController]
    public class ServerApiController : ControllerBase
    {
        public ServerApiController(IServerRepository serverRepo, IServerMapper serverMapper, IApiResponse apiResponse)
        {
            _serverRepo = serverRepo;
            _serverMapper = serverMapper;
            _apiResponse = apiResponse;
        }

        private readonly IServerRepository _serverRepo;
        private readonly IServerMapper _serverMapper;
        private readonly IApiResponse _apiResponse;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> GetServers()
        {
            try
            {
                IEnumerable<Server> servers = await _serverRepo.GetAllAsync();
                IEnumerable<GetServerDto> serversList = servers.Select(server => _serverMapper.ServerToGetDto(server));
                _apiResponse.Success(serversList.ToList());
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpGet("{id:int}", Name = "GetServer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> GetServer(int id)
        {
            try
            {
                var server = await _serverRepo.GetAsync(x => x.Id == id);

                if (server == null)
                {
                    _apiResponse.Failure("Server could not be found.");
                    return NotFound(_apiResponse);
                }

                _apiResponse.Success(_serverMapper.ServerToGetDto(server));
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(IModelValidationActionFilter))]
        public async Task<ActionResult<IApiResponse>> CreateServer([FromBody] CreateServerDto createServerDto)
        {
            try
            {
                Server server = _serverMapper.CreateDtoToServer(createServerDto);

                await _serverRepo.CreateAsync(server);

                _apiResponse.Success(_serverMapper.ServerToGetDto(server));
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpPut("{id:int}", Name = "UpdateServer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ServiceFilter(typeof(IModelValidationActionFilter))]
        public async Task<ActionResult<IApiResponse>> UpdateServer(int id, [FromBody] UpdateServerDto updateServerDto)
        {
            try
            {
                if (id != updateServerDto.Id)
                {
                    _apiResponse.Failure("The provided Server Id does not match the Dto Id.");
                    return BadRequest(_apiResponse);
                }

                Server server = _serverMapper.UpdateDtoToServer(updateServerDto);
                await _serverRepo.UpdateAsync(server);

                _apiResponse.Success();
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteServer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> DeleteServer(int id)
        {
            try
            {
                Server server = await _serverRepo.GetAsync(x => x.Id == id);

                if (server == null)
                {
                    _apiResponse.Failure("No server with given Id was found.");
                    return NotFound(_apiResponse);
                }

                await _serverRepo.RemoveAsync(server);

                _apiResponse.Success();
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }
    }
}
