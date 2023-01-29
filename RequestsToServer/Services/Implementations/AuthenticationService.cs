using RequestsToServer.Config;
using RequestsToServer.DTOs.Responses;
using RequestsToServer.Models;
using RequestsToServer.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace RequestsToServer.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly APIConfig _apiConfig;

        public AuthenticationService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<APIConfig> options)
        {
            _apiConfig = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<LoginResult> LoginAsync(string login, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new AuthDto { Email = login, Password = password };

                var response = await _internalHttpClientService.SendAsync<LoginResponse>($"{_apiConfig.Host}/login", HttpMethod.Post, request);
                return new LoginResult
                {
                    Token = response!.Token!
                };
            });
        }

        public async Task<RegisterResult> RegisterAsync(string login, string password)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new AuthDto { Email = login, Password = password };
                var response = await _internalHttpClientService.SendAsync<RegisterResponse>($"{_apiConfig.Host}/register", HttpMethod.Post, request);
                return new RegisterResult
                {
                    Token = response!.Token!
                };
            });
        }
    }
}