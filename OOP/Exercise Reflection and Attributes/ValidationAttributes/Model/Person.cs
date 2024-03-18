using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Model
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        private const int minAge = 12;
        private const int maxAge = 90;
        [MyRequired]
        public string FullName { get; set; }
        [MyRange(minAge,maxAge)]
        public int Age { get; set; }
    }
}
