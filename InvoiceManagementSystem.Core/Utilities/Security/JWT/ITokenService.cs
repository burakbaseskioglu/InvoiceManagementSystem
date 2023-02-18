using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Core.Utilities.Security.JWT
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(List<Claim> claims);
        RefreshToken CreateRefreshToken();
    }
}
