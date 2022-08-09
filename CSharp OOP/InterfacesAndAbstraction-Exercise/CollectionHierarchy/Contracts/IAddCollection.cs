namespace CollectionHierarchy.Models
{
    public interface IAddCollection<in T>
    {
        int Add(T item);
    }
}
