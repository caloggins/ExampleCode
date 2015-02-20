namespace QueryClasses
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}