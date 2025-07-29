using Microsoft.AspNetCore.Identity;

namespace NzWalksApi.Repositories;

public interface ITokenRepository
{
    string CreateJWTToken(IdentityUser user, List<string> roles);
}
