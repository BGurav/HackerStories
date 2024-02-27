
using HackerStories.BLL.IServices;
using HackerStories.DAL.Entities;
using HackerStories.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HackerStories.Test.API
{
    public class StoryControllerTests
    {
        private readonly Mock<IStoryService> mockStoryService;
        public StoryControllerTests()
        {
            mockStoryService = new Mock<IStoryService>();
        }

        [Fact]
        public async Task GetStories_StorisList_ReturnsOk()
        {
            //Arrange
            var storyList = GetStoryData();
            mockStoryService.Setup(x => x.GetAll()).ReturnsAsync(storyList);
            var storyController = new StoryController(mockStoryService.Object);

            // Act
            var response = await storyController.GetStories();
            
            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetStories_WhenServiceNotConnect_ReturnsBadRequest()
        {
            //Arrange
            mockStoryService.Setup(x => x.GetAll()).ThrowsAsync(new Exception());
            var storyController = new StoryController(mockStoryService.Object);

            // Act
            var response = await storyController.GetStories();

            // Assert
            Assert.IsType<BadRequestObjectResult>(response);
        }

        private List<Story> GetStoryData()
        {
            List<Story> storiesData = new List<Story>
        {
            new Story
            {
                Id = 1,
                Title = "Title 1",
                Description= "Description 1",
                Image="image/image1.jpg",
                Url="story/details/1",
                Time= DateTime.Now,
            },
             new Story
            {
                Id = 2,
                Title = "Title 2",
                Description= "Description 2",
                Image="image/image2.jpg",
                Url="story/details/2",
                Time= DateTime.Now,
            },
        };
            return storiesData;
        }
    }
}
