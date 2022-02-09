using API.Entities;

namespace API.Interfaces
{ // always preface interfaces with "I"
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}