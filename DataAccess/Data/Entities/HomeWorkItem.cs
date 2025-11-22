using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class HomeWorkItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; } 
        public Item? Item { get; set; }
        public string Decription         {  get; set; }
        public bool IsControlWork { get; set; } = false;


        public DateTime HomeWorkDate { get; set; }

    }
}
