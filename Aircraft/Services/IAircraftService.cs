using Beslogic.Pratice.API.Models;

namespace Beslogic.Pratice.API.Services
{
    public interface IAircraftService
    {
        Task<IEnumerable<Aircraft>> GetAll();
        Task<Aircraft> GetById(int id);
        Task<Aircraft> Add(Aircraft aircraft);
        Task<Aircraft> Update(int id, Aircraft aircraft);
        Task Delete(int id);
    }
}
