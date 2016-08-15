using System;
using System.Data.Entity;
using System.Linq;
using EntityFrameworkExample.Contracts;

namespace EntityFrameworkExample.Database
{
  public class LocalContext : DbContext, IContext
  {
    public LocalContext()
      : base(@"Server=.\sqlserver2014;Database=Experiments;Trusted_Connection=True;")
    {

    }

    public new IDbSet<TType> Set<TType>()
      where TType : class
    {
      return base.Set<TType>();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");

      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        var entityTypes = assembly
          .GetTypes()
          .Where(t =>
            t.GetCustomAttributes(typeof(PersistentAttribute), true)
              .Any());

        foreach (var type in entityTypes)
        {
          entityMethod.MakeGenericMethod(type)
            .Invoke(modelBuilder, new object[] { });
        }
      }
    }
  }
}