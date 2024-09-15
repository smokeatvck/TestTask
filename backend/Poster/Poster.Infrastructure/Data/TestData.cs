using Poster.Domain.Entities;

namespace Poster.Infrastructure.Data
{
    /// <summary>
    /// Стартовые данные
    /// </summary>
    public static class TestData
    {
        private static Random random = new Random();

        /// <summary>
        /// Сгенерировать посты
        /// </summary>
        /// <returns></returns>
        public static List<Post> GetPosts()
        {
            var result = new List<Post>();

            for (int i = 1; i <= 1500; i++)
            {
                result.Add(new Post
                {
                    Id = i,
                    Title = $"Заголовок {i}",
                    Body = RandomString(200),
                    IsRead = random.Next(2) == 0
                });
            }

            return result;
        }

        private static string RandomString(int length)
        {
            const string chars = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
