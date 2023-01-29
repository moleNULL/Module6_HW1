using System.Net.Http;
using System.Threading.Tasks;

namespace RequestsToServer.Services.Interfaces
{
    public interface IInternalHttpClientService
    {
        Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);
        Task SendAsync(string url, HttpMethod method, object? content = null);
    }
}