namespace XyrenthWeb.Models
{
    public class DetectTypeModel(int id, string? name, int price, int length, bool isNever, bool isEnabled)
    {
        public int Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public int Price { get; set; } = price;
        public int Length { get; set; } = length;
        public bool IsNever { get; set; } = isNever;
        public bool IsEnabled { get; set; } = isEnabled;

        public static DetectTypeModel GetByQuery(object[] queryResult)
        {
            var model = new DetectTypeModel((int)queryResult[0], (string)queryResult[1], (int)queryResult[2], (int)queryResult[3], (bool)queryResult[4], (bool)queryResult[5]);
            detectTypeModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            detectTypeModels.Clear();
            foreach (var obj in objects)
            {
                var model = new DetectTypeModel((int)obj[0], (string)obj[1], (int)obj[2], (int)obj[3], (bool)obj[4], (bool)obj[5]);
                detectTypeModels.Add(model);
            }
        }
        public static IEnumerable<DetectTypeModel> All =>
            detectTypeModels;
        public static DetectTypeModel? Get(int id) =>
            detectTypeModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<DetectTypeModel> detectTypeModels = new List<DetectTypeModel>();
    }
}
