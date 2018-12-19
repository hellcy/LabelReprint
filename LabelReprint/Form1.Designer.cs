namespace LabelReprint
{
    partial class LabelPrinter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelPrinter));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printButton = new System.Windows.Forms.Button();
            this.coilID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrMsg = new System.Windows.Forms.Label();
            this.otherPrinterNameLabel = new System.Windows.Forms.Label();
            this.otherPrinterName = new System.Windows.Forms.TextBox();
            this.createPDFText = new System.Windows.Forms.TextBox();
            this.createPDFButton = new System.Windows.Forms.Button();
            this.createPDFLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(243, 30);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(100, 46);
            this.printButton.TabIndex = 0;
            this.printButton.Text = "PRINT";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // coilID
            // 
            this.coilID.Location = new System.Drawing.Point(12, 43);
            this.coilID.Name = "coilID";
            this.coilID.Size = new System.Drawing.Size(225, 20);
            this.coilID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coil ID Scanned";
            // 
            // ErrMsg
            // 
            this.ErrMsg.AutoSize = true;
            this.ErrMsg.Location = new System.Drawing.Point(93, 9);
            this.ErrMsg.Name = "ErrMsg";
            this.ErrMsg.Size = new System.Drawing.Size(0, 13);
            this.ErrMsg.TabIndex = 3;
            // 
            // otherPrinterNameLabel
            // 
            this.otherPrinterNameLabel.AutoSize = true;
            this.otherPrinterNameLabel.Location = new System.Drawing.Point(9, 79);
            this.otherPrinterNameLabel.Name = "otherPrinterNameLabel";
            this.otherPrinterNameLabel.Size = new System.Drawing.Size(256, 13);
            this.otherPrinterNameLabel.TabIndex = 4;
            this.otherPrinterNameLabel.Text = "If print with other printers, please enter the print name";
            // 
            // otherPrinterName
            // 
            this.otherPrinterName.Location = new System.Drawing.Point(12, 95);
            this.otherPrinterName.Name = "otherPrinterName";
            this.otherPrinterName.Size = new System.Drawing.Size(100, 20);
            this.otherPrinterName.TabIndex = 5;
            // 
            // createPDFText
            // 
            this.createPDFText.Location = new System.Drawing.Point(12, 159);
            this.createPDFText.Name = "createPDFText";
            this.createPDFText.Size = new System.Drawing.Size(100, 20);
            this.createPDFText.TabIndex = 6;
            // 
            // createPDFButton
            // 
            this.createPDFButton.Location = new System.Drawing.Point(140, 146);
            this.createPDFButton.Name = "createPDFButton";
            this.createPDFButton.Size = new System.Drawing.Size(100, 45);
            this.createPDFButton.TabIndex = 7;
            this.createPDFButton.Text = "Create PDF";
            this.createPDFButton.UseVisualStyleBackColor = true;
            this.createPDFButton.Click += new System.EventHandler(this.createPDFButton_Click);
            // 
            // createPDFLabel
            // 
            this.createPDFLabel.AutoSize = true;
            this.createPDFLabel.Location = new System.Drawing.Point(9, 143);
            this.createPDFLabel.Name = "createPDFLabel";
            this.createPDFLabel.Size = new System.Drawing.Size(125, 13);
            this.createPDFLabel.TabIndex = 8;
            this.createPDFLabel.Text = "Enter Text to create PDF";
            // 
            // LabelPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 257);
            this.Controls.Add(this.createPDFLabel);
            this.Controls.Add(this.createPDFButton);
            this.Controls.Add(this.createPDFText);
            this.Controls.Add(this.otherPrinterName);
            this.Controls.Add(this.otherPrinterNameLabel);
            this.Controls.Add(this.ErrMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coilID);
            this.Controls.Add(this.printButton);
            this.Name = "LabelPrinter";
            this.Text = "Label Printer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.TextBox coilID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrMsg;
        private System.Windows.Forms.Label otherPrinterNameLabel;
        private System.Windows.Forms.TextBox otherPrinterName;
        private System.Windows.Forms.TextBox createPDFText;
        private System.Windows.Forms.Button createPDFButton;
        private System.Windows.Forms.Label createPDFLabel;
    }
}

