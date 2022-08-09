using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {

        public int Used => this.Data.Count;

        public override T Remove()
        {
            T item = this.Data[0];
            this.Data.RemoveAt(0);

            return item;
        }
    }
}
