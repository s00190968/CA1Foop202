using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    class TaskManager
    {
        ObservableCollection<RealTask> allTasks;
        ObservableCollection<RealTask> filteredTasks;
        ObservableCollection<RealTask> completedTasks;

        public void AddTask(string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate, string personInCharge)
        {
            allTasks.Add(new RealTask(title, description, category, priority, dueDate, personInCharge));
        }

        public void DeleteTask()
        {

        }

        public void EditTask()
        {

        }

        #region task filtering
        ObservableCollection<RealTask> FilterTasks(DateTime date)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if the date is same as date in task
                if (t.DueDate == date)
                {
                    temp.Add(t);
                }
            }

            return temp;
        }

        ObservableCollection<RealTask> FilterTasks(CATEGORY category)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if the date is same as date in task
                if (t.taskCategory == category)
                {
                    temp.Add(t);
                }
            }

            return temp;
        }

        ObservableCollection<RealTask> FilterTasks(PRIORITY_TYPES priority)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if the date is same as date in task
                if (t.Priority == priority)
                {
                    temp.Add(t);
                }
            }

            return temp;
        }
        #endregion
    }
}