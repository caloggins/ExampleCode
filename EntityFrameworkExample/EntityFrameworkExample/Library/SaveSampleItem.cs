using MediatR;

namespace EntityFrameworkExample.Library
{
  public class SaveSampleItem : INotification
  {
    public string Data { get; set; }
  }
}