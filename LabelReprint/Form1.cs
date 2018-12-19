using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LabelReprint
{
    public partial class LabelPrinter : Form
    {
        public LabelPrinter()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
            System.Drawing.Image QRcodeImage = QRcode.Draw(coilID.Text, 100);
            // RectangleF(The coordinates of the upper-left corner of the rectangle, width, height)
            RectangleF QRcodeRect = new RectangleF(50.0F, 40.0F, 150.0F, 150.0F);
            g.DrawImage(QRcodeImage, QRcodeRect);

            BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
            System.Drawing.Image barcodeImage = bdraw.Draw(coilID.Text, 100);
            RectangleF barcodeRect = new RectangleF(250.0F, 40.0F, 400.0F, 100.0F);
            g.DrawImage(barcodeImage, barcodeRect);

            // Create string to draw.
            String drawString = coilID.Text;

            // Create font and brush.
            System.Drawing.Font drawFont = new System.Drawing.Font("Times New Roman", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = 250.0F;
            float y = 150.0F;
            g.DrawString(drawString, drawFont, drawBrush, x, y);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (coilID.Text != "")
            {
                ErrMsg.Text = "";
                string printer = "";
                if (otherPrinterName.Text != "")
                {
                    printer = otherPrinterName.Text;
                }
                else
                {
                    printer = "ZDesigner S4M-203dpi ZPL";
                }
                //Printing(printer);
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                ErrMsg.Text = "Please Enter an ID.";
                ErrMsg.ForeColor = Color.Red;
                ErrMsg.Font = new System.Drawing.Font("Times New Roman", 20);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        public void Printing(string printer)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.PrinterSettings.PrinterName = printer;

                if (pd.PrinterSettings.IsValid)
                {
                    pd.Print();
                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.StartupPath;
                // In PDF we use user unit as the measurement, 1 cm = 28.34 user units. So to create a 27 cm by 4 cm page we need below sizes.
                var pgSize = new iTextSharp.text.Rectangle(765, 113);
                Document pdfdoc = new Document(pgSize); // Setting the page size for the PDF

                PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/Sample.pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                pdfdoc.Open(); // Opening the PDF to write the data from the textbox


                CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                System.Drawing.Image QRcodeImage = QRcode.Draw(createPDFText.Text, 100);
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(QRcodeImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(70, 70);
                pic.SetAbsolutePosition(50F, 20F);

                pdfdoc.Add(pic);
                PdfContentByte cb = writer.DirectContent;
                // we tell the ContentByte we're ready to draw text
                cb.BeginText();
                BaseFont mybf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(mybf, 50);

                // we draw some text on a certain position
                cb.SetTextMatrix(160, 40);
                cb.ShowText(createPDFText.Text);
                // we tell the contentByte, we've finished drawing text
                cb.EndText();

                //pdfdoc.Add(new Paragraph(createPDFText.Text)); // Adding the Text to the PDF

                pdfdoc.Close();
                //MessageBox.Show("PDF Generation Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
