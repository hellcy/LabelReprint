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
using System.Collections;

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
                    //default label printer
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
                // In PDF we use user unit as the measurement, 1 cm = 28.34 user units. So to create a 30 cm by 4 cm page we need below sizes.
                var pgSize = new iTextSharp.text.Rectangle(878, 141);

                Document pdfdoc = new Document(pgSize); // Setting the page size for the PDF
                PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/" + createPDFColorList.Text + ".pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                pdfdoc.Open(); // Opening the PDF to write the data from the textbox

                CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                System.Drawing.Image QRcodeImage = QRcode.Draw(createPDFNameText.Text + " / " + createPDFColorList.Text + " " + sizeText.Text + " MM", 100);
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(QRcodeImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                pic.ScaleAbsolute(90, 90);
                pic.SetAbsolutePosition(20F, 25F);

                pdfdoc.Add(pic);
                PdfContentByte cb = writer.DirectContent;
                // we tell the ContentByte we're ready to draw text
                cb.BeginText();

                // set up Font and Size for Content to be shown in PDF
                BaseFont mybf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(mybf, 70);

                // we draw some text on a certain position
                cb.SetTextMatrix(310, 70);
                cb.ShowText(createPDFColorList.Text);


                cb.SetFontAndSize(mybf, 50);
                cb.SetTextMatrix(250, 30);
                cb.ShowText(createPDFNameText.Text);

                cb.SetFontAndSize(mybf, 90);
                cb.SetTextMatrix(710, 40);
                cb.ShowText(sizeText.Text);
                // we tell the contentByte, we've finished drawing text
                cb.EndText();
                //var test = pdfdoc.Add(new Paragraph("my timestamp"));

                iTextSharp.text.Rectangle pageBorderRect = new iTextSharp.text.Rectangle(pgSize);

                pageBorderRect.Left += (pdfdoc.LeftMargin - 22);
                pageBorderRect.Right -= (pdfdoc.RightMargin - 22);
                pageBorderRect.Top -= (pdfdoc.TopMargin - 22);
                pageBorderRect.Bottom += (pdfdoc.BottomMargin - 22);
                pageBorderRect.BorderWidth = 6;

                cb.SetColorStroke(BaseColor.GRAY);
                cb.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                cb.Stroke();
                pdfdoc.Close();

                //MessageBox.Show("PDF Generation Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreatePDFButtonForRackLocation_Click(object sender, EventArgs e)
        {
            try
            {
                for (int numberOfTray = 1; numberOfTray <= 20; numberOfTray++)
                {
                    for (int numberOfRow = 1; numberOfRow <= 4; numberOfRow++)
                    {
                        for (int numberOfColumn = 1; numberOfColumn <= 3; numberOfColumn++)
                        {
                            string path = Application.StartupPath;
                            // In PDF we use user unit as the measurement, 1 cm = 28.34 user units. So to create a 30 cm by 4 cm page we need below sizes.
                            var pgSize = new iTextSharp.text.Rectangle(156, 567);
                            Document pdfdoc = new Document(pgSize); // Setting the page size for the PDF
                            PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/RackLocation/SM_" + numberOfTray + "_R" + numberOfRow + "_C" + numberOfColumn + ".pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                            pdfdoc.Open(); // Opening the PDF to write the data from the textbox

                            CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                            System.Drawing.Image QRcodeImage = QRcode.Draw("SM_" + numberOfTray + "_R" + numberOfRow + "_C" + numberOfColumn, 100);
                            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(QRcodeImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pic.ScaleAbsolute(120, 120); // QR code size
                            pic.SetAbsolutePosition(20F, 420F); // QR code position

                            pdfdoc.Add(pic);
                            PdfContentByte cb = writer.DirectContent;
                            // we tell the ContentByte we're ready to draw text
                            cb.BeginText();

                            // set up Font and Size for Content to be shown in PDF
                            BaseFont mybf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            cb.SetFontAndSize(mybf, 80);

                            // we draw some text on a certain position
                            cb.SetTextMatrix(20, 340);
                            cb.ShowText("SM");

                            if (numberOfTray < 10)
                            {
                                cb.SetTextMatrix(30, 260);
                                cb.ShowText("0" + numberOfTray.ToString());
                            }
                            else
                            {
                                cb.SetTextMatrix(30, 260);
                                cb.ShowText(numberOfTray.ToString());
                            }

                            cb.SetTextMatrix(30, 180);
                            cb.ShowText("R" + numberOfRow);

                            cb.SetTextMatrix(30, 100);
                            cb.ShowText("C" + numberOfColumn);

                            // we tell the contentByte, we've finished drawing text
                            cb.EndText();

                            iTextSharp.text.Rectangle pageBorderRect = new iTextSharp.text.Rectangle(pgSize);

                            pageBorderRect.Left += (pdfdoc.LeftMargin - 22);
                            pageBorderRect.Right -= (pdfdoc.RightMargin - 22);
                            pageBorderRect.Top -= (pdfdoc.TopMargin - 22);
                            pageBorderRect.Bottom += (pdfdoc.BottomMargin - 22);
                            pageBorderRect.BorderWidth = 6;

                            cb.SetColorStroke(BaseColor.GRAY);
                            cb.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                            cb.Stroke();
                            pdfdoc.Close();
                        }
                    }
                }

                //MessageBox.Show("PDF Generation Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateMasterCoilPDFButton_Click(object sender, EventArgs e)
        {
            char[] delimiters = { ' ', ',' };
            string COILID, TYPE = "", COLOR, GAUGE, WIDTH;
            int WEIGHT;

            if ((System.IO.File.Exists(@"C:\Coil master 28-02-2019.csv")) == true)
            {
                int pageNumber = 1;
                int fileNumber = 0;
                int i = 0; // number of columns
                int j = 0; // number of rows
                ArrayList lines = new ArrayList();

                foreach (string line in System.IO.File.ReadLines(@"C:\Coil master 28-02-2019.csv"))
                {
                    lines.Add(line);
                }

                int totalFiles = (int)Math.Ceiling((double)lines.Count / 50);

                for (; fileNumber < totalFiles; fileNumber++)
                {
                    j = 0; // reset the number of rows for each new document
                    string path = Application.StartupPath;
                    var pgSize = new iTextSharp.text.Rectangle(2976, 4194);

                    Document pdfdoc = new Document(pgSize); // Setting the page size for the PDF
                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/MasterCoils/" + (1 + (50 * fileNumber)) + "-" + (50 + (fileNumber * 50)) + ".pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                    pdfdoc.Open(); // Opening the PDF to write the data from the textbox

                    int maxRows = 50;
                    if (fileNumber == totalFiles - 1) maxRows = lines.Count - (50 * fileNumber) - 1;

                    // cannot write into new pdf
                    foreach (string line in lines.GetRange(1 + (fileNumber * 50), maxRows))
                    {
                        try
                        {
                            string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter ','

                            COILID = inputArray[0];
                            TYPE = inputArray[1];
                            COLOR = inputArray[2];
                            WEIGHT = Int32.Parse(inputArray[3]);
                            GAUGE = inputArray[4];
                            WIDTH = inputArray[5];

                            CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                            System.Drawing.Image QRcodeImage = QRcode.Draw(COILID + "+" + TYPE + "+" + COLOR + "+" + WEIGHT + "+" + GAUGE + "+" + WIDTH, 100);
                            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(QRcodeImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pic.ScaleAbsolute(90, 90);
                            pic.SetAbsolutePosition(20 + (595 * i), (419 * (9 - j)) + 300);

                            Code128BarcodeDraw barcode128 = BarcodeDrawFactory.Code128WithChecksum; // to generate barcode
                            System.Drawing.Image BarcodeImage = barcode128.Draw(COILID + "+" + TYPE + "+" + COLOR + "+" + WEIGHT + "+" + GAUGE + "+" + WIDTH, 100);
                            iTextSharp.text.Image pic2 = iTextSharp.text.Image.GetInstance(BarcodeImage, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pic2.ScaleAbsolute(310, 90);
                            pic2.SetAbsolutePosition(250 + (595 * i), (419 * (9 - j)) + 300);

                            pdfdoc.Add(pic);
                            pdfdoc.Add(pic2);
                            PdfContentByte cb = writer.DirectContent;
                            // we tell the ContentByte we're ready to draw text
                            cb.BeginText();

                            // set up Font and Size for Content to be shown in PDF
                            BaseFont mybf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                            cb.SetFontAndSize(mybf, 15);
                            cb.SetTextMatrix(250 + (595 * i), (419 * (9 - j)) + 280);
                            cb.ShowText(COILID + "+" + TYPE + "+" + COLOR + "+" + WEIGHT + "+" + GAUGE + "+" + WIDTH);

                            cb.SetFontAndSize(mybf, 45);
                            if (COLOR.Length == 4)
                            {
                                cb.SetTextMatrix(120 + (595 * i), (419 * (9 - j)) + 350);

                            }
                            else cb.SetTextMatrix(135 + (595 * i), (419 * (9 - j)) + 350);
                            cb.ShowText(COLOR);

                            cb.SetFontAndSize(mybf, 35);
                            cb.SetTextMatrix(160 + (595 * i), (419 * (9 - j)) + 320);
                            cb.ShowText(TYPE);

                            cb.SetFontAndSize(mybf, 25);
                            cb.SetTextMatrix(130 + (595 * i), (419 * (9 - j)) + 300);
                            string month_year = DateTime.Now.ToString("MMM").ToUpper() + "_" + DateTime.Now.ToString("yy");
                            cb.ShowText(month_year);

                            cb.SetFontAndSize(mybf, 150);
                            cb.SetTextMatrix(120 + (595 * i), (419 * (9 - j)) + 150);
                            cb.ShowText(COLOR);

                            cb.SetFontAndSize(mybf, 100);
                            cb.SetTextMatrix(140 + (595 * i), (419 * (9 - j)) + 50);
                            cb.ShowText(TYPE);

                            // we tell the contentByte, we've finished drawing text
                            cb.EndText();

                            // A5 size: 21cm x 14.8cm, (595, 419)
                            var A5Size = new iTextSharp.text.Rectangle(15 + (595 * i), (419 * (9 - j)) + 15, 580 + (595 * i), (419 * (9 - j)) + 404);
                            iTextSharp.text.Rectangle pageBorderRect = new iTextSharp.text.Rectangle(A5Size);

                            pageBorderRect.BorderWidth = 6;
                            i++;
                            if (i == 5)
                            {
                                j++;
                                i = 0;
                            }
                            pageNumber++;
                            cb.SetColorStroke(BaseColor.GRAY);
                            cb.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                            cb.Stroke();

                        }
                        catch (Exception ex)
                        {
                            ErrMsg.Text = "Input format is not corrent!" + ex.Message;
                            COILID = null;
                            TYPE = null;
                            COLOR = null;
                            WEIGHT = 0;
                            GAUGE = null;
                            WIDTH = null;
                            return;
                        }
                    }
                    pdfdoc.Close();
                }

            }
        }
    }
}



