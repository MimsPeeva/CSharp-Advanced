using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public string BirthDate { get; set; }
    }
}
