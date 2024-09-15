using Microsoft.AspNetCore.Mvc;
using Poster.Application.Interfaces;
using Poster.Domain.Entities;

namespace Poster.WebApi.Controllers
{
    /// <summary>
    /// Управление постами
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService) { 
            _postService = postService;
        }

        /// <summary>
        /// Изменить пост
        /// </summary>
        /// <param name="post">Модель поста</param>
        /// <returns>Успешно/неуспешно</returns>
        /// <response code="200">true/false</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPut]
        public async Task<ActionResult<bool>> Edit(Post post)
        {
            return await _postService.Edit(post);
        }

        /// <summary>
        /// Получить список постов
        /// </summary>
        /// <param name="limit">Количество постов</param>
        /// <param name="lastId">Идентификатор последнего поста</param>
        /// <returns>Список постов</returns>
        /// <response code="200">Возврат список постов</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> Get(int limit, int lastId)
        {
            return await _postService.Get(limit, lastId);
        }
    }
}
