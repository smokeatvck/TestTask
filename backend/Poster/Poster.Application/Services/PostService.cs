using Microsoft.EntityFrameworkCore;
using Poster.Application.Exceptions;
using Poster.Application.Interfaces;
using Poster.Domain.Entities;

namespace Poster.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IApplicationDbContext _db;

        public PostService(IApplicationDbContext db) { 
            _db = db;
        }

        public async Task<bool> Edit(Post post)
        {
            try
            {
                var model = await _db.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
                if (model == null)
                {
                    throw new AppException($"Запись с идентификатором ${post.Id} не найдена", $"Запись не найдена");
                }

                model.IsRead = post.IsRead;
                model.Title = post.Title;
                model.Body = post.Body;

                var response = await _db.SaveChangesAsync();

                return response > 0;
            }
            catch (AppException ex)
            {
                throw;
            }
            catch (Exception ex) {
                throw new AppException(ex.Message, $"Не удалось изменить запись {post.Title}");
            }
        }

        public async Task<List<Post>> Get(int limit, int lastId)
        {
            try
            {
                if (limit == 0) { 
                    limit = int.MaxValue;
                }

                var posts = await _db.Posts.OrderBy(x => x.Id).Where(x => x.Id > lastId).Take(limit).ToListAsync();
                return posts;
            }
            catch (Exception ex) {
                throw new AppException(ex.Message, "Возникла ошибка при получении записей");
            }
        }
    }
}
