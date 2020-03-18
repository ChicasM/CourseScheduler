﻿using System;
using System.Collections.Generic;
using System.Data;
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
        DataBaseHandler dataBaseHandler;

        public MainWindow()
        {
            InitializeComponent();
            DataBaseHandler = new DataBaseHandler();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataBaseHandler.FillAdaptersWithDataSet();
            DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_StudentsTableAdapter.GetData();

            GrdReport.ItemsSource = DataBaseHandler.NoRelation_SchedulesTableAdapter.GetData();
        }

        private void UpdateDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseHandler.FillAdaptersWithDataSet();
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
                Read_CSV(dlg.FileName);
                return dlg.FileName;
            }
            return "File Location";
        }

        public void Read_CSV(string fileLocation)
        {
            using (var reader = new StreamReader(fileLocation))
            {
                //Add File To DataBase
                if (fileLocation.Contains("Courses"))
                {
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');
                        // String, Int, Bool, Bool, Bool, Bool, String, Int
                        insertNewCourse(values);

                    }
                }

                if (fileLocation.Contains("Instructors"))
                {
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');
                        DataBaseHandler.InsertNewInstructor(values[0]);
                    }
                }

                if (fileLocation.Contains("Students"))
                {
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');
                        DataBaseHandler.InsertNewStudent(values[0], values[1], values[2], values[3], Convert.ToInt32(values[4]));
                    }
                }

                if (fileLocation.Contains("Rooms"))
                {
                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split(',');
                        DataBaseHandler.InsertNewRoom(values[0], Convert.ToBoolean(Convert.ToInt32(values[1])), Convert.ToBoolean(Convert.ToInt32(values[2])));
                    }
                }
            }
        }

        private void insertNewCourse(string[] values)
        {
            DataBaseHandler.InsertNewCourse(values[0], Convert.ToInt32(values[1]), Convert.ToBoolean(Convert.ToInt32(values[2])),
                                                                    Convert.ToBoolean(Convert.ToInt32(values[3])), Convert.ToBoolean(Convert.ToInt32(values[4])),
                                                                    Convert.ToBoolean(Convert.ToInt32(values[5])), values[6], Convert.ToInt32(values[7]));
        }

        private string DbTableItem => TableSelector.SelectionBoxItem.ToString();

        public DataBaseHandler DataBaseHandler { get => dataBaseHandler; set => dataBaseHandler = value; }

        private void UpdateTable()
        {
            switch (DbTableItem)
            {
                case "Combinations":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_CombinationsTableAdapter.GetData();
                    break;
                case "CourseCombinations":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_CourseCombinationsTableAdapter.GetData();
                    break;
                case "CourseEnrollments":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_CourseEnrollmentsTableAdapter.GetData();
                    break;
                case "Courses":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_CoursesTableAdapter.GetData();
                    break;
                case "InstructorPreferences":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_InstructorPreferencesTableAdapter.GetData();
                    break;
                case "Instructors":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_InstructorsTableAdapter.GetData();
                    break;
                case "Join_Schedules_PossibleCourses":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_Join_Schedules_PossibleCoursesTableAdapter.GetData();
                    break;
                case "PossibleCourses":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_PossibleCoursesTableAdapter.GetData();
                    break;
                case "Rooms":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_RoomsTableAdapter.GetData();
                    break;
                case "Schedules":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_SchedulesTableAdapter.GetData();
                    break;
                case "Students":
                    DataGrid_DbTable.ItemsSource = DataBaseHandler.NoRelation_StudentsTableAdapter.GetData();
                    break;
                default:
                    break;
            }
        }

        private void TableSelector_DropDownClosed(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void AddNewItem_Click(object sender, RoutedEventArgs e)
        {
            DbItemCreationWindow dbItemCreationWindow = new DbItemCreationWindow(DbTableItem, DataBaseHandler);
            dbItemCreationWindow.ShowDialog();
            UpdateTable();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            grpControls.Visibility = Visibility.Hidden;

            GrdReport.ItemsSource = DataBaseHandler.NoRelation_SchedulesTableAdapter.GetData();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            SwapToDetailed();
            grpControls.Visibility = Visibility.Visible;
        }

        private void SwapToDetailed()
        {
            DataTable tbl;

            tbl = DataBaseHandler.GetPossibleCourses(1);

            List<int> ids = new List<int>();

            foreach(DataRow row in tbl.Rows)
            {
                ids.Add(Convert.ToInt32(row[1]));
            }

            var results = from myRow in tbl.AsEnumerable()
                          where ids.Contains(myRow.Field<int>("PossibleCourseID"))
                          select myRow;

            GrdReport.ItemsSource = results;
        }
    }
}

