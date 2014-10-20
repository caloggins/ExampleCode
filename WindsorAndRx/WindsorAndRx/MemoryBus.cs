namespace WindsorAndRx
{
    using System;

    using Castle.MicroKernel;

    using MemBus;
    using MemBus.Configurators;

    public static class MemoryBus
    {
        public static IBus Create()
        {
            return BusSetup.StartWith<Fast>()
                .Construct();
        }

        // I could put this elsewhere, or use a factory, but meh.
        public static IObservable<TType> CreateObservable<TType>(IKernel kernel)
        {
            var bus = kernel.Resolve<IBus>();
            var observable = bus.Observe<TType>();
            return observable;
        } 
    }
}