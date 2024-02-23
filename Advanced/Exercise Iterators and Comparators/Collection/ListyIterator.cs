using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index = 0;

        public ListyIterator(List<T> list)
        {
            this.list = list;
        }


        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            else return false;
        }
        public bool HasNext()
        {
            return index < list.Count - 1;
        }
        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine(list[index]);
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", list));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
/*
Create 1 2 3 4 5
Move
PrintAll
END
 */