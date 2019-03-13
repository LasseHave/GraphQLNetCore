using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQLNetCore.Models;
using System.Threading.Tasks;
using GraphQLNetCore.Repositories.InMemory;

namespace GraphQLNetCore.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLController : Controller
    {
        private StarWarsQuery _starWarsQuery { get; set; }

        public GraphQLController(StarWarsQuery starWarsQuery)
        {
            _starWarsQuery = starWarsQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = _starWarsQuery };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}