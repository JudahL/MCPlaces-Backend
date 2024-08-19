using MCPlaces_Backend.Data;
using MCPlaces_Backend.Models;
using MCPlaces_Backend.Repository.GenericRepository;
using MCPlaces_Backend.Repository.ServerRepository.Interfaces;

namespace MCPlaces_Backend.Repository.ServerRepository
{
    public class ServerRepository : Repository<Server>, IServerRepository
    {
        private readonly ApplicationDbContext _context;
        public ServerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
