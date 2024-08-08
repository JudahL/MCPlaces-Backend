using MCPlaces_Backend.Data;
using MCPlaces_Backend.Models;
using MCPlaces_Backend.Repository.GenericRepository;
using MCPlaces_Backend.Repository.PlaceRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MCPlaces_Backend.Repository.PlaceRepository
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        private readonly ApplicationDbContext _context;
        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }        
    }
}
