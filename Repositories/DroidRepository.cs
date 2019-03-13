using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLNetCore.Models;
using System.Linq;
using GraphQLNetCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetCore.Repositories.InMemory
{
    public class DroidRepository : IDroidRepository
    {
        private StarWarsContext _db { get; set; }

        public DroidRepository(StarWarsContext db)
        {
            _db = db;
        }

        public Task<Droid> Get(int id)
        {
            return _db.Droids.FirstOrDefaultAsync(droid => droid.Id == id);
        }

        public List<Droid> GetAll()
        {
            return _db.Droids.ToList();
        }
    }
}