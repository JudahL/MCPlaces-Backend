using MCPlaces_Backend.Models;
using MCPlaces_Backend.Models.ApiResponse.Interfaces;
using MCPlaces_Backend.Models.Dtos;
using MCPlaces_Backend.Repository.PlaceRepository.Interfaces;
using MCPlaces_Backend.Utilities.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MCPlaces_Backend.Controllers
{
    [Route("api/Place")]
    [ApiController]
    public class PlaceApiController : ControllerBase
    {
        public PlaceApiController(IPlaceRepository placeRepo, IPlaceMapper placeMapper, IApiResponse apiResponse)
        {
            _placeRepo = placeRepo;
            _placeMapper = placeMapper;
            _apiResponse = apiResponse; 
        }

        private readonly IPlaceRepository _placeRepo;
        private readonly IPlaceMapper _placeMapper;
        private readonly IApiResponse _apiResponse;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> GetPlaces()
        {
            try
            {
                IEnumerable<Place> places = await _placeRepo.GetAllAsync();
                IEnumerable<GetPlaceDto> placesList = places.Select(place => _placeMapper.PlaceToGetDto(place));
                _apiResponse.Success(placesList.ToList());
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpGet("{id:int}", Name = "GetPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> GetPlace(int id)
        {
            try
            {
                var place = await _placeRepo.GetAsync(x => x.Id == id);

                if (place == null)
                {                    
                    _apiResponse.Failure("Place could not be found.");
                    return NotFound(_apiResponse);
                }

                _apiResponse.Success(_placeMapper.PlaceToGetDto(place));
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
        public async Task<ActionResult<IApiResponse>> CreatePlace([FromBody] CreatePlaceDto createPlaceDto)
        {
            try
            {
                if (createPlaceDto == null)
                {
                    _apiResponse.Failure("Create Place Dto was not provided.");
                    return BadRequest(_apiResponse);
                }

                Place place = _placeMapper.CreateDtoToPlace(createPlaceDto);

                await _placeRepo.CreateAsync(place);

                _apiResponse.Success(_placeMapper.PlaceToGetDto(place));
                return Ok(_apiResponse);
            }
            catch
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpPut("{id:int}", Name = "UpdatePlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> UpdatePlace(int id, [FromBody] UpdatePlaceDto updatePlaceDto) 
        {
            try 
            {
                if (updatePlaceDto == null) 
                {
                    _apiResponse.Failure("Update Place Dto not provided.");
                    return BadRequest(_apiResponse);
                }

                if (id != updatePlaceDto.Id) 
                {
                    _apiResponse.Failure("The provided Id does not match the Dto Id.");
                    return BadRequest(_apiResponse);
                }

                Place place = _placeMapper.UpdateDtoToPlace(updatePlaceDto);
                await _placeRepo.UpdateAsync(place);

                _apiResponse.Success();
                return Ok(_apiResponse);
            }
            catch 
            {
                _apiResponse.Failure();
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IApiResponse>> DeletePlace(int id) 
        {
            try
            {
                Place place = await _placeRepo.GetAsync(x => x.Id == id);

                if (place == null)                 
                {
                    _apiResponse.Failure("No place with given Id was found.");
                    return NotFound(_apiResponse);
                }

                await _placeRepo.RemoveAsync(place);

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
