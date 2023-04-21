using demo.webapi.demo.Models;

namespace demo.webapi.demo.Repos
{
    public interface IAuthentication
    {
        Task<TokenModel> GenerateJwtToken(string userName, int userid);
    }
}
