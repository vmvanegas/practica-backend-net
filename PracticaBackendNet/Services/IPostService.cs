using PracticaBackendNet.DTOs;

namespace PracticaBackendNet.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
