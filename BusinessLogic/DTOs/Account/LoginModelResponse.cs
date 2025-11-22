using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs.Account
{
    public class LoginModelResponse
    {
        public string AccesessToken { get; set; }
        public string RefreshToken { get; set; }
            
        public IList<string> Role { get; set; }

    }
}
