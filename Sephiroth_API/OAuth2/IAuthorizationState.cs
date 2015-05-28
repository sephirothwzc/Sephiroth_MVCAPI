using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sephiroth_API.OAuth2
{
    public interface IAuthorizationState
    {
        Uri Callback { get; set; }
        string RefreshToken { get; set; }
        string AccessToken { get; set; }
        DateTime? AccessTokenIssueDateUtc { get; set; }
        DateTime? AccessTokenExpirationUtc { get; set; }
        HashSet<string> Scope { get; }
    }
}
