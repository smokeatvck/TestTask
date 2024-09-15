using Newtonsoft.Json;
using Poster.Domain.Entities;
using System.Net;
using System.Text;

namespace Poster.Tests.PostTests
{
    public class PostAPITest
    {
        private readonly HttpClient _httpClient = new HttpClient();

        [Fact]
        public async Task EditPost_sucessfull()
        {
            //arrange
            var model = new Post
            {
                Id = 1,
                Title = "Заголовок измененный",
                Body = "BodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBody",
                IsRead = true
            };

            string path = $"http://localhost:5000/api/posts/edit";
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //act
            var response = await _httpClient.PutAsync(path, content);
            var dataStr = await response.Content.ReadAsStringAsync();
            bool data = JsonConvert.DeserializeObject<bool>(dataStr);

            //assert
            Assert.True(data);
        }

        [Fact]
        public async Task EditPost_title_isEmpty_shoud_error()
        {
            //arrange
            var model = new Post
            {
                Id = 1,
                Title = string.Empty,
                Body = "BodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBodyBody",
                IsRead = true
            };

            string path = $"http://localhost:5000/api/posts/edit";
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //act
            var response = await _httpClient.PutAsync(path, content);

            //assert
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetAllPosts()
        {
            //arrange
            string path = $"http://localhost:5000/api/posts/get";

            //act
            var response = await _httpClient.GetAsync(path);
            var json = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            //assert
            Assert.True(posts.Count > 1000);
        }

        [Fact]
        public async Task GetPosts_by_pagination()
        {
            //arrange
            int limit = 100;
            int lastId = 10;
            string path = $"http://localhost:5000/api/posts/get?limit={limit}&lastId={lastId}";

            //act
            var response = await _httpClient.GetAsync(path);
            var json = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            //assert
            Assert.Equal(13, posts[2].Id);
            Assert.Equal(100, posts.Count);
        }

        [Fact]
        public async Task GetPosts_by_pagination_should_empty()
        {
            //arrange
            int limit = 100;
            int lastId = 100000;
            string path = $"http://localhost:5000/api/posts/get?limit={limit}&lastId={lastId}";

            //act
            var response = await _httpClient.GetAsync(path);
            var json = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(json);

            //assert
            Assert.Empty(posts);
        }
    }
}
