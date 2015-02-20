namespace DapperExamples
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    using DapperExtensions;

    using FizzWare.NBuilder;

    class Program
    {
        static void Main()
        {
            try
            {
                var connection = new SqlConnection(@"Server=localhost\sqlexpress;Database=ExperimentalStuff;Trusted_Connection=true;");

                var id = new Guid("DB44BD6A-532C-4F9A-A9A0-CE32C193F467");
                var grandParent = new GrandParent
                {
                    Id = id,
                    Name = "grandparent",
                };

                Builder<Parent>.CreateListOfSize(3).Build()
                    .ToList().ForEach(grandParent.AddParent);

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    connection.Delete<GrandParent>(new { grandParent.Id }, transaction);
                    var insert = connection.Insert(grandParent, transaction);
                    Console.WriteLine(insert);
                    transaction.Commit();
                }
                connection.Close();

                Print(connection, grandParent.Id);
                //connection.Delete<GrandParent>(new { grandParent.Id });

                connection.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void Print(IDbConnection connection, Guid id)
        {
            var inserted = connection.Get<GrandParent>(new { Id = id });
            Console.WriteLine("Date: {0}", inserted.Name);
        }
    }
}
