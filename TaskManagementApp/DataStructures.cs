using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    public enum PRIORITY_TYPES { Low, Normal, Medium, Urgent, SuperUrgent, HyperUrgent }
    public enum CATEGORY { Home, Work, School, Leisure };

    public class DataStrucutres
    {
        public string[] imgNames;
        public DataStrucutres()
        {
            imgNames = new string[] { "home.jpg", "work.jpg", "school.jpg", "leisure.jpg" };
        }
    }
}