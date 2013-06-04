namespace NhibSamples.ConsoleApp
{
    using System;
    using Castle.Windsor;
    using Library.Models;
    using NHibernate;

    public class Program : IHazRun
    {
        private readonly ISessionFactory sessionFactory;

        static void Main()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Starting test...");

                var container = new WindsorContainer();
                var bootstrap = new Bootstrap
                                    {
                                        ConnectionString =
                                            "Data Source=localhost;Initial Catalog=NhibSampleData;Integrated Security=SSPI;"
                                    };

                bootstrap.InitializeContainer(container);

                var program = container.Resolve<IHazRun>();
                program.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine("{0}", exception);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        public Program(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public void Run()
        {
            using (var session = sessionFactory.OpenSession())
            {
                long id;

                using (var tx = session.BeginTransaction())
                {
                    var order = new CustomerOrder {Comments = "No comment.", DatePlaced = DateTime.Now};
                    id = (long) session.Save(order);
                    tx.Commit();
                }

                var savedOrder = session.Get<CustomerOrder>(id);
                
                Console.WriteLine();
                Console.WriteLine(savedOrder);
            }
        }
    }
}
