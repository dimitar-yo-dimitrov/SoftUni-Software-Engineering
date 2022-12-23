namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : Collection<T>
    {
        public override int Add(T item)
        {
             base.Add(item);

             return this.Data.Count - 1;
        }
    }
}
