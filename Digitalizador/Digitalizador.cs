using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using WIA;

namespace Digitalizador
{
    public partial class Digitalizador : Form
    {
        private BackgroundWorker scannerWorker;
        public Digitalizador()
        {
            InitializeComponent();
            LoadScanners();

        }

        private void LoadScanners()
        {
            try
            {
                var deviceManager = new DeviceManager();
                comboBoxScanners.Items.Clear();

                for (int i = 1; i < deviceManager.DeviceInfos.Count; i++)
                {
                    var deviceInfo = deviceManager.DeviceInfos[i];
                    var deviceType = (WiaDeviceType)deviceInfo.Type;
                    var deviceName = deviceInfo.Properties["Name"].get_Value().ToString();

                    if (deviceType == WiaDeviceType.ScannerDeviceType)
                    {
                        comboBoxScanners.Items.Add(deviceName);
                    }
                }

                if (comboBoxScanners.Items.Count > 0)
                {
                    comboBoxScanners.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Nenhum scanner foi encontrado.");
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show($"Erro WIA: {ex.Message} (0x{ex.ErrorCode:X})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxScanners.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um scanner.");
                    return;
                }

                var deviceManager = new DeviceManager();
                Device scanner = null;


                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    var deviceInfo = deviceManager.DeviceInfos[i];
                    var deviceType = (WiaDeviceType)deviceInfo.Type;
                    var deviceName = deviceInfo.Properties["Name"].get_Value().ToString();

                    //log
                    //MessageBox.Show($"Verificando dispositivo {i}: {deviceName} (Tipo: {deviceType})");

                    if (deviceType == WiaDeviceType.ScannerDeviceType && deviceName == comboBoxScanners.SelectedItem.ToString())
                    {
                        scanner = deviceInfo.Connect();
                        break;
                    }
                }

                if (scanner != null)
                {
                    var item = scanner.Items[1];
                    
                    var imgFile = (ImageFile)item.Transfer(FormatID.wiaFormatJPEG);
                    

                    var tempFilePath = Path.GetTempFileName();
                    File.Delete(tempFilePath);
                    var filePath = Path.ChangeExtension(tempFilePath, "jpg");
                    imgFile.SaveFile(filePath);


                    var image = Image.FromFile(filePath);
                    pictureBox1.Image = image;


                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF Files|*.pdf";
                        saveFileDialog.Title = "Save the scanned document as PDF";
                        saveFileDialog.FileName = "scannedDocument.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var pdfPath = saveFileDialog.FileName;
                            SaveImageAsPdf(filePath, pdfPath);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum scanner encontrado.");
                }
            }
            catch (COMException comEx)
            {
                MessageBox.Show($"Erro WIA: {comEx.Message} (0x{comEx.ErrorCode:X})");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro geral: {ex.Message}");
            }
        }
        private void SaveImageAsPdf(string imagePath, string filePath)
        {
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    using (XImage xImage = XImage.FromFile(imagePath))
                    {
                        page.Width = xImage.PixelWidth * 72 / xImage.HorizontalResolution;
                        page.Height = xImage.PixelHeight * 72 / xImage.VerticalResolution;

                        gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);
                    }
                }

                document.Save(filePath);
                labelWherePath.Text = $"{filePath}";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelWherePath.Text))
            {
                MessageBox.Show("Nenhum arquivo foi salvo");
                return;
            }
            Process.Start("explorer.exe", labelWherePath.Text);

        }
    }
}

//teste com arquivo do pc
//try
//{
//    // Simular digitalização carregando uma imagem existente
//    using (OpenFileDialog openFileDialog = new OpenFileDialog())
//    {
//        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
//        openFileDialog.Title = "Select an Image to Simulate Scanning";

//        if (openFileDialog.ShowDialog() == DialogResult.OK)
//        {
//            var imagePath = openFileDialog.FileName;
//            var image = Image.FromFile(imagePath);
//            pictureBox1.Image = image;

//            // Abrir diálogo para escolher o caminho do arquivo PDF
//            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
//            {
//                saveFileDialog.Filter = "PDF Files|*.pdf";
//                saveFileDialog.Title = "Save the scanned document as PDF";
//                saveFileDialog.FileName = "scannedDocument.pdf";

//                if (saveFileDialog.ShowDialog() == DialogResult.OK)
//                {
//                    var pdfPath = saveFileDialog.FileName;
//                    SaveImageAsPdf(imagePath, pdfPath);
//                }
//            }
//        }
//    }
//}
//catch (Exception ex)
//{
//    MessageBox.Show($"Erro ao simular digitalização: {ex.Message}");
//}
