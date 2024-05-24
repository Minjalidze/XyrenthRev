using XyrenthWeb.Database;

namespace XyrenthWeb.Services
{
    public class DatabaseService : IDatabaseService
    {
        public static DatabaseService? Instance { get; set; }

        public DatabaseService() {
            Instance = this;
        }

        private Query? query;
        public Query GetQuery() =>
            query ??= new Query();
    }
}