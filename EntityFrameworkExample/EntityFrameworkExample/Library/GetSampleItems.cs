using System.Collections.Generic;
using MediatR;

namespace EntityFrameworkExample.Library
{
  public class GetSampleItems : IRequest<IEnumerable<SampleItem>>
  {
    
  }
}