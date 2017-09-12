namespace WindowsFormsApplication2
{
    partial class SetupForm
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
            this.OKBtn = new System.Windows.Forms.Button();
            this.InsComPortComboBox = new System.Windows.Forms.ComboBox();
            this.BCRComPortComboBox = new System.Windows.Forms.ComboBox();
            this.BCRBaudRateComboBox = new System.Windows.Forms.ComboBox();
            this.InsBaudRateComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Chroma = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Chroma.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(12, 192);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(268, 69);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // InsComPortComboBox
            // 
            this.InsComPortComboBox.FormattingEnabled = true;
            this.InsComPortComboBox.Location = new System.Drawing.Point(120, 19);
            this.InsComPortComboBox.Name = "InsComPortComboBox";
            this.InsComPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.InsComPortComboBox.TabIndex = 1;
            // 
            // BCRComPortComboBox
            // 
            this.BCRComPortComboBox.FormattingEnabled = true;
            this.BCRComPortComboBox.Location = new System.Drawing.Point(120, 21);
            this.BCRComPortComboBox.Name = "BCRComPortComboBox";
            this.BCRComPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.BCRComPortComboBox.TabIndex = 2;
            // 
            // BCRBaudRateComboBox
            // 
            this.BCRBaudRateComboBox.FormattingEnabled = true;
            this.BCRBaudRateComboBox.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.BCRBaudRateComboBox.Location = new System.Drawing.Point(120, 51);
            this.BCRBaudRateComboBox.Name = "BCRBaudRateComboBox";
            this.BCRBaudRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.BCRBaudRateComboBox.TabIndex = 3;
            // 
            // InsBaudRateComboBox
            // 
            this.InsBaudRateComboBox.FormattingEnabled = true;
            this.InsBaudRateComboBox.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.InsBaudRateComboBox.Location = new System.Drawing.Point(120, 46);
            this.InsBaudRateComboBox.Name = "InsBaudRateComboBox";
            this.InsBaudRateComboBox.Size = new System.Drawing.Size(121, 21);
            this.InsBaudRateComboBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BCRComPortComboBox);
            this.groupBox1.Controls.Add(this.BCRBaudRateComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Reader";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "COM Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Baud Rate";
            // 
            // Chroma
            // 
            this.Chroma.Controls.Add(this.label2);
            this.Chroma.Controls.Add(this.label1);
            this.Chroma.Controls.Add(this.InsComPortComboBox);
            this.Chroma.Controls.Add(this.InsBaudRateComboBox);
            this.Chroma.Location = new System.Drawing.Point(12, 12);
            this.Chroma.Name = "Chroma";
            this.Chroma.Size = new System.Drawing.Size(268, 84);
            this.Chroma.TabIndex = 6;
            this.Chroma.TabStop = false;
            this.Chroma.Text = "Chroma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM Port";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.Chroma);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Chroma.ResumeLayout(false);
            this.Chroma.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.ComboBox InsComPortComboBox;
        private System.Windows.Forms.ComboBox BCRComPortComboBox;
        private System.Windows.Forms.ComboBox BCRBaudRateComboBox;
        private System.Windows.Forms.ComboBox InsBaudRateComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Chroma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}