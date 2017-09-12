namespace WindowsFormsApplication2
{
    partial class MainProgram
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.OpenPortBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ProgramBtn = new System.Windows.Forms.Button();
            this.SetupBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BCRComPortTextBox = new System.Windows.Forms.TextBox();
            this.InsBaudRateTextBox = new System.Windows.Forms.TextBox();
            this.BCRBaudRateTextBox = new System.Windows.Forms.TextBox();
            this.InsComPortTextBox = new System.Windows.Forms.TextBox();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PartNum = new System.Windows.Forms.TextBox();
            this.LampSN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ModelNum = new System.Windows.Forms.TextBox();
            this.BallastSN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.WorkOrderNum = new System.Windows.Forms.TextBox();
            this.IlluminatorSN = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChromaCalDateTextBox = new System.Windows.Forms.TextBox();
            this.ChromaModelTextBox = new System.Windows.Forms.TextBox();
            this.ChromaSerialTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programMenuItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // OpenPortBtn
            // 
            this.OpenPortBtn.Location = new System.Drawing.Point(361, 19);
            this.OpenPortBtn.Name = "OpenPortBtn";
            this.OpenPortBtn.Size = new System.Drawing.Size(107, 36);
            this.OpenPortBtn.TabIndex = 3;
            this.OpenPortBtn.Text = "Connect";
            this.OpenPortBtn.UseVisualStyleBackColor = true;
            this.OpenPortBtn.Click += new System.EventHandler(this.OpenPortBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(12, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(478, 26);
            this.textBox2.TabIndex = 12;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(12, 365);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(234, 40);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ProgramBtn);
            this.groupBox4.Controls.Add(this.SetupBtn);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.OpenPortBtn);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.BCRComPortTextBox);
            this.groupBox4.Controls.Add(this.InsBaudRateTextBox);
            this.groupBox4.Controls.Add(this.BCRBaudRateTextBox);
            this.groupBox4.Controls.Add(this.InsComPortTextBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 156);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "COM Port Setup";
            // 
            // ProgramBtn
            // 
            this.ProgramBtn.Location = new System.Drawing.Point(361, 103);
            this.ProgramBtn.Name = "ProgramBtn";
            this.ProgramBtn.Size = new System.Drawing.Size(107, 36);
            this.ProgramBtn.TabIndex = 33;
            this.ProgramBtn.Text = "Program";
            this.ProgramBtn.UseVisualStyleBackColor = true;
            this.ProgramBtn.Click += new System.EventHandler(this.ProgramBtn_Click);
            // 
            // SetupBtn
            // 
            this.SetupBtn.Location = new System.Drawing.Point(361, 61);
            this.SetupBtn.Name = "SetupBtn";
            this.SetupBtn.Size = new System.Drawing.Size(107, 36);
            this.SetupBtn.TabIndex = 24;
            this.SetupBtn.Text = "Setup";
            this.SetupBtn.UseVisualStyleBackColor = true;
            this.SetupBtn.Click += new System.EventHandler(this.SetupBtn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Barcode Reader Baud Rate";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Barcode Reader COM Port";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Chroma Baud Rate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Chroma COM Port";
            // 
            // BCRComPortTextBox
            // 
            this.BCRComPortTextBox.Location = new System.Drawing.Point(158, 87);
            this.BCRComPortTextBox.Name = "BCRComPortTextBox";
            this.BCRComPortTextBox.ReadOnly = true;
            this.BCRComPortTextBox.Size = new System.Drawing.Size(169, 20);
            this.BCRComPortTextBox.TabIndex = 28;
            // 
            // InsBaudRateTextBox
            // 
            this.InsBaudRateTextBox.Location = new System.Drawing.Point(158, 55);
            this.InsBaudRateTextBox.Name = "InsBaudRateTextBox";
            this.InsBaudRateTextBox.ReadOnly = true;
            this.InsBaudRateTextBox.Size = new System.Drawing.Size(169, 20);
            this.InsBaudRateTextBox.TabIndex = 27;
            // 
            // BCRBaudRateTextBox
            // 
            this.BCRBaudRateTextBox.Location = new System.Drawing.Point(158, 119);
            this.BCRBaudRateTextBox.Name = "BCRBaudRateTextBox";
            this.BCRBaudRateTextBox.ReadOnly = true;
            this.BCRBaudRateTextBox.Size = new System.Drawing.Size(169, 20);
            this.BCRBaudRateTextBox.TabIndex = 26;
            // 
            // InsComPortTextBox
            // 
            this.InsComPortTextBox.Location = new System.Drawing.Point(158, 23);
            this.InsComPortTextBox.Name = "InsComPortTextBox";
            this.InsComPortTextBox.ReadOnly = true;
            this.InsComPortTextBox.Size = new System.Drawing.Size(169, 20);
            this.InsComPortTextBox.TabIndex = 25;
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(268, 365);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(234, 40);
            this.StopBtn.TabIndex = 18;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PartNum
            // 
            this.PartNum.Location = new System.Drawing.Point(102, 50);
            this.PartNum.Name = "PartNum";
            this.PartNum.Size = new System.Drawing.Size(139, 20);
            this.PartNum.TabIndex = 19;
            // 
            // LampSN
            // 
            this.LampSN.Location = new System.Drawing.Point(333, 50);
            this.LampSN.Name = "LampSN";
            this.LampSN.Size = new System.Drawing.Size(139, 20);
            this.LampSN.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Part #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Lamp SN:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ModelNum);
            this.groupBox3.Controls.Add(this.BallastSN);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.WorkOrderNum);
            this.groupBox3.Controls.Add(this.IlluminatorSN);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.PartNum);
            this.groupBox3.Controls.Add(this.LampSN);
            this.groupBox3.Location = new System.Drawing.Point(12, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(490, 107);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ID";
            // 
            // ModelNum
            // 
            this.ModelNum.Location = new System.Drawing.Point(102, 78);
            this.ModelNum.Name = "ModelNum";
            this.ModelNum.Size = new System.Drawing.Size(139, 20);
            this.ModelNum.TabIndex = 29;
            // 
            // BallastSN
            // 
            this.BallastSN.Location = new System.Drawing.Point(333, 78);
            this.BallastSN.Name = "BallastSN";
            this.BallastSN.Size = new System.Drawing.Size(139, 20);
            this.BallastSN.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Model #";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Ballast SN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Work Order #";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Illuminator SN:";
            // 
            // WorkOrderNum
            // 
            this.WorkOrderNum.Location = new System.Drawing.Point(102, 22);
            this.WorkOrderNum.Name = "WorkOrderNum";
            this.WorkOrderNum.Size = new System.Drawing.Size(139, 20);
            this.WorkOrderNum.TabIndex = 23;
            // 
            // IlluminatorSN
            // 
            this.IlluminatorSN.Location = new System.Drawing.Point(333, 22);
            this.IlluminatorSN.Name = "IlluminatorSN";
            this.IlluminatorSN.Size = new System.Drawing.Size(139, 20);
            this.IlluminatorSN.TabIndex = 24;
            // 
            // serialPort2
            // 
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Calibration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "SN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Model#";
            // 
            // ChromaCalDateTextBox
            // 
            this.ChromaCalDateTextBox.Location = new System.Drawing.Point(375, 21);
            this.ChromaCalDateTextBox.Name = "ChromaCalDateTextBox";
            this.ChromaCalDateTextBox.ReadOnly = true;
            this.ChromaCalDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.ChromaCalDateTextBox.TabIndex = 39;
            // 
            // ChromaModelTextBox
            // 
            this.ChromaModelTextBox.Location = new System.Drawing.Point(61, 21);
            this.ChromaModelTextBox.Name = "ChromaModelTextBox";
            this.ChromaModelTextBox.ReadOnly = true;
            this.ChromaModelTextBox.Size = new System.Drawing.Size(100, 20);
            this.ChromaModelTextBox.TabIndex = 38;
            // 
            // ChromaSerialTextBox
            // 
            this.ChromaSerialTextBox.Location = new System.Drawing.Point(195, 21);
            this.ChromaSerialTextBox.Name = "ChromaSerialTextBox";
            this.ChromaSerialTextBox.ReadOnly = true;
            this.ChromaSerialTextBox.Size = new System.Drawing.Size(112, 20);
            this.ChromaSerialTextBox.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChromaSerialTextBox);
            this.groupBox1.Controls.Add(this.ChromaModelTextBox);
            this.groupBox1.Controls.Add(this.ChromaCalDateTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 59);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chroma Info";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.addUserToolStripMenuItem,
            this.programMenuItemToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // programMenuItemToolStripMenuItem
            // 
            this.programMenuItemToolStripMenuItem.Name = "programMenuItemToolStripMenuItem";
            this.programMenuItemToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.programMenuItemToolStripMenuItem.Text = "Program";
            this.programMenuItemToolStripMenuItem.Click += new System.EventHandler(this.programMenuItemToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 468);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainProgram";
            this.Text = "Chroma Electrical Safety Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainProgram_FormClosing);
            this.Load += new System.EventHandler(this.MainProgram_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button OpenPortBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox PartNum;
        private System.Windows.Forms.TextBox LampSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ModelNum;
        private System.Windows.Forms.TextBox BallastSN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WorkOrderNum;
        private System.Windows.Forms.TextBox IlluminatorSN;
        private System.Windows.Forms.Button SetupBtn;
        private System.Windows.Forms.TextBox InsComPortTextBox;
        private System.Windows.Forms.TextBox BCRBaudRateTextBox;
        private System.Windows.Forms.TextBox InsBaudRateTextBox;
        private System.Windows.Forms.TextBox BCRComPortTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChromaCalDateTextBox;
        private System.Windows.Forms.TextBox ChromaModelTextBox;
        private System.Windows.Forms.TextBox ChromaSerialTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ProgramBtn;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programMenuItemToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

