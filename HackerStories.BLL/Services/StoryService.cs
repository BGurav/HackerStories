using HackerStories.BLL.IServices;
using HackerStories.DAL.Entities;
using HackerStories.DAL.Interface;
using Microsoft.Extensions.Logging;

namespace HackerStories.BLL.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        //private readonly IMapper _mapper;
        private readonly ILogger<StoryService> _logger;

        public StoryService(IStoryRepository storyRepository, ILogger<StoryService> logger)
        {
            _storyRepository = storyRepository;
            _logger = logger;
        }

        public async Task<IList<Story>> GetAll()
        {
            _logger.LogInformation("List of Story has been returned");
            return await _storyRepository.GetAllAsync();
        }

        public async Task<Story> GetById(int storyId)
        {
            return await _storyRepository.FindAsync(storyId);
        }
    }
}
