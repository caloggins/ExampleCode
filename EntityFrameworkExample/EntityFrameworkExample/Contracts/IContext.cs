using System.Data.Entity;

namespace EntityFrameworkExample.Contracts
{
  public interface IContext
  {
    System.Data.Entity.Database Database { get; }

    IDbSet<TType> Set<TType>()
      where TType : class;

    int SaveChanges();
  }
}