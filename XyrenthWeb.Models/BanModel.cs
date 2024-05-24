namespace XyrenthWeb.Models
{
    public class BanModel(int id, DetectModel? detect, UserModel? user, DateTime? date, DateTime? expired)
    {
        public int Id { get; set; } = id;
        public DetectModel? Detect { get; set; } = detect;
        public UserModel? User { get; set; } = user;
        public DateTime? Date { get; set; } = date;
        public DateTime? Expired { get; set; } = expired;

        public static BanModel GetByQuery(object[] queryResult)
        {
            var model = new BanModel((int)queryResult[0], DetectModel.Get((int)queryResult[1]), UserModel.Get((int)queryResult[2]), (DateTime)queryResult[3], (DateTime)queryResult[4]);
            banModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            banModels.Clear();
            foreach (var obj in objects)
            {
                var model = new BanModel((int)obj[0], DetectModel.Get((int)obj[1]), UserModel.Get((int)obj[2]), (DateTime)obj[3], (DateTime)obj[4]);
                banModels.Add(model);
            }
        }
        public static IEnumerable<BanModel> All =>
            banModels;
        public static BanModel? Get(int id) =>
            banModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<BanModel> banModels = new List<BanModel>();
    }
}
