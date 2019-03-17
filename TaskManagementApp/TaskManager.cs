using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskManagementApp
{
    public class TaskManager
    {
        public ObservableCollection<RealTask> allTasks;
        public ObservableCollection<RealTask> filteredTasks;
        public ObservableCollection<RealTask> completedTasks;

        public TaskManager()
        {
            allTasks = new ObservableCollection<RealTask>();
            filteredTasks = new ObservableCollection<RealTask>();
            completedTasks = new ObservableCollection<RealTask>();

            loadDataFromJson();
        }

        public void AddTask(string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate, string personInCharge)
        {
            allTasks.Add(new RealTask(title, description, category, priority, dueDate, personInCharge));
        }

        public void DeleteTask(RealTask task)
        {
            allTasks.Remove(task);
        }

        public void CompeleteTask(RealTask task)
        {
            completedTasks.Add(task);
            DeleteTask(task);
        }

        public void EditTask(RealTask task, string title, string description, CATEGORY category, PRIORITY_TYPES priority, DateTime dueDate, string personInCharge)
        {
            task.Title = title;
            task.Description = description;
            task.taskCategory = category;
            task.Priority = priority;
            task.DueDate = dueDate;
            task.PersonInCharge = personInCharge;
        }

        #region saving and loading json file
        public void saveDataToJson()
        {
            string json = JsonConvert.SerializeObject(allTasks, Formatting.Indented);

            //write to file
            using (StreamWriter sw = new StreamWriter(@"AllTasks.json"))//file should go to the bin folder of the solution
            {
                sw.Write(json);
            }
        }

        public void loadDataFromJson()
        {
            //connect to a file
            using (StreamReader sr = new StreamReader(@"AllTasks.json"))
            {
                //read from file
                string json = sr.ReadToEnd();

                //deserialize json/convert from
                allTasks = JsonConvert.DeserializeObject<ObservableCollection<RealTask>>(json);
            }
        }

        #endregion

        public void addLabelsToTask(Task task, params string[] values)
        {
            foreach (string s in values)
            {
                task.Labels.Add(s);
            }
        }

        #region task filtering
        public ObservableCollection<RealTask> FilterTasks(DateTime date)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if the days are same
                if (t.DueDate.Day == date.Day)
                {
                    temp.Add(t);
                }
                //if years are same
                else if (t.DueDate.Year == date.Year)
                {
                    temp.Add(t);
                }
                //if months are same
                else if (t.DueDate.Month == date.Month)
                {
                    temp.Add(t);
                }
            }

            return temp;
        }

        public ObservableCollection<RealTask> FilterTasks(CATEGORY category)
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

        public ObservableCollection<RealTask> FilterTasks(PRIORITY_TYPES priority)
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
        public ObservableCollection<RealTask> FilterTasks(string label)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if the label is found in labels list of task
                foreach (string l in t.Labels)
                {
                    if (l.Equals(label))
                    {
                        temp.Add(t);
                    }
                }
            }

            return temp;
        }

        #endregion

        #region task searching

        public ObservableCollection<RealTask> SearchTasks(string word)
        {
            ObservableCollection<RealTask> temp = new ObservableCollection<RealTask>();

            foreach (RealTask t in allTasks)
            {
                //if title contains the word
                if (t.Title.Contains(word))
                {
                    temp.Add(t);
                }
                //if labels contain the word
                if (t.Description.Contains(word))
                {
                    temp.Add(t);
                }
                //if description contains the word
                foreach (string s in t.Labels)
                {
                    if (s.Contains(word))
                    {
                        temp.Add(t);
                    }
                }
            }

            return temp;
        }

        #endregion
    }
}
