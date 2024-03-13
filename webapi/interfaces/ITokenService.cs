using webapi.model;

namespace webapi.interfaces
{
    public interface ITokenService
    {

        string CreateToken(AppUser user);
    }
}
