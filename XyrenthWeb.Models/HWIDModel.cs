namespace XyrenthWeb.Models
{
    public class HWIDModel(int id, string? value)
    {
        public int Id { get; set; } = id;
        public string? Value { get; set; } = value;

        public static HWIDModel GetByQuery(object[] queryResult)
        {
            var model = new HWIDModel((int)queryResult[0], (string)queryResult[1]);
            hWIDModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            hWIDModels.Clear();
            foreach (var obj in objects)
            {
                var model = new HWIDModel((int)obj[0], (string)obj[1]);
                hWIDModels.Add(model);
            }
        }
        public static IEnumerable<HWIDModel> All =>
            hWIDModels;
        public static HWIDModel? Get(int id) =>
            hWIDModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<HWIDModel> hWIDModels = new List<HWIDModel>();
    }
}
