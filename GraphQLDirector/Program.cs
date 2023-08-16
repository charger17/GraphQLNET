using GraphQL.Server.Ui.Voyager;
using GraphQLDirector.Data;
using GraphQLDirector.GraphQL;
using GraphQLDirector.GraphQL.DataVideo;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ApiDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

//add graphql
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting()
    .AddType<VideoType>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();


//GRAPH ENDPOINTS
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-ui"
);

app.MapControllers();

app.Run();
