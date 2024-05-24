using MySqlConnector;

namespace XyrenthWeb.Database
{
    public class QueryParameter(string name, object value)
    {
        public MySqlParameter SqlParameter { get; set; } = new MySqlParameter(name, value);
    }
}
