namespace NhibSamples.ConsoleApp.DataAccess
{
    using Library.Models;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Table(DatabaseTable.Products);

            Id(product => product.ProductId, mapper => mapper.Generator(Generators.Identity));

            Property(product => product.Name);
            Property(product => product.Description);
            Property(product => product.Type);
            Property(product => product.IsActive);
        }
    }
}