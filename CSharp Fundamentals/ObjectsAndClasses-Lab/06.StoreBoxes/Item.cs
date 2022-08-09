using System;

namespace _06.StoreBoxes
{
    public class Item
    {
        public static implicit operator Item(string v)
        {
            throw new NotImplementedException();
        }
    }
}