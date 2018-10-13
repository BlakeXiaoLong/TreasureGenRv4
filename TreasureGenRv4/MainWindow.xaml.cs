using System;
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
            ScrollBuilder s = new ScrollBuilder();
            PotionBuilder p = new PotionBuilder();
            WandBuilder w = new WandBuilder();
            Treasure t0 = s.GetResult();
            Treasure t1 = p.GetResult();
            Treasure t2 = w.GetResult();
        }
    }
}