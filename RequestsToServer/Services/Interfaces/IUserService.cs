using RequestsToServer.Models;

namespace RequestsToServer.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<CollectionData<User>> GetUsersByPageAsync(int page);
        Task<CollectionData<User>> GetUsersByDelayAsync(int delay);
        Task<Employee> CreateUserEmployeeAsync(string name, string job);
        Task<Employee> UpdateUserEmployeeAsync(int id, string name, string job);
        Task<Employee> ModifyUserEmployeeAsync(int id, string name, string job);
        Task<VoidResult> RemoveUserEmployeeAsync(int id);
    }
}