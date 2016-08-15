using System;
using EntityFrameworkExample.Contracts;
using MediatR;

namespace EntityFrameworkExample.Library
{
  public class SaveSampleItemHandler : INotificationHandler<SaveSampleItem>
  {
    private readonly IContext context;

    public SaveSampleItemHandler(IContext context)
    {
      this.context = context;
    }

    public void Handle(SaveSampleItem notification)
    {
      var sampleItem = new SampleItem
      {
        Id = Guid.NewGuid(),
        Data = notification.Data
      };

      context.Set<SampleItem>()
        .Add(sampleItem);
      context.SaveChanges();
    }
  }
}