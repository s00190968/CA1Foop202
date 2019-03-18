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
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    { 
        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void AddTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Owner;

            string title = TitleTxBx.Text;
            string description = DescriptionTxBx.Text;
            int cat = CategoryCmbx.SelectedIndex;
            int pr = PriorityCmbx.SelectedIndex;
            DateTime due = DueDatePicker.SelectedDate.Value;
            string person = PersonChargeTxBx.Text;

            CATEGORY chosenCat = main.TM.getCategory(cat);
            PRIORITY_TYPES chosePr = main.TM.getPriority(pr);

            string[] labels = LabelsTxBx.Text.Split(' ');

            main.TM.AddTask(title, description, chosenCat, chosePr, due, person, labels);

            this.Close();
        }

        private void CancelTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
