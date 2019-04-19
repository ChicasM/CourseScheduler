using System.Windows;
using System.Windows.Controls;

namespace CourseScheduler
{
    /// <summary>
    /// Interaction logic for NewCombinationsControl.xaml
    /// </summary>
    public partial class AddCombinationControl : UserControl
    {
        DataBaseHandler dataBaseHandler;
        public AddCombinationControl(DataBaseHandler dbHandler)
        {
            dataBaseHandler = dbHandler;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string logicalOperator;
            if (Or.IsChecked == true) { logicalOperator = "OR"; }
            else { logicalOperator = "AND"; }
            dataBaseHandler.InsertNewCombination(logicalOperator);
            Window.GetWindow(this).Close();
        }
    }
}
