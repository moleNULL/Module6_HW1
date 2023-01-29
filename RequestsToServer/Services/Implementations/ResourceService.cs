using RequestsToServer.DTOs.Responses;
using RequestsToServer.Models;
using RequestsToServer.Services.Interfaces;
using Microsoft.Extensions.Options;
using RequestsToServer.Config;

namespace RequestsToServer.Services
{
    public class ResourceService : BaseService, IResourceService
    {
        private readonly IInternalHttpClientService _internalHttpClientService;
        private readonly APIConfig _apiConfig;

        public ResourceService(
            IInternalHttpClientService internalHttpClientService,
            IOptions<APIConfig> options)
        {
            _apiConfig = options.Value;
            _internalHttpClientService = internalHttpClientService;
        }

        public async Task<Resource> GetResourceAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto>>($"{_apiConfig.Host}/unknown/{id}", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new Resource
                    {
                        Color = response.Data.Color,
                        Name = response.Data.Name,
                        Id = response.Data.Id,
                        PantoneValue = response.Data.PantoneValue,
                        Year = response.Data.Year
                    };
                }

                return null!;
            });
        }

        public async Task<CollectionData<Resource>> GetResourcesAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var response =
                    await _internalHttpClientService.SendAsync<PagingResponse<ResourceDto[]>>($"{_apiConfig.Host}/unknown", HttpMethod.Get);

                if (response!.Data != null)
                {
                    return new CollectionData<Resource>()
                    {
                        Data = response.Data.Select(s => new Resource
                        {
                            Color = s.Color,
                            Name = s.Name,
                            Id = s.Id,
                            PantoneValue = s.PantoneValue,
                            Year = s.Year
                        }).ToList()
                    };
                }

                return null!;
            });
        }
    }
}