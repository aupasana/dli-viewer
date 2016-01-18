namespace dli_viewer
{
    partial class MainForm
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
            this.downloadButton = new System.Windows.Forms.Button();
            this.progressBarBook = new System.Windows.Forms.ProgressBar();
            this.folderButton = new System.Windows.Forms.Button();
            this.statusListView = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkDLIServersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSuccesfulDownloadsFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBookDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.overwriteExistingFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPDFFromSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelPDFCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizePDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addWatermarkToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAdvancedPDFOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImagesAfterPDFCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPDFAfterCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTargetFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFilesFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startUpDown = new System.Windows.Forms.NumericUpDown();
            this.endUpDown = new System.Windows.Forms.NumericUpDown();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.fileDownloadSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bookDownloadingSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeRemainingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonBarcodeInitialize = new System.Windows.Forms.Button();
            this.upDownThreads = new System.Windows.Forms.NumericUpDown();
            this.serverComboBox = new System.Windows.Forms.ComboBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.outputFolderLabel = new System.Windows.Forms.TextBox();
            this.labelFormatString = new System.Windows.Forms.TextBox();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCreatePDF = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.startUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endUpDown)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(316, 428);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(6);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(272, 44);
            this.downloadButton.TabIndex = 6;
            this.downloadButton.Text = "Start &Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // progressBarBook
            // 
            this.progressBarBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarBook.Location = new System.Drawing.Point(644, 484);
            this.progressBarBook.Margin = new System.Windows.Forms.Padding(6);
            this.progressBarBook.Name = "progressBarBook";
            this.progressBarBook.Size = new System.Drawing.Size(484, 44);
            this.progressBarBook.TabIndex = 3;
            // 
            // folderButton
            // 
            this.folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderButton.Location = new System.Drawing.Point(814, 102);
            this.folderButton.Margin = new System.Windows.Forms.Padding(6);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(140, 44);
            this.folderButton.TabIndex = 4;
            this.folderButton.Text = "Browse";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // statusListView
            // 
            this.statusListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.Status});
            this.statusListView.FullRowSelect = true;
            this.statusListView.Location = new System.Drawing.Point(20, 568);
            this.statusListView.Margin = new System.Windows.Forms.Padding(6);
            this.statusListView.Name = "statusListView";
            this.statusListView.Size = new System.Drawing.Size(1108, 258);
            this.statusListView.TabIndex = 30;
            this.statusListView.UseCompatibleStateImageBehavior = false;
            this.statusListView.View = System.Windows.Forms.View.Details;
            this.statusListView.DoubleClick += new System.EventHandler(this.statusListView_DoubleClick);
            // 
            // File
            // 
            this.File.Text = "File";
            this.File.Width = 460;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 400;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.pDFToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(1164, 44);
            this.menuStrip.TabIndex = 15;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDownloadToolStripMenuItem,
            this.cancelDownloadToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkDLIServersToolStripMenuItem,
            this.removeSuccesfulDownloadsFromListToolStripMenuItem,
            this.copyBookDetailsToolStripMenuItem,
            this.toolStripSeparator3,
            this.overwriteExistingFilesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
            this.optionsToolStripMenuItem.Text = "Download";
            // 
            // startDownloadToolStripMenuItem
            // 
            this.startDownloadToolStripMenuItem.Name = "startDownloadToolStripMenuItem";
            this.startDownloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.startDownloadToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.startDownloadToolStripMenuItem.Text = "Start Download";
            this.startDownloadToolStripMenuItem.Click += new System.EventHandler(this.startDownloadToolStripMenuItem_Click);
            // 
            // cancelDownloadToolStripMenuItem
            // 
            this.cancelDownloadToolStripMenuItem.Name = "cancelDownloadToolStripMenuItem";
            this.cancelDownloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelDownloadToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.cancelDownloadToolStripMenuItem.Text = "Cancel Download";
            this.cancelDownloadToolStripMenuItem.Click += new System.EventHandler(this.cancelDownloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(614, 6);
            // 
            // checkDLIServersToolStripMenuItem
            // 
            this.checkDLIServersToolStripMenuItem.Name = "checkDLIServersToolStripMenuItem";
            this.checkDLIServersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.checkDLIServersToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.checkDLIServersToolStripMenuItem.Text = "Check DLI Servers For Book";
            this.checkDLIServersToolStripMenuItem.Click += new System.EventHandler(this.checkDLIServersToolStripMenuItem_Click);
            // 
            // removeSuccesfulDownloadsFromListToolStripMenuItem
            // 
            this.removeSuccesfulDownloadsFromListToolStripMenuItem.Name = "removeSuccesfulDownloadsFromListToolStripMenuItem";
            this.removeSuccesfulDownloadsFromListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.removeSuccesfulDownloadsFromListToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.removeSuccesfulDownloadsFromListToolStripMenuItem.Text = "Remove Succesful Downloads from List";
            this.removeSuccesfulDownloadsFromListToolStripMenuItem.Click += new System.EventHandler(this.removeSuccesfulDownloadsFromListToolStripMenuItem_Click);
            // 
            // copyBookDetailsToolStripMenuItem
            // 
            this.copyBookDetailsToolStripMenuItem.Name = "copyBookDetailsToolStripMenuItem";
            this.copyBookDetailsToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.copyBookDetailsToolStripMenuItem.Text = "Copy download details to clipboard";
            this.copyBookDetailsToolStripMenuItem.Click += new System.EventHandler(this.copyBookDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(614, 6);
            // 
            // overwriteExistingFilesToolStripMenuItem
            // 
            this.overwriteExistingFilesToolStripMenuItem.Checked = global::dli_viewer.Properties.Settings.Default.overwriteExistingFiles;
            this.overwriteExistingFilesToolStripMenuItem.CheckOnClick = true;
            this.overwriteExistingFilesToolStripMenuItem.Name = "overwriteExistingFilesToolStripMenuItem";
            this.overwriteExistingFilesToolStripMenuItem.Size = new System.Drawing.Size(617, 38);
            this.overwriteExistingFilesToolStripMenuItem.Text = "Overwrite Existing Files";
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPDFToolStripMenuItem,
            this.createPDFFromSelectedFilesToolStripMenuItem,
            this.cancelPDFCreationToolStripMenuItem,
            this.optimizePDFToolStripMenuItem,
            this.toolStripSeparator1,
            this.addWatermarkToPDFToolStripMenuItem,
            this.showAdvancedPDFOptionsToolStripMenuItem,
            this.deleteImagesAfterPDFCreationToolStripMenuItem,
            this.openPDFAfterCreationToolStripMenuItem});
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(69, 36);
            this.pDFToolStripMenuItem.Text = "PDF";
            // 
            // createPDFToolStripMenuItem
            // 
            this.createPDFToolStripMenuItem.Name = "createPDFToolStripMenuItem";
            this.createPDFToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.createPDFToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.createPDFToolStripMenuItem.Text = "Create PDF";
            this.createPDFToolStripMenuItem.Click += new System.EventHandler(this.createPDFToolStripMenuItem_Click);
            // 
            // createPDFFromSelectedFilesToolStripMenuItem
            // 
            this.createPDFFromSelectedFilesToolStripMenuItem.Name = "createPDFFromSelectedFilesToolStripMenuItem";
            this.createPDFFromSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.createPDFFromSelectedFilesToolStripMenuItem.Text = "Create PDF from selected files";
            this.createPDFFromSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.createPDFFromSelectedFilesToolStripMenuItem_Click);
            // 
            // cancelPDFCreationToolStripMenuItem
            // 
            this.cancelPDFCreationToolStripMenuItem.Name = "cancelPDFCreationToolStripMenuItem";
            this.cancelPDFCreationToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.cancelPDFCreationToolStripMenuItem.Text = "Cancel PDF Creation / Extraction";
            this.cancelPDFCreationToolStripMenuItem.Click += new System.EventHandler(this.cancelPDFCreationToolStripMenuItem_Click);
            // 
            // optimizePDFToolStripMenuItem
            // 
            this.optimizePDFToolStripMenuItem.Name = "optimizePDFToolStripMenuItem";
            this.optimizePDFToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.optimizePDFToolStripMenuItem.Text = "Extract Images from PDF";
            this.optimizePDFToolStripMenuItem.Click += new System.EventHandler(this.optimizePDFToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(476, 6);
            // 
            // addWatermarkToPDFToolStripMenuItem
            // 
            this.addWatermarkToPDFToolStripMenuItem.Checked = global::dli_viewer.Properties.Settings.Default.AddWatermarkToPDF;
            this.addWatermarkToPDFToolStripMenuItem.CheckOnClick = true;
            this.addWatermarkToPDFToolStripMenuItem.Name = "addWatermarkToPDFToolStripMenuItem";
            this.addWatermarkToPDFToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.addWatermarkToPDFToolStripMenuItem.Text = "Add watermark to PDF";
            // 
            // showAdvancedPDFOptionsToolStripMenuItem
            // 
            this.showAdvancedPDFOptionsToolStripMenuItem.Checked = global::dli_viewer.Properties.Settings.Default.ShowAdvancedPdfOptions;
            this.showAdvancedPDFOptionsToolStripMenuItem.CheckOnClick = true;
            this.showAdvancedPDFOptionsToolStripMenuItem.Name = "showAdvancedPDFOptionsToolStripMenuItem";
            this.showAdvancedPDFOptionsToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.showAdvancedPDFOptionsToolStripMenuItem.Text = "Prompt for advanced PDF Options";
            // 
            // deleteImagesAfterPDFCreationToolStripMenuItem
            // 
            this.deleteImagesAfterPDFCreationToolStripMenuItem.Checked = global::dli_viewer.Properties.Settings.Default.DeleteImagesAfterPDFCreation;
            this.deleteImagesAfterPDFCreationToolStripMenuItem.CheckOnClick = true;
            this.deleteImagesAfterPDFCreationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.deleteImagesAfterPDFCreationToolStripMenuItem.Name = "deleteImagesAfterPDFCreationToolStripMenuItem";
            this.deleteImagesAfterPDFCreationToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.deleteImagesAfterPDFCreationToolStripMenuItem.Text = "Delete Images after PDF creation";
            // 
            // openPDFAfterCreationToolStripMenuItem
            // 
            this.openPDFAfterCreationToolStripMenuItem.Checked = global::dli_viewer.Properties.Settings.Default.OpenPDFAfterCreation;
            this.openPDFAfterCreationToolStripMenuItem.CheckOnClick = true;
            this.openPDFAfterCreationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openPDFAfterCreationToolStripMenuItem.Name = "openPDFAfterCreationToolStripMenuItem";
            this.openPDFAfterCreationToolStripMenuItem.Size = new System.Drawing.Size(479, 38);
            this.openPDFAfterCreationToolStripMenuItem.Text = "Open PDF after creation";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTargetFolderToolStripMenuItem,
            this.loadFilesFromFolderToolStripMenuItem,
            this.notepadToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(88, 36);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // openTargetFolderToolStripMenuItem
            // 
            this.openTargetFolderToolStripMenuItem.Name = "openTargetFolderToolStripMenuItem";
            this.openTargetFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.openTargetFolderToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.openTargetFolderToolStripMenuItem.Text = "Open Target Folder";
            this.openTargetFolderToolStripMenuItem.Click += new System.EventHandler(this.openTargetFolderToolStripMenuItem_Click);
            // 
            // loadFilesFromFolderToolStripMenuItem
            // 
            this.loadFilesFromFolderToolStripMenuItem.Name = "loadFilesFromFolderToolStripMenuItem";
            this.loadFilesFromFolderToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.loadFilesFromFolderToolStripMenuItem.Text = "Load files from folder";
            this.loadFilesFromFolderToolStripMenuItem.Click += new System.EventHandler(this.loadFilesFromFolderToolStripMenuItem_Click);
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(401, 38);
            this.notepadToolStripMenuItem.Text = "Notepad";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(this.notepadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startUpDown);
            this.groupBox1.Controls.Add(this.endUpDown);
            this.groupBox1.Location = new System.Drawing.Point(316, 276);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(238, 137);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pages to Download";
            // 
            // startUpDown
            // 
            this.startUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::dli_viewer.Properties.Settings.Default, "startPageNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.startUpDown.Location = new System.Drawing.Point(12, 36);
            this.startUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.startUpDown.Name = "startUpDown";
            this.startUpDown.Size = new System.Drawing.Size(194, 31);
            this.startUpDown.TabIndex = 20;
            this.startUpDown.Value = global::dli_viewer.Properties.Settings.Default.startPageNumber;
            // 
            // endUpDown
            // 
            this.endUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::dli_viewer.Properties.Settings.Default, "EndPageNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.endUpDown.Location = new System.Drawing.Point(12, 79);
            this.endUpDown.Margin = new System.Windows.Forms.Padding(6);
            this.endUpDown.Name = "endUpDown";
            this.endUpDown.Size = new System.Drawing.Size(194, 31);
            this.endUpDown.TabIndex = 21;
            this.endUpDown.Value = global::dli_viewer.Properties.Settings.Default.EndPageNumber;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDownloadSpeedLabel,
            this.bookDownloadingSpeedLabel,
            this.timeRemainingLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 1011);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip.Size = new System.Drawing.Size(1164, 37);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip";
            // 
            // fileDownloadSpeedLabel
            // 
            this.fileDownloadSpeedLabel.Name = "fileDownloadSpeedLabel";
            this.fileDownloadSpeedLabel.Size = new System.Drawing.Size(311, 32);
            this.fileDownloadSpeedLabel.Text = "File downloading at ?? kb/s.";
            // 
            // bookDownloadingSpeedLabel
            // 
            this.bookDownloadingSpeedLabel.Name = "bookDownloadingSpeedLabel";
            this.bookDownloadingSpeedLabel.Size = new System.Drawing.Size(393, 32);
            this.bookDownloadingSpeedLabel.Text = "Book downloading at ?? sec / page.";
            // 
            // timeRemainingLabel
            // 
            this.timeRemainingLabel.Name = "timeRemainingLabel";
            this.timeRemainingLabel.Size = new System.Drawing.Size(331, 32);
            this.timeRemainingLabel.Text = "Estimated Time Remaining:??.";
            // 
            // buttonBarcodeInitialize
            // 
            this.buttonBarcodeInitialize.Location = new System.Drawing.Point(318, 207);
            this.buttonBarcodeInitialize.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBarcodeInitialize.Name = "buttonBarcodeInitialize";
            this.buttonBarcodeInitialize.Size = new System.Drawing.Size(270, 44);
            this.buttonBarcodeInitialize.TabIndex = 2;
            this.buttonBarcodeInitialize.Text = "Search (for &barcode)";
            this.buttonBarcodeInitialize.UseVisualStyleBackColor = true;
            this.buttonBarcodeInitialize.Click += new System.EventHandler(this.buttonBarcodeInitialize_Click);
            // 
            // upDownThreads
            // 
            this.upDownThreads.Location = new System.Drawing.Point(644, 355);
            this.upDownThreads.Margin = new System.Windows.Forms.Padding(6);
            this.upDownThreads.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownThreads.Name = "upDownThreads";
            this.upDownThreads.Size = new System.Drawing.Size(110, 31);
            this.upDownThreads.TabIndex = 22;
            this.upDownThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // serverComboBox
            // 
            this.serverComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.serverComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "DLIServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.serverComboBox.FormattingEnabled = true;
            this.serverComboBox.Items.AddRange(new object[] {
            "http://www.dli.ernet.in",
            "http://www.dli.gov.in",
            "http://www.new.dli.ernet.in",
            "http://www.new1.dli.ernet.in",
            "http://202.41.82.144"});
            this.serverComboBox.Location = new System.Drawing.Point(318, 57);
            this.serverComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.serverComboBox.Name = "serverComboBox";
            this.serverComboBox.Size = new System.Drawing.Size(468, 33);
            this.serverComboBox.TabIndex = 7;
            this.serverComboBox.Text = global::dli_viewer.Properties.Settings.Default.DLIServer;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Window;
            this.txtBarcode.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "Barcode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBarcode.Location = new System.Drawing.Point(318, 160);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(6);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(474, 31);
            this.txtBarcode.TabIndex = 3;
            this.txtBarcode.Text = global::dli_viewer.Properties.Settings.Default.Barcode;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolderLabel.BackColor = System.Drawing.SystemColors.Window;
            this.outputFolderLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "OutputDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outputFolderLabel.Location = new System.Drawing.Point(318, 109);
            this.outputFolderLabel.Margin = new System.Windows.Forms.Padding(6);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(474, 31);
            this.outputFolderLabel.TabIndex = 5;
            this.outputFolderLabel.Text = global::dli_viewer.Properties.Settings.Default.OutputDirectory;
            // 
            // labelFormatString
            // 
            this.labelFormatString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFormatString.BackColor = System.Drawing.SystemColors.Control;
            this.labelFormatString.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "formatString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelFormatString.Location = new System.Drawing.Point(644, 250);
            this.labelFormatString.Margin = new System.Windows.Forms.Padding(6);
            this.labelFormatString.Name = "labelFormatString";
            this.labelFormatString.Size = new System.Drawing.Size(484, 31);
            this.labelFormatString.TabIndex = 9;
            this.labelFormatString.Text = global::dli_viewer.Properties.Settings.Default.formatString;
            // 
            // URLTextBox
            // 
            this.URLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URLTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.URLTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::dli_viewer.Properties.Settings.Default, "DownloadURL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.URLTextBox.Location = new System.Drawing.Point(644, 207);
            this.URLTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.ReadOnly = true;
            this.URLTextBox.Size = new System.Drawing.Size(484, 31);
            this.URLTextBox.TabIndex = 1;
            this.URLTextBox.Text = global::dli_viewer.Properties.Settings.Default.DownloadURL;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(644, 312);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 31);
            this.textBox1.TabIndex = 31;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Number of threads";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(27, 413);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(0, 25);
            this.labelTitle.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "1) Pick DLI Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "2) Enter Download Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "3) Enter DLI barcode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "4) Search server for book";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "5) Download the book";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 50);
            this.label6.TabIndex = 38;
            this.label6.Text = "5) Pick Advanced Options \r\n    (optional)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 494);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 25);
            this.label7.TabIndex = 39;
            this.label7.Text = "6) Create PDF";
            // 
            // buttonCreatePDF
            // 
            this.buttonCreatePDF.Location = new System.Drawing.Point(316, 484);
            this.buttonCreatePDF.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCreatePDF.Name = "buttonCreatePDF";
            this.buttonCreatePDF.Size = new System.Drawing.Size(272, 44);
            this.buttonCreatePDF.TabIndex = 40;
            this.buttonCreatePDF.Text = "Create PDF";
            this.buttonCreatePDF.UseVisualStyleBackColor = true;
            this.buttonCreatePDF.Click += new System.EventHandler(this.buttonCreatePDF_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 1048);
            this.Controls.Add(this.buttonCreatePDF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.upDownThreads);
            this.Controls.Add(this.serverComboBox);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.buttonBarcodeInitialize);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.labelFormatString);
            this.Controls.Add(this.statusListView);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.progressBarBook);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Digital Library of India Download Helper v1.00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.startUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endUpDown)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ProgressBar progressBarBook;
        private System.Windows.Forms.NumericUpDown startUpDown;
        private System.Windows.Forms.NumericUpDown endUpDown;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.ListView statusListView;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.TextBox labelFormatString;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overwriteExistingFilesToolStripMenuItem;
        private System.Windows.Forms.TextBox outputFolderLabel;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTargetFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel timeRemainingLabel;
        private System.Windows.Forms.ToolStripStatusLabel fileDownloadSpeedLabel;
        private System.Windows.Forms.ToolStripStatusLabel bookDownloadingSpeedLabel;
        private System.Windows.Forms.ToolStripMenuItem loadFilesFromFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button buttonBarcodeInitialize;
        private System.Windows.Forms.ComboBox serverComboBox;
        private System.Windows.Forms.NumericUpDown upDownThreads;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkDLIServersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSuccesfulDownloadsFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPDFFromSelectedFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelPDFCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addWatermarkToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAdvancedPDFOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImagesAfterPDFCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPDFAfterCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBookDetailsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem optimizePDFToolStripMenuItem;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCreatePDF;
    }
}

