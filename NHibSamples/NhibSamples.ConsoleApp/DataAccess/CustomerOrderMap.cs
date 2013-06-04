namespace NhibSamples.ConsoleApp.DataAccess
{
    using Library.Models;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using UserTypes;

    public class CustomerOrderMap : ClassMapping<CustomerOrder>
    {
        public CustomerOrderMap()
        {
            Table(DatabaseTable.CustomerOrders);

            Id(order => order.OrderId, mapper => mapper.Generator(Generators.Identity));
            
            Property(order => order.Comments);
            Property(order => order.DatePlaced);
            
            Version(order => order.Version, mapper =>
                                                {
                                                    mapper.Generated(VersionGeneration.Always);
                                                    mapper.Column("LastModified");
                                                    mapper.Type<BinaryTimestamp>();
                                                });
        }
    }
}