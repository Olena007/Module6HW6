using IdentityModel.Client;

namespace asp_ht4.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
