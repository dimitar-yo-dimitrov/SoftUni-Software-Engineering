using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public abstract class Collection<T> : IAddCollection<T>
    {
        protected Collection()
        {
            this.Data = new List<T>();
        }

        protected List<T> Data { get; }

        public virtual int Add(T item)
        {
            var index = 0;

            this.Data.Insert(index, item);

            return index;
        }
    }
}
