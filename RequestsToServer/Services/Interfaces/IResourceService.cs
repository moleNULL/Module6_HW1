using RequestsToServer.Models;

namespace RequestsToServer.Services.Interfaces
{
    public interface IResourceService
    {
        Task<Resource> GetResourceAsync(int id);
        Task<CollectionData<Resource>> GetResourcesAsync();
    }
}