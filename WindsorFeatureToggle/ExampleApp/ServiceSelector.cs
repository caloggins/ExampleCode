namespace ExampleApp
{
    using System.Reflection;

    using Castle.Facilities.TypedFactory;

    public class ServiceSelector : DefaultTypedFactoryComponentSelector
    {
        private readonly bool useNewService;

        public ServiceSelector(bool useNewService)
        {
            this.useNewService = useNewService;
        }

        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return useNewService ? typeof(NewService).FullName : typeof(OldService).FullName;
        }
    }
}