using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace QR_Code_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void _BTN_Encode_Click(object sender, RoutedEventArgs e)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(_TB_Encode_Input.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            _IMG_Preview.Source = Convert(qrCodeImage); 
        }

        private void _BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Takes a bitmap and converts it to an image that can be handled by WPF ImageBrush
        /// </summary>
        /// <param name="src">A bitmap image</param>
        /// <returns>The image as a BitmapImage for WPF</returns>
        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

    }
}
