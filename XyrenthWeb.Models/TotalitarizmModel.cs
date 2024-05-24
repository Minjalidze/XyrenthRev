namespace XyrenthWeb.Models
{
    public class TotalitarizmModel(int id, UserModel? user)
    {
        public int Id { get; set; } = id;
        public UserModel? User { get; set; } = user;

        public static TotalitarizmModel GetByQuery(object[] queryResult)
        {
            var model = new TotalitarizmModel((int)queryResult[0], UserModel.Get((int)queryResult[1]));
            totalitarizmModels.Add(model);
            return model;
        }
        public static void LoadFromQuery(List<object[]> objects)
        {
            totalitarizmModels.Clear();
            foreach (var obj in objects)
            {
                var model = new TotalitarizmModel((int)obj[0], UserModel.Get((int)obj[1]));
                totalitarizmModels.Add(model);
            }
        }
        public static IEnumerable<TotalitarizmModel> All =>
            totalitarizmModels;
        public static TotalitarizmModel? Get(int id) =>
            totalitarizmModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<TotalitarizmModel> totalitarizmModels = new List<TotalitarizmModel>();
    }
}
