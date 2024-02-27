using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerStories.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackerStories.DAL.DataContext
{
    public class StoryDbContext : DbContext
    {
        public StoryDbContext(DbContextOptions<StoryDbContext> options) : base(options) { }
        
        public DbSet<Story> Stories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().HasData(new Story
            {
                Id = 1,
                Title = "Title 1",
                Description = "Description 1",
                Url = "/story/1",
                Image = "/story-images/hacker-story-uniqueId-1.jpg",
                Time = DateTime.Now,
            }, 
            new Story
            {
                Id = 2,
                Title = "Title 2",
                Description = "Description 2",
                Url = "/story/2",
                Image = "/story-images/hacker-story-uniqueId-2.jpg",
                Time = DateTime.Now,
            });
        }
    }
}
