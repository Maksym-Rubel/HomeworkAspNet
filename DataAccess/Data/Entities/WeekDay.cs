using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class WeekDay
    {
        public int Id {  get; set; }
        public int DayOfWeek { get; set; }
        public DateTime DayInCalendar { get; set; }

        

        public ICollection<Item>? Items { get; set; }
    }
}
