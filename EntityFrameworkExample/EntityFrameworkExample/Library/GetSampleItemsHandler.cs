using System.Collections.Generic;
using System.Linq;
using EntityFrameworkExample.Contracts;
using MediatR;

namespace EntityFrameworkExample.Library
{
  public class GetSampleItemsHandler : IRequestHandler<GetSampleItems, IEnumerable<SampleItem>>
  {
    private readonly IContext context;

    public GetSampleItemsHandler(IContext context)
    {
      this.context = context;
    }

    public IEnumerable<SampleItem> Handle(GetSampleItems message)
    {
      var items = context.Set<SampleItem>()
        .ToList();

      return items;
    }
  }
}