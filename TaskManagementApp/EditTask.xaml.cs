using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManagementApp
{
    /// <summary>
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public EditTask()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;

            RealTask temp = main.selectedTask;
            TitleTxBx.Text = temp.Title;
            DescriptionTxBx.Text = temp.Description;
            CategoryCmbx.SelectedIndex = (int)temp.taskCategory;
            PriorityCmbx.SelectedIndex = (int)temp.Priority;
            DueDatePicker.SelectedDate = temp.DueDate;
            PersonChargeTxBx.Text = temp.PersonInCharge;
        }

        private void SaveTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;

            string title = TitleTxBx.Text;
            string description = DescriptionTxBx.Text;
            int cat = CategoryCmbx.SelectedIndex;
            int pr = PriorityCmbx.SelectedIndex;
            DateTime due = DueDatePicker.SelectedDate.Value;
            string person = PersonChargeTxBx.Text;

            string[] labels = LabelsTxBx.Text.Split(' ');

            CATEGORY chosenCat = main.TM.getCategory(cat);
            PRIORITY_TYPES chosenPr = main.TM.getPriority(pr);

            main.TM.EditTask(main.selectedTask, title, description, chosenCat, chosenPr, due, person);
            main.TM.addLabelsToTask(main.selectedTask, labels);

            this.Close();
        }

        private void CancelTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
