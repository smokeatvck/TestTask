using System.ComponentModel.DataAnnotations;

namespace Poster.Domain.Entities
{
    /// <summary>
    /// Сущность "Пост"
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор поста
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        [MinLength(3), MaxLength(50)]
        public required string Title { get; set; }
        /// <summary>
        /// Текст поста
        /// </summary>
        [MinLength(50)]
        public required string Body { get; set; }
        /// <summary>
        /// Является ли прочитанным
        /// </summary>
        public bool IsRead { get; set; }
    }
}
