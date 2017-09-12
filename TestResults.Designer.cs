namespace WindowsFormsApplication2
{
    partial class TestResults
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResults));
            this.TestDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ChromaLoginDBDataSet = new WindowsFormsApplication2.ChromaLoginDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TestDataTableAdapter = new WindowsFormsApplication2.ChromaLoginDBDataSetTableAdapters.TestDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TestDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromaLoginDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TestDataBindingSource
            // 
            this.TestDataBindingSource.DataSource = this.ChromaLoginDBDataSet;
            this.TestDataBindingSource.Position = 0;
            // 
            // ChromaLoginDBDataSet
            // 
            this.ChromaLoginDBDataSet.DataSetName = "ChromaLoginDBDataSet";
            this.ChromaLoginDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.TestDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication2.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(794, 514);
            this.reportViewer1.TabIndex = 0;
            // 
            // TestDataTableAdapter
            // 
            this.TestDataTableAdapter.ClearBeforeFill = true;
            // 
            // TestResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 514);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestResults";
            this.Text = "TestResults";
            this.Load += new System.EventHandler(this.TestResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TestDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromaLoginDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TestDataBindingSource;
        private ChromaLoginDBDataSet ChromaLoginDBDataSet;
        private ChromaLoginDBDataSetTableAdapters.TestDataTableAdapter TestDataTableAdapter;
    }
}