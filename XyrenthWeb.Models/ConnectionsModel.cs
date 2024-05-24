namespace XyrenthWeb.Models
{
    public class ConnectionsModel(int id, DateTime? date, UserModel? user, string? address)
    {
        public int Id { get; set; } = id;
        public DateTime? Date { get; set; } = date;
        public UserModel? User { get; set; } = user;
        public string? Address { get; set; } = address;

        public static ConnectionsModel GetByQuery(object[] queryResult)
        {
            var model = new ConnectionsModel((int)queryResult[0], (DateTime)queryResult[1], UserModel.Get((int)queryResult[2]), (string)queryResult[3]);
            connectionModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            connectionModels.Clear();
            foreach (var obj in objects)
            {
                var model = new ConnectionsModel((int)obj[0], (DateTime)obj[1], UserModel.Get((int)obj[2]), (string)obj[3]);
                connectionModels.Add(model);
            }
        }
        public static IEnumerable<ConnectionsModel> All =>
            connectionModels;
        public static ConnectionsModel? Get(int id) =>
            connectionModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<ConnectionsModel> connectionModels = new List<ConnectionsModel>();
    }
}