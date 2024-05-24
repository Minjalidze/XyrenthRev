namespace XyrenthWeb.Models
{
    public class BanTypeModel(int id, string? type)
    {
        public int Id { get; set; } = id;
        public string? Type { get; set; } = type;

        public static BanTypeModel GetByQuery(object[] queryResult)
        {
            var model = new BanTypeModel((int)queryResult[0], (string)queryResult[1]);
            banTypeModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            banTypeModels.Clear();
            foreach (var obj in objects)
            {
                var model = new BanTypeModel((int)obj[0], (string)obj[1]);
                banTypeModels.Add(model);
            }
        }
        public static IEnumerable<BanTypeModel> All =>
            banTypeModels;
        public static BanTypeModel? Get(int id) =>
            banTypeModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<BanTypeModel> banTypeModels = new List<BanTypeModel>();
    }
}
