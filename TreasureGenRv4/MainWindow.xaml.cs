using System.Windows;

namespace TreasureGenRv4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Generator g = new Generator();
        }
    }
}