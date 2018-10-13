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
            ScrollFactory s = new ScrollFactory(RarityTypeEnum.LesserMajor);
            PotionFactory p = new PotionFactory(RarityTypeEnum.GreaterMajor);
            WandFactory w = new WandFactory(RarityTypeEnum.GreaterMinor);
            Treasure t0 = s.GetResult();
            Treasure t1 = p.GetResult();
            Treasure t2 = w.GetResult();
        }
    }
}