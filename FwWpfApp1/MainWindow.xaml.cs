using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FwWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var allocatedBytesForCurrentThread = GC.GetTotalMemory(true);

            var src1x1 = BitmapSource.Create(1, 1, 72, 72, PixelFormats.BlackWhite, BitmapPalettes.BlackAndWhite, new byte[] { 0x44 }, 1);
            var src = new TransformedBitmap(src1x1, new ScaleTransform(2000, 2000));// here I get Exception
            cnvMain.Background = new ImageBrush(src);// cnvMain = Canvas

            var allocatedBytesForCurrentThreadAfter = GC.GetTotalMemory(true);

            debug.Content = $"Delta: {(allocatedBytesForCurrentThreadAfter - allocatedBytesForCurrentThread):D} B allocated";
        }
    }
}
