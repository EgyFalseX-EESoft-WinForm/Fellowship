namespace Fellowship.Data
{
    partial class ImportFrm
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
            this.pbc = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.dsFellowship = new Fellowship.DataSources.DSFellowship();
            this.txtYear = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFellowship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pbc
            // 
            this.pbc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbc.Location = new System.Drawing.Point(0, 69);
            this.pbc.Name = "pbc";
            this.pbc.Size = new System.Drawing.Size(598, 18);
            this.pbc.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(442, 39);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(110, 23);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "استيراد من الاكسس";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dsFellowship
            // 
            this.dsFellowship.DataSetName = "DSFellowship";
            this.dsFellowship.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsFellowship.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(442, 13);
            this.txtYear.Name = "txtYear";
            this.txtYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtYear.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtYear.Size = new System.Drawing.Size(110, 20);
            this.txtYear.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(558, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "السنة";
            // 
            // ImportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 87);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.pbc);
            this.Controls.Add(this.txtYear);
            this.Name = "ImportFrm";
            this.Text = "أستيراد بيانات";
            ((System.ComponentModel.ISupportInitialize)(this.pbc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFellowship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl pbc;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.OpenFileDialog ofd;
        private DataSources.DSFellowship dsFellowship;
        private DevExpress.XtraEditors.SpinEdit txtYear;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}