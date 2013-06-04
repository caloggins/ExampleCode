namespace TopShelfWcfExample.ConsoleApp.UnitTests
{
    using System;
    using System.Linq;
    using Castle.MicroKernel;
    using Castle.Windsor;

    public static class WindsorTestHelpers
    {
        public static IHandler[] GetAllHandlers(this IWindsorContainer container)
        {
            return container.GetHandlersFor(typeof(object));
        }

        public static IHandler[] GetHandlersFor(this IWindsorContainer container, Type type)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        public static IHandler[] GetHandlersFor<T>(this IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(typeof(T));
        }

        public static Type[] GetImplementationTypesFor<T>(this IWindsorContainer container)
        {
            return container.GetImplementationTypesFor(typeof (T));
        }

        private static Type[] GetImplementationTypesFor(this IWindsorContainer container, Type type)
        {
            return container.GetHandlersFor(type)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }
    }
}