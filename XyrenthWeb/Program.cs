using XyrenthWeb.Database;
using XyrenthWeb.Models;
using XyrenthWeb.Services;

namespace XyrenthWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            var q = new Query();
            HWIDModel.LoadFromQuery(q.ExecProcedure("GetAllHWIDs"));
            UserModel.LoadFromQuery(q.ExecProcedure("GetAllUsers"));
            TotalitarizmModel.LoadFromQuery(q.ExecSql("select * from totalitarizm;"));

            app.Run();
        }
    }
}