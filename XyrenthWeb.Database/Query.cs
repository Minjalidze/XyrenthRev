using MySqlConnector;

namespace XyrenthWeb.Database
{
    public class Query : IDisposable
    {
        private readonly string _connectionString = "Server=localhost;User ID=root;Password=;Database=xyrenth";
        private readonly MySqlConnection _connection;

        public Query()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public async Task<List<object[]>> ExecProcedureAsync(string name, params QueryParameter[]? queryParameters)
        {
            var temp = new List<object[]>();

            using var command = new MySqlCommand(name, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (queryParameters is not null)
                foreach (var queryParam in queryParameters)
                    command.Parameters.Add(queryParam.SqlParameter);

            using var reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                var array = new object[reader.FieldCount];
                for (var i = 0; i < array.Length; i++)
                    array[i] = reader[i];
                temp.Add(array);
            }

            return temp;
        }
        public List<object[]> ExecProcedure(string name, params QueryParameter[]? queryParameters)
        {
            var temp = new List<object[]>();

            using var command = new MySqlCommand(name, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (queryParameters is not null)
                foreach (var queryParam in queryParameters)
                    command.Parameters.Add(queryParam.SqlParameter);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var array = new object[reader.FieldCount];
                for (var i = 0; i < array.Length; i++)
                    array[i] = reader[i];
                temp.Add(array);
            }

            return temp;
        }

        public async Task<List<object[]>> ExecProcedureAsync(string name) =>
            await ExecProcedureAsync(name, null);
        public List<object[]> ExecProcedure(string name) =>
            ExecProcedure(name, null);

        public async Task<List<object[]>> ExecSqlAsync(string sql)
        {
            var temp = new List<object[]>();

            using var command = new MySqlCommand(sql, _connection);
            using var reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                var array = new object[reader.FieldCount];
                for (var i = 0; i < array.Length; i++)
                    array[i] = reader[i];
                temp.Add(array);
            }

            return temp;
        }
        public List<object[]> ExecSql(string sql)
        {
            var temp = new List<object[]>();

            using var command = new MySqlCommand(sql, _connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var array = new object[reader.FieldCount];
                for (var i = 0; i < array.Length; i++)
                    array[i] = reader[i];
                temp.Add(array);
            }

            return temp;
        }

        public async Task ExecAnySqlAsync(string sql)
        {
            using var command = new MySqlCommand(sql, _connection);
            await command.ExecuteNonQueryAsync();
        }
        public void ExecAnySql(string sql)
        {
            using var command = new MySqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public void ExecFunction(string name, params QueryParameter[]? queryParameters)
        {
            using var command = new MySqlCommand(name, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (queryParameters is not null)
                foreach (var queryParam in queryParameters)
                    command.Parameters.Add(queryParam.SqlParameter);

            command.ExecuteNonQuery();
        }
        public void ExecFunction(string name) =>
            ExecFunction(name, null);

        public async Task ExecFunctionAsync(string name, params QueryParameter[]? queryParameters)
        {
            using var command = new MySqlCommand(name, _connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            if (queryParameters is not null)
                foreach (var queryParam in queryParameters)
                    command.Parameters.Add(queryParam.SqlParameter);

            await command.ExecuteNonQueryAsync();
        }
        public async Task ExecFunctionAsync(string name) => 
            await ExecFunctionAsync(name, null);
    }
}
