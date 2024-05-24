namespace XyrenthWeb.Models
{
    public class DetectModel(int id, string? value, DetectTypeModel? detectType, BanMessageModel? banMessage, BanTypeModel? banType)
    {
        public int Id { get; set; } = id;
        public string? Value { get; set; } = value;
        public DetectTypeModel? DetectType { get; set; } = detectType;
        public BanMessageModel? BanMessage { get; set; } = banMessage;
        public BanTypeModel? BanType { get; set; } = banType;

        public static void LoadFromQuery(List<object[]> objects)
        {
            detectModels.Clear();
            foreach (var obj in objects)
            {
                var model = new DetectModel((int)obj[0], (string)obj[1],
                DetectTypeModel.Get((int)obj[2]),
                BanMessageModel.Get((int)obj[3]),
                BanTypeModel.Get((int)obj[4]));

                detectModels.Add(model);
            }
        }
        public static IEnumerable<DetectModel> All =>
            detectModels;

        public static DetectModel GetByQuery(object[] queryResult)
        {
            var model = new DetectModel((int)queryResult[0], (string)queryResult[1],
                DetectTypeModel.Get((int)queryResult[2]),
                BanMessageModel.Get((int)queryResult[3]),
                BanTypeModel.Get((int)queryResult[4]));
            detectModels.Add(model);
            return model;
        }

        public static DetectModel? Get(int id) =>
            detectModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<DetectModel> detectModels = new List<DetectModel>();
    }
}
