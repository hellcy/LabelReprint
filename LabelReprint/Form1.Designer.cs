using System.Windows.Forms;

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
            this.createPDFButton = new System.Windows.Forms.Button();
            this.createPDFColor = new System.Windows.Forms.Label();
            this.createPDFName = new System.Windows.Forms.Label();
            this.createPDFNameText = new System.Windows.Forms.TextBox();
            this.createPDFColorList = new System.Windows.Forms.ComboBox();
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
            // createPDFButton
            // 
            this.createPDFButton.Location = new System.Drawing.Point(118, 155);
            this.createPDFButton.Name = "createPDFButton";
            this.createPDFButton.Size = new System.Drawing.Size(100, 45);
            this.createPDFButton.TabIndex = 7;
            this.createPDFButton.Text = "Create PDF";
            this.createPDFButton.UseVisualStyleBackColor = true;
            this.createPDFButton.Click += new System.EventHandler(this.createPDFButton_Click);
            // 
            // createPDFColor
            // 
            this.createPDFColor.AutoSize = true;
            this.createPDFColor.Location = new System.Drawing.Point(9, 187);
            this.createPDFColor.Name = "createPDFColor";
            this.createPDFColor.Size = new System.Drawing.Size(59, 13);
            this.createPDFColor.TabIndex = 8;
            this.createPDFColor.Text = "Enter Color";
            // 
            // createPDFName
            // 
            this.createPDFName.AutoSize = true;
            this.createPDFName.Location = new System.Drawing.Point(9, 148);
            this.createPDFName.Name = "createPDFName";
            this.createPDFName.Size = new System.Drawing.Size(63, 13);
            this.createPDFName.TabIndex = 9;
            this.createPDFName.Text = "Enter Name";
            // 
            // createPDFNameText
            // 
            this.createPDFNameText.Location = new System.Drawing.Point(12, 164);
            this.createPDFNameText.Name = "createPDFNameText";
            this.createPDFNameText.ShortcutsEnabled = false;
            this.createPDFNameText.Size = new System.Drawing.Size(100, 20);
            this.createPDFNameText.TabIndex = 10;
            this.createPDFNameText.Text = "SMART POST";
            // 
            // createPDFColorList
            // 
            this.createPDFColorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.createPDFColorList.FormattingEnabled = true;
            this.createPDFColorList.IntegralHeight = false;
            this.createPDFColorList.Items.AddRange(new object[] {
            "ARMOUR GREY 300MM",
            "BEIGE 300MM",
            "BIRCH 300MM",
            "BLACK 300MM",
            "BLUE ROCK 300MM",
            "BOWRAL BROWN 300MM",
            "CAULFIELD GREEN 300MM",
            "COKE 300MM",
            "GALVANISED 300MM",
            "GREY STONE 300MM",
            "GULL GREY 300MM",
            "GUN METAL GREEN 300MM",
            "HERITAGE RED 300MM",
            "IRONBARK 300MM",
            "MERINO 300MM",
            "MOCCA 300MM",
            "MOSS VALE SAND 300MM",
            "MOUNTAIN BLUE 300MM",
            "OCEAN GREEN 300MM",
            "OFF WHITE 300MM",
            "PICTON GREEN 300MM",
            "PRIMROSE 300MM",
            "RIVERGUM 300MM",
            "SLATE GREY 300MM",
            "SMOOTH CREAM 300MM",
            "WEATHERED COPPER 300MM",
            "WHEAT 300MM"});
            this.createPDFColorList.Location = new System.Drawing.Point(12, 203);
            this.createPDFColorList.MaxDropDownItems = 50;
            this.createPDFColorList.Name = "createPDFColorList";
            this.createPDFColorList.Size = new System.Drawing.Size(136, 21);
            this.createPDFColorList.Sorted = true;
            this.createPDFColorList.TabIndex = 0;
            this.createPDFColorList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LabelPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 257);
            this.Controls.Add(this.createPDFColorList);
            this.Controls.Add(this.createPDFNameText);
            this.Controls.Add(this.createPDFName);
            this.Controls.Add(this.createPDFColor);
            this.Controls.Add(this.createPDFButton);
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
        private System.Windows.Forms.Button createPDFButton;
        private System.Windows.Forms.Label createPDFColor;
        private System.Windows.Forms.Label createPDFName;
        private System.Windows.Forms.TextBox createPDFNameText;
        private System.Windows.Forms.ComboBox createPDFColorList;
    }
}

