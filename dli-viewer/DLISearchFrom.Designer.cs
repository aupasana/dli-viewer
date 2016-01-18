namespace dli_viewer
{
    partial class DLISearchFrom
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
            this.listViewSearch = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Barcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Language = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Year = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pages = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Link = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.pageNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewSearch
            // 
            this.listViewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.Barcode,
            this.Title,
            this.Author,
            this.Language,
            this.Year,
            this.Pages,
            this.Publisher,
            this.Link});
            this.listViewSearch.FullRowSelect = true;
            this.listViewSearch.Location = new System.Drawing.Point(24, 106);
            this.listViewSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listViewSearch.Name = "listViewSearch";
            this.listViewSearch.Size = new System.Drawing.Size(1626, 723);
            this.listViewSearch.TabIndex = 2;
            this.listViewSearch.UseCompatibleStateImageBehavior = false;
            this.listViewSearch.View = System.Windows.Forms.View.Details;
            this.listViewSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSearch_ColumnClick);
            this.listViewSearch.DoubleClick += new System.EventHandler(this.listViewSearch_DoubleClick);
            // 
            // Number
            // 
            this.Number.Text = "#";
            this.Number.Width = 35;
            // 
            // Barcode
            // 
            this.Barcode.Text = "Barcode";
            this.Barcode.Width = 107;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 258;
            // 
            // Author
            // 
            this.Author.Text = "Author";
            this.Author.Width = 112;
            // 
            // Language
            // 
            this.Language.Text = "Language";
            // 
            // Year
            // 
            this.Year.Text = "Year";
            this.Year.Width = 40;
            // 
            // Pages
            // 
            this.Pages.Text = "Pages";
            this.Pages.Width = 45;
            // 
            // Publisher
            // 
            this.Publisher.Text = "Publisher";
            this.Publisher.Width = 112;
            // 
            // Link
            // 
            this.Link.Text = "Link";
            this.Link.Width = 191;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavoritesToolStripMenuItem,
            this.loadFavoritesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(289, 80);
            // 
            // addToFavoritesToolStripMenuItem
            // 
            this.addToFavoritesToolStripMenuItem.Name = "addToFavoritesToolStripMenuItem";
            this.addToFavoritesToolStripMenuItem.Size = new System.Drawing.Size(288, 38);
            this.addToFavoritesToolStripMenuItem.Text = "Add to Favorites";
            this.addToFavoritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavoritesToolStripMenuItem_Click);
            // 
            // loadFavoritesToolStripMenuItem
            // 
            this.loadFavoritesToolStripMenuItem.Name = "loadFavoritesToolStripMenuItem";
            this.loadFavoritesToolStripMenuItem.Size = new System.Drawing.Size(288, 38);
            this.loadFavoritesToolStripMenuItem.Text = "Load Favorites";
            this.loadFavoritesToolStripMenuItem.Click += new System.EventHandler(this.loadFavoritesToolStripMenuItem_Click);
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Items.AddRange(new object[] {
            "http://www.new.dli.ernet.in",
            "http://202.41.82.144",
            "http://www.dli.ernet.in",
            "http://www.dli.gov.in",
            "http://www.new1.dli.ernet.in"});
            this.comboBoxLocation.Location = new System.Drawing.Point(24, 56);
            this.comboBoxLocation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(288, 33);
            this.comboBoxLocation.TabIndex = 4;
            this.comboBoxLocation.Text = "http://www.new.dli.ernet.in";
            this.comboBoxLocation.SelectedValueChanged += new System.EventHandler(this.comboBoxLocation_SelectedValueChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(1132, 56);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(276, 44);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Find Books";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOK.Location = new System.Drawing.Point(1420, 56);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(234, 44);
            this.ButtonOK.TabIndex = 2;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "searchTerm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSearch.Location = new System.Drawing.Point(494, 60);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(622, 31);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = global::dli_viewer.Properties.Settings.Default.searchTerm;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "SearchLanguage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Sanskrit",
            "Any"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(328, 58);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(150, 33);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.Text = global::dli_viewer.Properties.Settings.Default.SearchLanguage;
            this.comboBoxLanguage.SelectedValueChanged += new System.EventHandler(this.comboBoxLanguage_SelectedValueChanged);
            // 
            // pageNumberUpDown
            // 
            this.pageNumberUpDown.Location = new System.Drawing.Point(1276, 12);
            this.pageNumberUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pageNumberUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.Name = "pageNumberUpDown";
            this.pageNumberUpDown.Size = new System.Drawing.Size(90, 31);
            this.pageNumberUpDown.TabIndex = 3;
            this.pageNumberUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageNumberUpDown.ValueChanged += new System.EventHandler(this.pageNumberUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1210, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Page";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Language";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Search String";
            // 
            // DLISearchFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1678, 844);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pageNumberUpDown);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxLocation);
            this.Controls.Add(this.listViewSearch);
            this.Controls.Add(this.buttonSearch);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "DLISearchLanguage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DLISearchFrom";
            this.Text = global::dli_viewer.Properties.Settings.Default.DLISearchLanguage;
            this.Load += new System.EventHandler(this.DLISearchFrom_Load);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageNumberUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSearch;
        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Year;
        private System.Windows.Forms.ColumnHeader Pages;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ColumnHeader Publisher;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.NumericUpDown pageNumberUpDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFavoritesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Language;
        private System.Windows.Forms.ColumnHeader Barcode;
        private System.Windows.Forms.ColumnHeader Link;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}