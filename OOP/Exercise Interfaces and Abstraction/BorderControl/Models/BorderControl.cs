using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class BorderControl
    {
        private List<BaseEntity> entities;
        public List<BaseEntity> EntitiesToCheck
            { get => entities;  }
        public BorderControl()
        { entities = new List<BaseEntity>();

        }
       public void AddEntityForBorderControl(BaseEntity entity)
        { entities.Add(entity); }
    }
}
