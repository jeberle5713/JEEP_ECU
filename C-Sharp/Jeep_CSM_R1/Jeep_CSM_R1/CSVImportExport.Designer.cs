namespace Jeep_CSM_R1
{
    partial class CSVImportExport
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
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lbCSVFiles = new System.Windows.Forms.ListBox();
            this.dlgSelectCSVFile = new System.Windows.Forms.OpenFileDialog();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dlgCSVSave = new System.Windows.Forms.SaveFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Location = new System.Drawing.Point(38, 61);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(75, 25);
            this.btnAddFiles.TabIndex = 0;
            this.btnAddFiles.Text = "Add Files";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lbCSVFiles
            // 
            this.lbCSVFiles.FormattingEnabled = true;
            this.lbCSVFiles.Location = new System.Drawing.Point(38, 92);
            this.lbCSVFiles.Name = "lbCSVFiles";
            this.lbCSVFiles.Size = new System.Drawing.Size(275, 186);
            this.lbCSVFiles.TabIndex = 1;
            this.lbCSVFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbCSVFiles_KeyUp);
            // 
            // dlgSelectCSVFile
            // 
            this.dlgSelectCSVFile.FileName = "openFileDialog1";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(38, 310);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblOK
            // 
            this.lblOK.Location = new System.Drawing.Point(238, 310);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(75, 23);
            this.lblOK.TabIndex = 3;
            this.lblOK.Text = "OK";
            this.lblOK.UseVisualStyleBackColor = true;
            this.lblOK.Click += new System.EventHandler(this.lblOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 53);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Allows ECU code streams (i.e. ECU serial data) in CSV format to be loaded and con" +
    "verted into data frames and saved back into a CSV file.";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(319, 64);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(98, 24);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "Conversion Order";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(319, 92);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(98, 24);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Earliest";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(319, 254);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(98, 24);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "Latest";
            // 
            // CSVImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 350);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lbCSVFiles);
            this.Controls.Add(this.btnAddFiles);
            this.Name = "CSVImportExport";
            this.Text = "CSV Import/Export";
            this.Load += new System.EventHandler(this.CSVImportExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListBox lbCSVFiles;
        private System.Windows.Forms.OpenFileDialog dlgSelectCSVFile;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button lblOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog dlgCSVSave;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}