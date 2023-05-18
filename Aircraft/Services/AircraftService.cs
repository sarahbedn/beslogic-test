using Beslogic.Pratice.API.Context;
using Beslogic.Pratice.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beslogic.Pratice.API.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly PraticeDatabaseContext _praticeDatabase;
        private object _aircraftService;

        public AircraftService(PraticeDatabaseContext praticeDatabase)
        {
            _praticeDatabase = praticeDatabase;
        }

        public async Task<IEnumerable<Aircraft>> GetAll()
        {
            return await _praticeDatabase.Aircrafts.ToListAsync();
        }

        public Aircraft GetById(int id)
        {
            var items = _praticeDatabase.Aircrafts.SingleOrDefault(x => x.Id == id);

            if (items == null)
            {
                throw new Exception($"Could not find any aicraft with an id of {id}");
            }

            return items;
        }

        public async Task<Aircraft> Add(Aircraft aircraft)
        {
            try
            {
                aircraft.RegistrationDate = DateTime.Now;
                var newAircraft = _praticeDatabase.Aircrafts.Add(aircraft);
                await _praticeDatabase.SaveChangesAsync();
                return newAircraft.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aircraft> Update(int id, Aircraft aircraft)
        {
            var dbAircraft = _praticeDatabase.Aircrafts.SingleOrDefault(x => x.Id == id);
            if (dbAircraft == null)
            {
                throw new Exception($"Could not find aircraft to update with id {id}");
            }

            _praticeDatabase.Entry(aircraft).State = EntityState.Modified;
            await _praticeDatabase.SaveChangesAsync();

            return aircraft;
        }
        public async Task Delete(int id)
        {
            var dbAircraft = _praticeDatabase.Aircrafts.SingleOrDefault(x => x.Id == id);
            if (dbAircraft == null)
            {
                throw new Exception($"Could not find aircraft to delete with id {id}");
            }
            _praticeDatabase.Aircrafts.Remove(dbAircraft);

            await _praticeDatabase.SaveChangesAsync();
        }
    }
}
