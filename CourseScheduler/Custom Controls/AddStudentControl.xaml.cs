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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseScheduler.Custom_Controls
{
    /// <summary>
    /// Interaction logic for AddStudentControl.xaml
    /// </summary>
    public partial class AddStudentControl : UserControl
    {
        DataBaseHandler dataBaseHandler;
        public AddStudentControl(DataBaseHandler dbHandler)
        {
            InitializeComponent();
            dataBaseHandler = dbHandler;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StudentName.Text == null || Cohort.Text == null || GraduationStatus.Text == null || Major.Text == null || CreditsFinished.Text == null)
                MessageBox.Show("You must enter all fields.", "Error", MessageBoxButton.OK);
            else if (!int.TryParse(CreditsFinished.Text, out int cred))
                MessageBox.Show("Error parsing credits, it must be an interger.", "Error", MessageBoxButton.OK);
            else
            {
                dataBaseHandler.InsertNewStudent(StudentName.Text, Cohort.Text, GraduationStatus.Text, Major.Text, cred);
                Window.GetWindow(this).Close();
            }
        }
    }
}
