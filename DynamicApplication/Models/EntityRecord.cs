using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Models
{
    public class EntityRecord
    {
        public Entity Entity { get; set; }
        public ObservableCollection<EntityAttribute> EntityAttributes { get; set; }
    }
}
