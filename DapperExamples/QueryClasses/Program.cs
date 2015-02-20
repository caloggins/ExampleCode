namespace QueryClasses
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main()
        {
            try
            {
                DapperThing thing;

                const string connectionString = "Server=localhost;Database=Experimental;User Id=Adama;Password=William";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    const string id = "C2809366-B155-4314-84FB-331A409616E8";
                    thing = new GetById<DapperThing, Guid>(connection)
                        .Run(new {Id = new Guid(id)}) ?? new DapperThing {Id = new Guid(id)};
                }

                Console.WriteLine(thing.EnrollmentKey);

                thing.EnrollmentKey = Guid.NewGuid();
                Console.WriteLine(thing.EnrollmentKey);

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    new SaveOrUpdate<DapperThing, Guid>(connection).Run(thing);
                }
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
