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

namespace pour_sae
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationData applicationData;
        public MainWindow()
        {
            this.applicationData = new ApplicationData();
            InitializeComponent();
            // this.DataContext = applicationData; // a faire en XAML pour avoir la complétion sur les binding
            
        }
    }
}
