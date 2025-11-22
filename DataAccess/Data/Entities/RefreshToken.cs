using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class RefreshToken
    {

        public int Id { get; set; }

        public string Token { get; set; } = default!;
        public DateTime Expired { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expired;

        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; } = default!;

        public string UserId { get; set; }
        public User User { get; set; }


    }
}
