using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        public IQueryable<Video> GetVideos([ScopedService] ApiDbContext context)
        {
            return context.Videos!;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        public IQueryable<Director> GetDirector([ScopedService] ApiDbContext context)
        {
            return context.Directores!;
        }
    }
}
