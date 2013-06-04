namespace NhibSamples.Library.Models
{
    public class Product
    {
        public virtual long ProductId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ProductType Type { get; set; }
        public virtual bool IsActive { get; set; }

        public override string ToString()
        {
            return string.Format("Product <Id: {0}, Name: {1}>", ProductId, Name);
        }
    }
}