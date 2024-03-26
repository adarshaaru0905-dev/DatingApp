using Datingapp.Entities;

namespace Datingapp.interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        
        

    }
}