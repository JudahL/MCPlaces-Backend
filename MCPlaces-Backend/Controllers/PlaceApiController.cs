using MCPlaces_Backend.Models;
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
        public PlaceApiController(IPlaceRepository placeRepo, IPlaceMapper placeMapper)
        {
            _placeRepo = placeRepo;
            _placeMapper = placeMapper;
        }

        private readonly IPlaceRepository _placeRepo;
        private readonly IPlaceMapper _placeMapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetPlaceDto>>> GetPlaces()
        {
            try
            {
                IEnumerable<Place> places = await _placeRepo.GetAllAsync();
                IEnumerable<GetPlaceDto> placesList = places.Select(place => _placeMapper.PlaceToGetDto(place));
                return Ok(placesList.ToList());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}", Name = "GetPlace")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetPlaceDto>> GetPlace(int id)
        {
            try
            {
                var place = await _placeRepo.GetAsync(x => x.Id == id);

                if (place == null)
                {
                    return NotFound("Place could not be found.");
                }

                return Ok(_placeMapper.PlaceToGetDto(place));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetPlaceDto>> CreatePlace([FromBody] CreatePlaceDto createPlaceDto)
        {
            try
            {
                if (createPlaceDto == null)
                {
                    return BadRequest();
                }

                Place place = _placeMapper.CreateDtoToPlace(createPlaceDto);

                await _placeRepo.CreateAsync(place);

                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id: int}", Name = "UpdatePlace")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePlace(int id, [FromBody] UpdatePlaceDto updatePlaceDto) 
        {
            try 
            {
                if (updatePlaceDto == null) 
                {
                    return BadRequest("Update Place Dto not provided.");
                }

                if (id != updatePlaceDto.Id) 
                {
                    return BadRequest("The provided Id does not match the Dto Id.");
                }

                Place place = _placeMapper.UpdateDtoToPlace(updatePlaceDto);
                await _placeRepo.UpdateAsync(place);

                return NoContent();
            }
            catch 
            { 
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:int}", Name = "DeletePlace")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePlace(int id) 
        {
            try
            {
                Place place = await _placeRepo.GetAsync(x => x.Id == id);

                if (place == null)                 
                {
                    return NotFound();
                }

                await _placeRepo.RemoveAsync(place);

                return NoContent();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
