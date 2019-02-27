using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    class Task
    {
        public enum CATEGORY { Home, Work, School, Leisure };
        public CATEGORY taskCategory;
        //title, description, category
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description, CATEGORY category)
        {
            Title = title;
            Description = description;
            taskCategory = category;
        }
    }
}
