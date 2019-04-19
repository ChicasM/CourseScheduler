using System.Windows;
using System.Windows.Controls;

namespace CourseScheduler.Custom_Controls
{
    /// <summary>
    /// Interaction logic for AddCourseEnrollmentControl.xaml
    /// </summary>
    public partial class AddCourseEnrollmentControl : UserControl
    {
        DataBaseHandler dataBaseHandler;
        CourseSchedulerDBDataSet.StudentsRow Student;
        CourseSchedulerDBDataSet.CoursesRow Course;

        public AddCourseEnrollmentControl(DataBaseHandler dbHandler)
        {
            dataBaseHandler = dbHandler;
            InitializeComponent();
        }

        private void SetStudent(ComboBox comboBox)
        {
            //Student = (CourseSchedulerDBDataSet.StudentsRow)comboBox.SelectedItem;
        }

        private void SetCourse(ComboBox comboBox)
        {
            //Course = (CourseSchedulerDBDataSet.CoursesRow)comboBox.SelectedItem;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetStudent((ComboBox)sender);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SetCourse((ComboBox)sender);
        }

        private void CreateEnrollment_Click(object sender, RoutedEventArgs e)
        {
            if (Student == null || Course == null)
                MessageBox.Show("You must select a student and a course to make an erollment.", "Error", MessageBoxButton.OK);
            else if (CreditType.Text == null || Grade.Text == null || CompletionStatus.Text == null)
                MessageBox.Show("Entries must not be null.", "Error", MessageBoxButton.OK);
            else
            {
                dataBaseHandler.InsertNewCourseEnrollment(Student, Course, CreditType.Text, CompletionStatus.Text, Grade.Text);
                Window.GetWindow(this).Close();
            }
        }
    }
}
