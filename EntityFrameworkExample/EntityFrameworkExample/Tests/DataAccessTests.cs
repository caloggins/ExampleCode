using System;
using System.Linq;
using EntityFrameworkExample.Database;
using EntityFrameworkExample.Library;
using FluentAssertions;
using MediatR;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Planning.Bindings.Resolvers;
using NUnit.Framework;

namespace EntityFrameworkExample.Tests
{
  public class DataAccessTests
  {
    [Test]
    public void ItShouldGetItemsFromTheDatabase()
    {
      var context = new LocalContext();

      var sampleItems = context.Set<SampleItem>()
        .ToList();

      sampleItems.Should().NotBeEmpty();
    }

    [Test]
    public void UsingQueriesWorksTheSameWay()
    {
      var mediator = GetMediator();

      var sampleItem = mediator.Send(new GetSampleItems());

      sampleItem.Should().NotBeEmpty();
    }

    [Test]
    public void ItWillSaveItemsToo()
    {
      var mediator = GetMediator();

      var data = Guid.NewGuid().ToString();
      var saveSampleItem = new SaveSampleItem { Data = data };
      mediator.Publish(saveSampleItem);

      var items = mediator.Send(new GetSampleItems());
      items.Count(o => o.Data == data).Should().Be(1);
    }

    private static IMediator GetMediator()
    {
      var kernel = new StandardKernel();

      kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();
      kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>().SelectAllClasses().BindDefaultInterface());
      kernel.Bind(scan => scan.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
      kernel.Bind<SingleInstanceFactory>().ToMethod(context => t => context.Kernel.Get(t));
      kernel.Bind<MultiInstanceFactory>().ToMethod(context => t => context.Kernel.GetAll(t));

      return kernel.Get<IMediator>();
    }
  }

}