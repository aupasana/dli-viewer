namespace dli_viewer
{
    partial class CreatePDFForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatePDFForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.imageQualityUpDown = new System.Windows.Forms.NumericUpDown();
            this.scaleImageUpDown = new System.Windows.Forms.NumericUpDown();
            this.useOriginalImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageQualityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleImageUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale Image (0-100%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image Quality";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(111, 200);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 0;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // imageQualityUpDown
            // 
            this.imageQualityUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::dli_viewer.Properties.Settings.Default, "CreatePDFImageQuality", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.imageQualityUpDown.Location = new System.Drawing.Point(144, 68);
            this.imageQualityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.imageQualityUpDown.Name = "imageQualityUpDown";
            this.imageQualityUpDown.Size = new System.Drawing.Size(63, 20);
            this.imageQualityUpDown.TabIndex = 3;
            this.imageQualityUpDown.Value = global::dli_viewer.Properties.Settings.Default.CreatePDFImageQuality;
            // 
            // scaleImageUpDown
            // 
            this.scaleImageUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::dli_viewer.Properties.Settings.Default, "CreatePDFScaleImage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.scaleImageUpDown.Location = new System.Drawing.Point(144, 41);
            this.scaleImageUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleImageUpDown.Name = "scaleImageUpDown";
            this.scaleImageUpDown.Size = new System.Drawing.Size(63, 20);
            this.scaleImageUpDown.TabIndex = 2;
            this.scaleImageUpDown.Value = global::dli_viewer.Properties.Settings.Default.CreatePDFScaleImage;
            // 
            // useOriginalImagesCheckBox
            // 
            this.useOriginalImagesCheckBox.AutoSize = true;
            this.useOriginalImagesCheckBox.Checked = global::dli_viewer.Properties.Settings.Default.CreatePDFUseOriginalImages;
            this.useOriginalImagesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useOriginalImagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::dli_viewer.Properties.Settings.Default, "CreatePDFUseOriginalImages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.useOriginalImagesCheckBox.Location = new System.Drawing.Point(18, 13);
            this.useOriginalImagesCheckBox.Name = "useOriginalImagesCheckBox";
            this.useOriginalImagesCheckBox.Size = new System.Drawing.Size(120, 17);
            this.useOriginalImagesCheckBox.TabIndex = 1;
            this.useOriginalImagesCheckBox.Text = "Use Original Images";
            this.useOriginalImagesCheckBox.UseVisualStyleBackColor = true;
            this.useOriginalImagesCheckBox.CheckedChanged += new System.EventHandler(this.useOriginalImagesCheckBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 101);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 93);
            this.textBox1.TabIndex = 100;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // CreatePDFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 237);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.imageQualityUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scaleImageUpDown);
            this.Controls.Add(this.useOriginalImagesCheckBox);
            this.Controls.Add(this.label1);
            this.Name = "CreatePDFForm";
            this.Text = "Advanced PDF Creation Settings";
            this.Load += new System.EventHandler(this.CreatePDFForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageQualityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleImageUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox useOriginalImagesCheckBox;
        internal System.Windows.Forms.NumericUpDown scaleImageUpDown;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown imageQualityUpDown;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBox1;
    }
}