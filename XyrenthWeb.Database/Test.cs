using System.Diagnostics;
using XyrenthWeb.Models;

namespace XyrenthWeb.Database
{
    public class Test
    {
        public static void DoGepa()
        {
            var q = new Query();
           
            Console.WriteLine($"\nСоздание 1000-и юзеров при помощи ХФ:");
            DoWithWatch(async () =>
            {
                for (var i = 1; i <= 1000; i++)
                    await q.ExecFunctionAsync("CreateNewUser",
                        new QueryParameter("USERNAME", $"Iteration #{i}"),
                        new QueryParameter("REGISTRATION", DateTime.Now.ToString("s")),
                        new QueryParameter("HWIDID", i));
            });
        }

        public static void DoPepa()
        {
            var q = new Query();

            Console.WriteLine($"\nI: 1");
            DoWithWatch(() =>
            {
                var result = q.ExecProcedure("GetAllHWIDs");
                var models = result.Select(HWIDModel.GetByQuery);

                foreach (var model in models)
                    Console.WriteLine(model.Id + " : " + model.Value);
            });


            Console.WriteLine($"\nI: 2");
            DoWithWatch(() =>
            {
                var result = q.ExecProcedure("GetAllUsers");
                var models = result.Select(UserModel.GetByQuery);

                foreach (var model in models)
                    Console.WriteLine($"{model.Id} : {model.UserName} : {model.Registration} : {model.HWID!.Value}");
            });

            Console.WriteLine($"\nI: 3");
            DoWithWatch(() =>
            {
                var result = q.ExecProcedure("GetAllUsers");
                var models = result.Select(UserModel.GetByQuery);

                foreach (var model in models)
                    Console.WriteLine($"{model.Id} : {model.UserName} : {model.Registration} : {model.HWID!.Value}");
            });
        }

        private static void DoWithWatch(Action action)
        {
            var timer = new Stopwatch();
            timer.Start();

            action.Invoke();

            timer.Stop();
            var timeTaken = timer.Elapsed;
            Console.WriteLine($"Full complete: {timeTaken}");
        }
    }
}
