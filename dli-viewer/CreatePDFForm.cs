using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dli_viewer
{
    public partial class CreatePDFForm : Form
    {
        public CreatePDFForm()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetEnabledControls()
        {
            bool enableOtherControls = !this.useOriginalImagesCheckBox.Checked;
            this.imageQualityUpDown.Enabled = enableOtherControls;
            this.scaleImageUpDown.Enabled = enableOtherControls;
        }

        private void CreatePDFForm_Load(object sender, EventArgs e)
        {
            SetEnabledControls();
        }

        private void useOriginalImagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledControls();
        }
    }
}
