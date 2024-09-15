using Moq;
using Poster.Application.Interfaces;
using Poster.Application.Services;
using Poster.Infrastructure.Data;
using MockQueryable;
using MockQueryable.Moq;
using Poster.Domain.Entities;

namespace Poster.Tests.PostTests
{
    public class PostServiceTest
    {
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

            var data = TestData.GetPosts();
            var mock = data.BuildMock().BuildMockDbSet();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(x => x.Posts).Returns(mock.Object);
            var service = new PostService(mockContext.Object);

            //act
            await service.Edit(model);
            var post = await service.Get(1, 0);

            //assert
            Assert.Equal(model.Title, post[0].Title);
            Assert.Equal(model.Body, post[0].Body);
            Assert.Equal(model.IsRead, post[0].IsRead);
        }

        [Fact]
        public async Task GetAllPosts()
        {
            //arrange
            int limit = 0;
            int lastId = 0;
            var data = TestData.GetPosts();
            var mock = data.BuildMock().BuildMockDbSet();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(x => x.Posts).Returns(mock.Object);
            var service = new PostService(mockContext.Object);

            //act
            var posts = await service.Get(limit, lastId);

            //assert
            Assert.Equal(data.Count, posts.Count);
        }

        [Fact]
        public async Task GetPosts_by_pagination()
        {
            //arrange
            int limit = 100;
            int lastId = 10;
            var data = TestData.GetPosts();
            var mock = data.BuildMock().BuildMockDbSet();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(x => x.Posts).Returns(mock.Object);
            var service = new PostService(mockContext.Object);

            //act
            var posts = await service.Get(limit, lastId);

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
            var data = TestData.GetPosts();
            var mock = data.BuildMock().BuildMockDbSet();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(x => x.Posts).Returns(mock.Object);
            var service = new PostService(mockContext.Object);

            //act
            var posts = await service.Get(limit, lastId);

            //assert
            Assert.Empty(posts);
        }
    }
}
