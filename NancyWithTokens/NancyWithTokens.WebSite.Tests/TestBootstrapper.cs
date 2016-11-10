using System;
using Nancy.TinyIoc;

namespace NancyWithTokens.WebSite.Tests
{
    public class TestBootstrapper : Bootstrap
    {
        private readonly Action<TinyIoCContainer> register;
        public TestBootstrapper(Action<TinyIoCContainer> register)
        {
            this.register = register;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            register(container);
        }
    }
}