using RequestsToServer.Config;
using RequestsToServer.DTOs.Responses;
using RequestsToServer.Models;
using RequestsToServer.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace RequestsToServer.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly APIConfig _apiConfig;

        public UserService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<APIConfig> options)
        {
            _apiConfig = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService
                        .SendAsync<PagingResponse<UserDto>>($"{_apiConfig.Host}/users/{id}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new User
                    {
                        Email = response.Data.Email,
                        FirstName = response.Data.FirstName,
                        Id = response.Data.Id,
                        LastName = response.Data.LastName,
                        UrlAvatar = response.Data.UrlAvatar
                    };
                }

                return null!;
            });
        }

        public async Task<CollectionData<User>> GetUsersByPageAsync(int page)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService
                        .SendAsync<PagingResponse<UserDto[]>>($"{_apiConfig.Host}/users?page={page}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.UrlAvatar
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<CollectionData<User>> GetUsersByDelayAsync(int delay)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService
                        .SendAsync<PagingResponse<UserDto[]>>($"{_apiConfig.Host}/users?delay={delay}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<User>()
                    {
                        Data = response.Data.Select(s => new User
                        {
                            Email = s.Email,
                            FirstName = s.FirstName,
                            Id = s.Id,
                            LastName = s.LastName,
                            UrlAvatar = s.UrlAvatar
                        }).ToList()
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> CreateUserEmployeeAsync(string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDto { Name = name, Job = job };
                var response =
                    await _internalHttpClientService
                        .SendAsync<EmployeeDto>($"{_apiConfig.Host}/users", HttpMethod.Post, request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> UpdateUserEmployeeAsync(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDto { Name = name, Job = job };
                var response =
                    await _internalHttpClientService
                        .SendAsync<EmployeeDto>($"{_apiConfig.Host}/users/{id}", HttpMethod.Put, request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<Employee> ModifyUserEmployeeAsync(int id, string name, string job)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var request = new EmployeeDto { Name = name, Job = job };
                var response =
                    await _internalHttpClientService
                        .SendAsync<EmployeeDto>($"{_apiConfig.Host}/users/{id}", HttpMethod.Patch, request);

                if (response != null)
                {
                    return new Employee
                    {
                        CreatedAt = response.CreatedAt,
                        Job = response.Job,
                        Id = response.Id,
                        Name = response.Name,
                        UpdatedAt = response.UpdatedAt
                    };
                }

                return null!;
            });
        }

        public async Task<VoidResult> RemoveUserEmployeeAsync(int id)
        {
            return await ExecuteSafeAsync<VoidResult>(async () =>
            {
                await _internalHttpClientService.SendAsync($"{_apiConfig.Host}/users/{id}", HttpMethod.Delete);
                return null!;
            });
        }
    }
}