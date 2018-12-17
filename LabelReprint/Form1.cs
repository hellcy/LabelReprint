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
            Image QRcodeImage = QRcode.Draw(textBox1.Text, 100);
            // RectangleF(The coordinates of the upper-left corner of the rectangle, width, height)
            RectangleF QRcodeRect = new RectangleF(50.0F, 40.0F, 150.0F, 150.0F);
            g.DrawImage(QRcodeImage, QRcodeRect);

            BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
            Image barcodeImage = bdraw.Draw(textBox1.Text, 100);
            RectangleF barcodeRect = new RectangleF(250.0F, 40.0F, 400.0F, 100.0F);
            g.DrawImage(barcodeImage, barcodeRect);

            // Create string to draw.
            String drawString = textBox1.Text;

            // Create font and brush.
            Font drawFont = new Font("Times New Roman", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            float x = 250.0F;
            float y = 150.0F;
            g.DrawString(drawString, drawFont, drawBrush, x, y);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ErrMsg.Text = "";
                Printing();
                //printPreviewDialog1.ShowDialog();
            }
            else
            {
                ErrMsg.Text = "Please scan an ID.";
                ErrMsg.ForeColor = Color.Red;
                ErrMsg.Font = new Font("Times New Roman", 20);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        public void Printing()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.PrinterSettings.PrinterName = "ZDesigner S4M-203dpi ZPL";
                // Specify the printer to use.

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
    }
}
