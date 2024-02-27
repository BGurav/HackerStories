using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerStories.DAL.DataContext;
using HackerStories.DAL.Entities;
using HackerStories.DAL.Interface;

namespace HackerStories.DAL.Repositories
{
    public class StoryRepository : Repository<Story>,IStoryRepository
    {
        private readonly StoryDbContext _storyDbContext;
        public StoryRepository(StoryDbContext storyDbContext) : base(storyDbContext)  
        {
            _storyDbContext = storyDbContext;
        }
        
    }
}
