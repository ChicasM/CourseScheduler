using System;
using System.Collections.Generic;
using System.IO;
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

namespace CourseScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CourseSchedulerDataSetTableAdapters.CombinationsTableAdapter CombinationsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CourseCombinationsTableAdapter CourseCombinationsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CourseEnrollmentsTableAdapter CourseEnrollmentsTableAdapter;
        CourseSchedulerDataSetTableAdapters.CoursesTableAdapter CoursesTableAdapter;
        CourseSchedulerDataSetTableAdapters.InstructorPreferencesTableAdapter InstructorPreferencesTableAdapter;
        CourseSchedulerDataSetTableAdapters.InstructorsTableAdapter InstructorsTableAdapter;
        CourseSchedulerDataSetTableAdapters.PossibleCoursesTableAdapter PossibleCoursesTableAdapter;
        CourseSchedulerDataSetTableAdapters.RoomsTableAdapter RoomsTableAdapter;
        CourseSchedulerDataSetTableAdapters.StudentsTableAdapter StudentsTableAdapter;
        CourseSchedulerDataSetTableAdapters.TableAdapterManager TableAdapterManager;
        CourseSchedulerDataSetTableAdapters.SchedulesTableAdapter SchedulesTableAdapter;
        CourseSchedulerDataSetTableAdapters.Join_Schedules_PossibleCoursesTableAdapter Join_Schedules_PossibleCoursesTableAdapter;
        CourseSchedulerDataSet DataSet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeDataSet();
        }

        private void InitializeDataSet()
        {
            DataSet = (CourseSchedulerDataSet)FindResource("courseSchedulerDataSet");
            CombinationsTableAdapter = new CourseSchedulerDataSetTableAdapters.CombinationsTableAdapter();
            CombinationsTableAdapter.Fill(DataSet.Combinations);

            CourseCombinationsTableAdapter = new CourseSchedulerDataSetTableAdapters.CourseCombinationsTableAdapter();
            CourseCombinationsTableAdapter.Fill(DataSet.CourseCombinations);

            CourseEnrollmentsTableAdapter = new CourseSchedulerDataSetTableAdapters.CourseEnrollmentsTableAdapter();
            CourseEnrollmentsTableAdapter.Fill(DataSet.CourseEnrollments);

            CoursesTableAdapter = new CourseSchedulerDataSetTableAdapters.CoursesTableAdapter();
            CoursesTableAdapter.Fill(DataSet.Courses);

            InstructorPreferencesTableAdapter = new CourseSchedulerDataSetTableAdapters.InstructorPreferencesTableAdapter();
            InstructorPreferencesTableAdapter.Fill(DataSet.InstructorPreferences);

            InstructorsTableAdapter = new CourseSchedulerDataSetTableAdapters.InstructorsTableAdapter();
            InstructorsTableAdapter.Fill(DataSet.Instructors);

            PossibleCoursesTableAdapter = new CourseSchedulerDataSetTableAdapters.PossibleCoursesTableAdapter();
            PossibleCoursesTableAdapter.Fill(DataSet.PossibleCourses);

            RoomsTableAdapter = new CourseSchedulerDataSetTableAdapters.RoomsTableAdapter();
            RoomsTableAdapter.Fill(DataSet.Rooms);

            StudentsTableAdapter = new CourseSchedulerDataSetTableAdapters.StudentsTableAdapter();
            StudentsTableAdapter.Fill(DataSet.Students);

            Join_Schedules_PossibleCoursesTableAdapter = new CourseSchedulerDataSetTableAdapters.Join_Schedules_PossibleCoursesTableAdapter();
            Join_Schedules_PossibleCoursesTableAdapter.Fill(DataSet.Join_Schedules_PossibleCourses);

            SchedulesTableAdapter = new CourseSchedulerDataSetTableAdapters.SchedulesTableAdapter();
            SchedulesTableAdapter.Fill(DataSet.Schedules);

            TableAdapterManager = new CourseSchedulerDataSetTableAdapters.TableAdapterManager();
            TableAdapterManager.CourseCombinationsTableAdapter = CourseCombinationsTableAdapter;
            TableAdapterManager.CourseEnrollmentsTableAdapter = CourseEnrollmentsTableAdapter;
            TableAdapterManager.CoursesTableAdapter = CoursesTableAdapter;
            TableAdapterManager.InstructorPreferencesTableAdapter = InstructorPreferencesTableAdapter;
            TableAdapterManager.InstructorsTableAdapter = InstructorsTableAdapter;
            TableAdapterManager.PossibleCoursesTableAdapter = PossibleCoursesTableAdapter;
            TableAdapterManager.RoomsTableAdapter = RoomsTableAdapter;
            TableAdapterManager.StudentsTableAdapter = StudentsTableAdapter;
            TableAdapterManager.SchedulesTableAdapter = SchedulesTableAdapter;
            TableAdapterManager.Join_Schedules_PossibleCoursesTableAdapter = Join_Schedules_PossibleCoursesTableAdapter;
        }

        private void UpdateDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TableAdapterManager.UpdateAll(DataSet);
                MessageBox.Show("Database Updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            courses.Content = "File Location";
            courses_Loaded.Visibility = Visibility.Hidden;

            string courseLocation = Load_CSV();

            courses.Content = courseLocation;

            if (courses.Content.ToString() != "File Location")
            {
                courses_Loaded.Visibility = Visibility.Visible;
            }
        }

        public string Load_CSV()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.csv)|*.csv";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Read_CSV(filename);
                return filename;
            }
            return "File Location";
        }

        public void Read_CSV(string fileLocation)
        {
            using (var reader = new StreamReader(fileLocation))
            {            

                    //Add File To DataBase
                    if (fileLocation.Contains("Courses")){
                    while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            DataSet.Courses.AddCoursesRow(Convert.ToInt32(values[0]), values[1], Convert.ToInt32(values[2]),
                                Convert.ToBoolean(Convert.ToInt32(values[3])), Convert.ToBoolean(Convert.ToInt32(values[4])), Convert.ToBoolean(Convert.ToInt32(values[5])),
                                Convert.ToBoolean(Convert.ToInt32(values[6])), values[7], Convert.ToInt32(values[8]));
                        }
                    }
                    if (fileLocation.Contains("Instructors"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        DataSet.Instructors.AddInstructorsRow(Convert.ToInt32(values[0]), values[1]);
                    }

                }
                    if (fileLocation.Contains("Students"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        DataSet.Students.AddStudentsRow(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[2]),
                            values[3], Convert.ToInt32(values[4]));
                    }

                }
                    
                    TableAdapterManager.UpdateAll(DataSet);
                }
            }
        }
    }

