using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaBackendNet.DTOs;
using PracticaBackendNet.Services;

namespace PracticaBackendNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService _titlesService;
        public PostsController(IPostService postService)
        {
            _titlesService = postService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _titlesService.Get();
    }
}
