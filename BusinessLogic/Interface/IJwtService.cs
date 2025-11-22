using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IJwtService
    {
        Task<IEnumerable<Claim>> GetClaims(User user);
        string GenerateToken(IEnumerable<Claim> claims);

        RefreshToken GenerateRefreshToken(string ipAddress);

    }
}
