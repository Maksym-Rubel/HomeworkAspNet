using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class HomeWorkItemDto
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string Decription { get; set; }
        public bool IsControlWork { get; set; } = false;

        public DateTime HomeWorkDate { get; set; }
    }
}
