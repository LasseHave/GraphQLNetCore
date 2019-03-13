using System.Linq;
using GraphQL.Types;
using GraphQLNetCore.Repositories;

namespace GraphQLNetCore.Models
{
    public class StarWarsQuery : ObjectGraphType
    {
        private IDroidRepository _droidRepository { get; set; }

        public StarWarsQuery(IDroidRepository _droidRepository)
        {
            Field<DroidType>(
              "hero",
              arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the droid." }),
              resolve: context => {
                  var id = context.GetArgument<int>("id");
                  return _droidRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
              }
            );
        }
    }
}