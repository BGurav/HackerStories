using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerStories.DAL.Entities;

namespace HackerStories.DAL.Interface
{
    public interface IStoryRepository:IRepository<Story>
    {
        Task<IList<Story>> GetAllAsync();
        
    }
}
