using Microsoft.EntityFrameworkCore;
using Poster.Domain.Entities;

namespace Poster.Application.Interfaces
{
    /// <summary>
    /// Интерфейс контекста приложения
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Набор постов, хранящиеся в базе данных
        /// </summary>
        DbSet<Post> Posts { get; set; }
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
