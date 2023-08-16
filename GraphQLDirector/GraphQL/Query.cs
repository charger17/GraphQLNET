using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Query
    {
        public IQueryable<Video> GetVideos([Service] ApiDbContext context)
        {
            return context.Videos!;
        }
    }
}
