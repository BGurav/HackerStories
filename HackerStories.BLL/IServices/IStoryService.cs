using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerStories.DAL.Entities;

namespace HackerStories.BLL.IServices
{
    public interface IStoryService
    {
        Task<IList<Story>> GetAll();
        Task<Story> GetById(int storyId);
    }
}
