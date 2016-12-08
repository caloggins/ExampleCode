using System;
using System.Linq;
using FluentAssertions;
using FluentValidation;
using MediatR;
using Ninject;
using Ninject.Extensions.Conventions;
using NUnit.Framework;

namespace MediatrDecorators
{
    public class CommandHandlerTests
    {
        [Test]
        public void ItShouldHandleBasicCommands()
        {
            var mediator = GetMediator();

            var command = new Command();
            var response = mediator.Send(command);

            response.Should().NotBeNull();
        }


        [Test]
        public void ItShouldProcessCommands()
        {
            var mediator = GetMediator();

            var command = new Foo { Message = "valid ping" };
            var response = mediator.Send(command);

            response.Should().NotBeNull();
        }

        [Test]
        public void ItShouldValidateTheCommand()
        {
            var mediator = GetMediator();

            var ping = new Foo();
            Action act = () => mediator.Send(ping);

            act.ShouldThrow<ValidationException>();
        }

        [Test]
        public void ItShouldHandleComamndsWithMultipleProperties()
        {
            var mediator = GetMediator();

            var command = new Bar
            {
                Message = "valid ping",
                Author = "author"
            };
            var response = mediator.Send(command);

            response.Should().NotBeNull();
        }

        [Test]
        public void ItShouldHandleMoreThanOneValidation()
        {
            var mediator = GetMediator();

            var command = new Bar();
            Action act = () => mediator.Send(command);

            act.ShouldThrow<ValidationException>()
                .And.Errors.Count().Should().Be(2);
        }

        private static IMediator GetMediator()
        {
            var kernel = new StandardKernel();

            kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>()
                .SelectAllClasses()
                .BindDefaultInterface());

            kernel.Bind(scan => scan.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom(typeof(AbstractValidator<>))
                .BindAllInterfaces());

            kernel.Bind(scan => scan.FromThisAssembly()
                .SelectAllClasses()
                .Where(o => o.IsAssignableFrom(typeof(IRequestHandler<,>)))
                .BindAllInterfaces());

            kernel.Bind(scan => scan.FromThisAssembly()
                .SelectAllClasses()
                .InheritedFrom(typeof(IRequestHandler<,>))
                .BindAllInterfaces()
                .Configure(o => o.WhenInjectedInto(typeof(ValidatingHandler<,>))));

            kernel.Bind(typeof(IRequestHandler<,>)).To(typeof(ValidatingHandler<,>));

            kernel.Bind<SingleInstanceFactory>().ToMethod(context => (type => context.Kernel.Get(type)));
            kernel.Bind<MultiInstanceFactory>().ToMethod(context => (type => context.Kernel.GetAll(type)));
            var mediator = kernel.Get<IMediator>();

            return mediator;
        }
    }
}
