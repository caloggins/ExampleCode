namespace ExampleApp
{
    using System;
    using System.Linq;

    using Castle.MicroKernel;

    public class ServiceHandler : IHandlerSelector
    {
        private readonly bool useNewService;

        public ServiceHandler(bool useNewService)
        {
            this.useNewService = useNewService;
        }

        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(IService);
        }

        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            var s = useNewService ? typeof(NewService) : typeof(OldService);

            var q = (from h in handlers
                     where h.ComponentModel.Implementation == s
                     select h).FirstOrDefault();

            if (q == null)
                throw new ApplicationException(string.Format("No handlers for {0}", service.Name));

            return q;
        }
    }
}