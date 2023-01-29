using RequestsToServer.Models;

namespace RequestsToServer.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginAsync(string login, string password);
        Task<RegisterResult> RegisterAsync(string login, string password);
    }
}