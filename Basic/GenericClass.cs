using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection
{
    public class GenericClass<T>
    {
        private List<T>  items;

        public GenericClass()
        {
            items = new List<T>();
        }
        public void Add(T _t)
        {
            items.Add(_t); 
        }
        public bool Remove(T _t)
        {
            return items.Remove(_t);
        }
        public bool Contains(T _t)
        {
            return (items.Contains(_t));
        }
        public T GetItems(int index)
        {
            if (index >= 0 && index < items.Count)
                return items[index];
            else
                throw new IndexOutOfRangeException("Index is out of range.");
        }
    }
}
