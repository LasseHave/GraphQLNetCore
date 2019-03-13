using GraphQLNetCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLNetCore.Repositories
{
    public interface IDroidRepository
    {
        Task<Droid> Get(int id);
        List<Droid> GetAll();
    }
}