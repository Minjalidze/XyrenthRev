namespace XyrenthWeb.Models
{
    public class UserModel(int id, string? userName, DateTime? registration, HWIDModel? hWID)
    {
        public int Id { get; set; } = id;
        public string? UserName { get; set; } = userName;
        public DateTime? Registration { get; set; } = registration;
        public HWIDModel? HWID { get; set; } = hWID;

        public static UserModel GetByQuery(object[] queryResult)
        {
            var model = new UserModel((int)queryResult[0], (string)queryResult[1], (DateTime)queryResult[2], HWIDModel.Get((int)queryResult[3]));
            userModels.Add(model);
            return model;
        }

        public static void LoadFromQuery(List<object[]> objects)
        {
            userModels.Clear();
            foreach (var obj in objects)
            {
                var model = new UserModel((int)obj[0], (string)obj[1], (DateTime)obj[2], HWIDModel.Get((int)obj[3]));
                userModels.Add(model);
            }
        }
        public static IEnumerable<UserModel> All =>
            userModels;
        public static UserModel? Get(int id) =>
            userModels.FirstOrDefault(predicate: x => x.Id == id);
        private static List<UserModel> userModels = new List<UserModel>();
    }
}
