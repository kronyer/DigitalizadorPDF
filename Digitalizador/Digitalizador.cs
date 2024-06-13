using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;
using WIA;

namespace Digitalizador
{
    public partial class Digitalizador : Form
    {

        public Digitalizador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceManager = new DeviceManager();
                Device scanner = null;

                for (int i = 0; i < deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                    {
                        scanner = deviceManager.DeviceInfos[i].Connect();
                        break;
                    }
                }

                if (scanner != null)
                {
                    var item = scanner.Items[0];
                    var imgFile = (ImageFile)item.Transfer(FormatID.wiaFormatJPEG);

                    var tempFilePath = Path.GetTempFileName();
                    File.Delete(tempFilePath);
                    var filePath = Path.ChangeExtension(tempFilePath, "jpg");
                    imgFile.SaveFile(filePath);

                    var image = Image.FromFile(filePath);
                    pictureBox1.Image = image;

                    // Abrir diálogo para escolher o caminho do arquivo PDF
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show($"Arquivo salvo em: {filePath}");
            }
        }
    }
}
