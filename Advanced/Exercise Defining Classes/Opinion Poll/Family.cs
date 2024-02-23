using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> list = new();
        public Family()
        {
            this.list = new List<Person>();
        }
        public List<Person> List
        {
            get { return list; }
            set { list = value; }
        }
        public void AddMember(Person person)
        {
            list.Add(person);
        }
        public Person GetOldestMember()
        {
            //Person oldestMember = list.MaxBy(x => x.Age);
            //return oldestMember;
            //second variant
            return list.FirstOrDefault(p => p.Age == list.Max(p1 => p1.Age));
        }
    }
}
