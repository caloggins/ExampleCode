namespace QueryClasses
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        private const string ConnectionString = "Server=localhost;Database=Experimental;User Id=Adama;Password=William";

        static void Main()
        {
            try
            {
                var thing = new DapperThing
                {
                    Id = Guid.NewGuid(),
                    CreateDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    SomeData = Guid.NewGuid(),
                };

                Console.WriteLine("*** Save ***");
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var save = new Save<DapperThing, Guid>(connection);
                    save.Run(thing);
                }
                Console.WriteLine(thing);

                Console.WriteLine("*** Update ***");
                thing.SomeData = Guid.NewGuid();
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    new SaveOrUpdate<DapperThing, Guid>(connection).Run(thing);
                }
                Console.WriteLine(thing);

                Console.WriteLine("*** Get ***");
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var getById = new GetById<DapperThing, Guid>(connection);
                    var fromDb = getById.Run(new{thing.Id});
                    Console.WriteLine(fromDb);
                }

                Console.WriteLine("*** Update ***");
                thing.SomeData = Guid.NewGuid();
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    new SaveOrUpdate<DapperThing, Guid>(connection).Run(thing);
                }
                Console.WriteLine(thing);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
