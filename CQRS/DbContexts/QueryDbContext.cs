using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CQRS
{
    public class QueryDbContext
    {
        public QueryDbContext(IOptions<QueryDatabaseSettings>
           queryDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                        queryDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                queryDatabaseSettings.Value.DatabaseName);

            Employee = mongoDatabase.GetCollection<EmployeeQuery>(
                queryDatabaseSettings.Value.BooksCollectionName);
        }

        public IMongoCollection<EmployeeQuery> Employee { get; private set; }

    }
}
