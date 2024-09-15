using Poster.Domain.Entities;

namespace Poster.Application.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса постов
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Получить посты
        /// </summary>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="lastId">Идентификатор последней возвращаемой записи</param>
        /// <returns>Список постов</returns>
        Task<List<Post>> Get(int limit, int lastId);
        /// <summary>
        /// Редактировать пост
        /// </summary>
        /// <param name="post">Модель поста</param>
        /// <returns>Успешно/Неуспешно</returns>
        Task<bool> Edit(Post post);
    }
}
