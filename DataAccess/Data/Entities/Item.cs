using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WeekDay>? Days { get; set; }
        public ICollection<HomeWorkItem>? HomeWorkItems { get; set; }
     

    }
}
