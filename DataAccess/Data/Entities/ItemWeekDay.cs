using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class ItemWeekDay
    {
        public int Id { get; set; }
        public int DayId { get; set; }

        public WeekDay? Day { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

    }
}
