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
