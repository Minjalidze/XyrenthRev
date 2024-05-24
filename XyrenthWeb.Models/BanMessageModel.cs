namespace XyrenthWeb.Models
{
    public class BanMessageModel(int id, string? message)
    {
        public int Id { get; set; } = id;
        public string? Message { get; set; } = message;

        public static BanMessageModel GetByQuery(object[] queryResult) {
            var model = new BanMessageModel((int)queryResult[0], (string)queryResult[1]);
            banMessageModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            banMessageModels.Clear();
            foreach (var obj in objects)
            {
                var model = new BanMessageModel((int)obj[0], (string)obj[1]);
                banMessageModels.Add(model);
            }
        }
        public static IEnumerable<BanMessageModel> All =>
            banMessageModels;
        public static BanMessageModel? Get(int id) =>
            banMessageModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<BanMessageModel> banMessageModels = new List<BanMessageModel>();
    }
}
