using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }
        public void AddItem(T item)
        {
            list.Add(item);
        }
        public int Count(T item)
        {
            int count = 0;
            foreach (var listItem in list)
            {
                if (listItem.CompareTo(item)>0)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
     
    }
}
