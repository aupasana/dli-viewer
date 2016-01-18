using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace dli_viewer
{
    public partial class MainForm : Form
    {
        List<Thread> allWorkerThreads = new List<Thread>();

        public MainForm()
        {
            InitializeComponent();
            startUpDown.Maximum = 10000;
            endUpDown.Maximum = 10000;
        }

        private bool OverwriteExistingFiles
        {
            get { return this.overwriteExistingFilesToolStripMenuItem.Checked; }
        }

        private bool OpenPDFAfterCreation
        {
            get { return this.openPDFAfterCreationToolStripMenuItem.Checked; }
        }

        private bool AddWatermarktoPDF
        {
            get { return this.addWatermarkToPDFToolStripMenuItem.Checked; }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.serverComboBox.Text))
            {
                MessageBox.Show("Please select a DLI server to download from", "", MessageBoxButtons.OK);
                this.serverComboBox.Focus();
                return;
            }

            if (!Directory.Exists(outputFolderLabel.Text))
            {
                DialogResult dr = MessageBox.Show("Output directory does not exist. Would you like to create it?",
                    "", MessageBoxButtons.YesNo);

                if (dr == DialogResult.No)
                {
                    return;
                }

                Directory.CreateDirectory(outputFolderLabel.Text);
            }

            try
            {
                string locationFilename = outputFolderLabel.Text + @"\location.txt";
                string formatStringFilename = outputFolderLabel.Text + @"\formatString.txt";

                if (System.IO.File.Exists(locationFilename))
                {
                    System.IO.File.Delete(locationFilename);
                }

                if (System.IO.File.Exists(formatStringFilename))
                {
                    System.IO.File.Delete(formatStringFilename);
                }

                System.IO.File.WriteAllText(locationFilename, this.URLTextBox.Text);
                System.IO.File.WriteAllText(formatStringFilename, this.labelFormatString.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                this.serverName = serverComboBox.Text;
                this.statusListView.Items.Clear();


                this.downloadButton.Enabled = false;

                for (int threadNumber = 0; threadNumber < this.upDownThreads.Value; threadNumber++)
                {
                    Thread nextWorkerThread = new Thread(new ParameterizedThreadStart(this.StartDownload));
                    allWorkerThreads.Add(nextWorkerThread);
                    string serverFormatString = string.Format(@"{0}{1}", this.serverComboBox.Text, labelFormatString.Text);
                    nextWorkerThread.Start(serverFormatString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string serverName;



        private bool DownloadSingleFile(string url, string outputFileName, out string error)
        {
            error = "Success";
            if (this.OverwriteExistingFiles == false && System.IO.File.Exists(outputFileName))
            {
                FileInfo info = new FileInfo(outputFileName);
                if (info.Length > 0)
                {
                    error = "Already exists";
                    return true;
                }
            }

            FileStream currentFileStream = null;

            WebClient client = new WebClient();
            try
            {
                Stopwatch fragmentStopWatch = new Stopwatch();

                currentFileStream = new FileStream(outputFileName, FileMode.Create);
                HttpWebRequest fileSizeWebRequest = WebRequest.Create(url) as HttpWebRequest;
                WebResponse response = fileSizeWebRequest.GetResponse();
                Stream readStream = response.GetResponseStream();

                byte[] buffer = new byte[2048];
                int numBytesRead = 0;
                int totalBytesRead = 0;
                fragmentStopWatch.Start();
                do
                {

                    numBytesRead = readStream.Read(buffer, 0, 2048);
                    currentFileStream.Write(buffer, 0, numBytesRead);
                    totalBytesRead += numBytesRead;
                    double elapsedSeconds = fragmentStopWatch.ElapsedMilliseconds / 1000.0;
                    string speedText = String.Format("File downloading at {0:0.000} kb/s.",
                        ((double)totalBytesRead / (double)elapsedSeconds) / 1000.0);
                    statusStrip.Invoke(new UpdateToolStripLabelDelegate(UpdateToolStripLabel), new object[] { fileDownloadSpeedLabel, speedText });

                    //int progress = CalculatePercentage(totalBytesRead, response.ContentLength);
                    //progressBarPage.Invoke(new SetInt(SetPageProgress), progress);

                } while (numBytesRead > 0);

                readStream.Close();
                currentFileStream.Close();
            }
            catch (Exception e)
            {
                if (null != currentFileStream)
                {
                    currentFileStream.Close();
                }

                if (System.IO.File.Exists(outputFileName))
                {
                    System.IO.File.Delete(outputFileName);
                }
                error = e.Message;
                return false;
            }

            return true;
        }

        private int CalculatePercentage(long current, long total)
        {
            int progress = (int)((double)current / (double)total * 100.0);
            progress = Math.Max(progress, 0);
            progress = Math.Min(progress, 100);
            return progress;
        }

        delegate void EmptyDelegate();

        private int GetNextPageToDownload()
        {
            lock (this)
            {
                if (this.startUpDown.Value > this.endUpDown.Value)
                {
                    return -1;
                }

                EmptyDelegate incrementStart = delegate() { this.startUpDown.Value++; };
                this.startUpDown.Invoke(incrementStart);
                return (int)this.startUpDown.Value-1;
            }
        }

        private void StartDownload(object o)
        {
            try
            {
                int start = (int)startUpDown.Value;
                int end = (int)endUpDown.Value;
                string urlFormatString = o as string;

                if (!Directory.Exists(this.outputFolderLabel.Text))
                {
                    throw new Exception(String.Format("Directory {0} does not exist", this.outputFolderLabel.Text));
                }

                Stopwatch bookStopwatch = new Stopwatch();
                bookStopwatch.Start();
                int i;
                while ((i = GetNextPageToDownload()) != -1)
                {
                    //progressBarPage.Invoke(new SetInt(SetPageProgress), 0);
                    //startUpDown.Invoke(new SetInt(SetBookPage), i);

                    string url = String.Format(urlFormatString, i);
                    string outputFileName = String.Format(@"{0}\{1:00000000}.tif", this.outputFolderLabel.Text, i);


                    this.statusListView.Invoke(new AddStatusItemDelegate(AddStatusItem), new object[] { url, "Downloading" });

                    string error;
                    bool succesfulDownload = (DownloadSingleFile(url, outputFileName, out error));
                    if (succesfulDownload)
                    {
                        this.statusListView.Invoke(new ChangeStatusItemDelegate(ChangeStatusItem), new object[] { url, outputFileName, "Success" });
                    }
                    else
                    {
                        this.statusListView.Invoke(new ChangeStatusItemDelegate(ChangeStatusItem), new object[] { url, url, error });
                    }

                    double speed = ((double)bookStopwatch.ElapsedMilliseconds/1000.0) / (double)(i-start+1);
                    string speedText = string.Format("Book downloading at {0} sec/page.", (int)speed);
                    statusStrip.Invoke(new UpdateToolStripLabelDelegate(UpdateToolStripLabel), new object[] { bookDownloadingSpeedLabel, speedText });

                    speed = ((double)(end - i)) * speed;
                    speedText = string.Format("Estimated Time Remaining: {0:0.0} minutes.", speed / 60);
                    statusStrip.Invoke(new UpdateToolStripLabelDelegate(UpdateToolStripLabel), new object[] { timeRemainingLabel, speedText });

                    int progress = this.CalculatePercentage(i - start, end - start);

                    if (progressBarBook.Value < progress)
                    {
                        progressBarBook.Invoke(new SetInt(SetBookProgress), progress);
                    }
                }
            }
            catch (ThreadAbortException)
            {
                return;
            }
            catch (Exception e)
            {
                this.Invoke(new ShowException(ShowError), e);
            }
            finally
            {
                this.downloadButton.Invoke(new SetButtonStatusDelegate(SetButtonStatus), new object[] { this.downloadButton, true });
                this.allWorkerThreads.Clear();
            }
        }

        delegate void SetInt(int value);
        delegate void SetString(string s);
        delegate void SetButtonStatusDelegate(Button b, bool enabled);
        internal delegate void AddStatusItemDelegate(string file, string status);
        delegate void ChangeStatusItemDelegate(string currentText, string newText, string status);
        delegate void ShowException(Exception e);
        delegate void UpdateToolStripLabelDelegate(ToolStripStatusLabel l, string text);

        //private void SetPageProgress(int progress)
        //{
        //    Console.WriteLine("Page " + progress);
        //    progressBarPage.Value = progress;
        //}

        private void SetBookProgress(int progress)
        {
            Console.WriteLine("Book " + progress);
            progressBarBook.Value = progress;
        }

        private void SetBookPage(int page)
        {
            this.startUpDown.Value = page;
        }

        private void ShowString(string s)
        {
            MessageBox.Show(s);
        }

        private void ShowError(Exception e)
        {
            MessageBox.Show(e.Message);
        }

        private void SetButtonStatus(Button b, bool enabled)
        {
            b.Enabled = enabled;
        }

        internal void AddStatusItem(string file, string status)
        {
            ListViewItem item = new ListViewItem(file);
            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, status);
            item.SubItems.Add(subItem);
            statusListView.Items.Add(item);
            statusListView.Update();
            statusListView.EnsureVisible(statusListView.Items.Count - 1);
        }

        private void ChangeStatusItem(string currentText, string newText, string status)
        {
            ListViewItem item = statusListView.FindItemWithText(currentText);
            item.Text = newText;
            item.SubItems[1].Text = status;
            item.EnsureVisible();
        }

        private void UpdateToolStripLabel(ToolStripStatusLabel l, string text)
        {
            l.Text = text;
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result =  dialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            this.outputFolderLabel.Text = dialog.SelectedPath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.overwriteExistingFiles = this.overwriteExistingFilesToolStripMenuItem.Checked;
            Properties.Settings.Default.OpenPDFAfterCreation = this.openPDFAfterCreationToolStripMenuItem.Checked;
            Properties.Settings.Default.AddWatermarkToPDF = this.addWatermarkToPDFToolStripMenuItem.Checked;
            Properties.Settings.Default.ShowAdvancedPdfOptions = this.showAdvancedPDFOptionsToolStripMenuItem.Checked;
            Properties.Settings.Default.DeleteImagesAfterPDFCreation = this.deleteImagesAfterPDFCreationToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        internal static string FindDictionaryValueForKey(Dictionary<string,string> dictionary, string[] keys)
        {
            foreach (string key in keys)
            {
                if (dictionary.ContainsKey(key))
                {
                    return dictionary[key].Trim();
                }
            }
            return String.Empty;
        }

        private void buttonPrepare_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri = new Uri(HttpUtility.UrlDecode(this.bookUrl));
                NameValueCollection collection = HttpUtility.ParseQueryString(uri.Query);

                this.progressBarBook.Value = 0;
                //this.progressBarPage.Value = 0;

                int numPages = 0;

                Dictionary<string, string> urlParameters = new Dictionary<string, string>();
                foreach (string key in collection.Keys)
                {
                    if (null != key)
                    {
                        urlParameters.Add(key, collection.Get(key));
                    }
                }


                string hostPrefix = uri.GetLeftPart(UriPartial.Authority);
                string pageValue = FindDictionaryValueForKey(urlParameters, new string[] { "pages", "last" });
                string urlValue = FindDictionaryValueForKey(urlParameters, new string[] { "url", "path1", "bookpath" });

                if (false == int.TryParse(pageValue, out numPages))
                {
                    numPages = 0;
                }


                labelFormatString.Text = string.Format("{0}/PTIFF/", urlValue) + @"{0:00000000}.tif";
                startUpDown.Value = 1;
                endUpDown.Value = numPages;
            }
            catch (Exception ee)
            {
            }
        }

        private void CancelBackgroundThread()
        {
            foreach (Thread t in this.allWorkerThreads)
            {
                t.Abort();
            }
            this.downloadButton.Enabled = true;
        }

        private void OpenFile (string fileName)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Verb = "Open";
            process.Start();
        }

        private void statusListView_DoubleClick(object sender, EventArgs e)
        {
            if (this.statusListView.SelectedItems.Count <= 0)
            {
                return;
            }

            OpenFile(this.statusListView.SelectedItems[0].Text);

        }

        string GetInputPDFFilename(out DialogResult result)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = this.outputFolderLabel.Text;
            dialog.Title = "Choose PDF to extract images from ...";
            dialog.Filter = "PDF Files|*.pdf";

            result = dialog.ShowDialog();
            return dialog.FileName;
        }


        string GetOutputPDFFilename (out DialogResult result)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = this.outputFolderLabel.Text;
            dialog.Title = "Save PDF as ...";
            dialog.Filter = "PDF Files|*.pdf";

            result = dialog.ShowDialog();
            return dialog.FileName;
        }

        void GetAdvancedPDFSettings(GeneratePDFArguments arguments)
        {
            if (showAdvancedPDFOptionsToolStripMenuItem.Checked)
            {
                CreatePDFForm createForm = new CreatePDFForm();
                createForm.ShowDialog();
                arguments.useOriginalImages = createForm.useOriginalImagesCheckBox.Checked;
                arguments.imageQuality = (long)((float)createForm.imageQualityUpDown.Value / 100f);
                arguments.imageScaleFactor = (float)createForm.scaleImageUpDown.Value / 100f;
            }
            else
            {
                arguments.useOriginalImages = true;
            }
            arguments.InputDirectory = this.outputFolderLabel.Text;
        }

        void CreatePDF()
        {
            DialogResult result;
            GeneratePDFArguments arguments = new GeneratePDFArguments();
            arguments.OutputFilename = GetOutputPDFFilename(out result);
            if (result != DialogResult.OK)
            {
                return;
            }

            GetAdvancedPDFSettings(arguments);

            this.statusListView.Items.Clear();
            this.downloadButton.Enabled = false;

            try
            {
                arguments.InputFilenames = Directory.GetFiles(this.outputFolderLabel.Text, "*.tif", SearchOption.TopDirectoryOnly);
            }
            catch
            {
            }

            if (arguments.InputFilenames == null || arguments.InputFilenames.Length == 0)
            {
                try
                {
                    arguments.InputFilenames = Directory.GetFiles(this.outputFolderLabel.Text, "*.png", SearchOption.TopDirectoryOnly);
                }
                catch
                {
                }
            }

            if (arguments.InputFilenames == null || arguments.InputFilenames.Length == 0)
            {
                MessageBox.Show("No image files found");
                return;
            }

            this.progressBarBook.Value = 0;
            Thread workerThread = new Thread(new ParameterizedThreadStart(GeneratePDF));
            this.allWorkerThreads.Add(workerThread);
            workerThread.Start(arguments);
        }

        private void createPDFFromSelectedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.statusListView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("No items selected.");
                return;
            }

            DialogResult result;
            GeneratePDFArguments arguments = new GeneratePDFArguments();
            arguments.OutputFilename = GetOutputPDFFilename(out result);
            if (result != DialogResult.OK)
            {
                return;
            }

            GetAdvancedPDFSettings(arguments);

            arguments.InputFilenames = new string[this.statusListView.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in this.statusListView.SelectedItems)
            {
                arguments.InputFilenames[i++] = item.Text;
            }

            this.statusListView.Items.Clear();
            this.downloadButton.Enabled = false;
            this.progressBarBook.Value = 0;
            Thread workerThread = new Thread(new ParameterizedThreadStart(GeneratePDF));
            this.allWorkerThreads.Add(workerThread);
            workerThread.Start(arguments);

        }

        internal class GeneratePDFArguments
        {
            internal string OutputFilename = String.Empty;
            internal string InputDirectory = String.Empty;
            internal string[] InputFilenames = null;
            internal bool useOriginalImages;
            internal long imageQuality;
            internal float imageScaleFactor;
        }

        static System.Drawing.Image Resize(System.Drawing.Image img, float percentage)
        {
            float originalW = img.Width;
            float originalH = img.Height;

            int resizedW = (int)(originalW * percentage);
            int resizedH = (int)(originalH * percentage);

            Bitmap bmp = new Bitmap(resizedW, resizedH);
            Graphics graphic = Graphics.FromImage((System.Drawing.Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            graphic.Dispose();
            return (System.Drawing.Image)bmp;
        }
        static ImageCodecInfo imageEncoder = GetEncoder(ImageFormat.Tiff);
        static Byte[] ConvertImage(string filename, float scaleFactor, long qualityFactor)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bitmap = new Bitmap(filename);

            System.Drawing.Image resizedImage = Resize(bitmap, scaleFactor);
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
            encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long).7);
            resizedImage.Save(ms, imageEncoder, encoderParameters);

            if (ms.Length > new FileInfo(filename).Length)
            {
                return System.IO.File.ReadAllBytes(filename);
            }
            else
            {
                return ms.GetBuffer();
            }
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        void GeneratePDF(object argumentsObject)
        {
            try
            {
                GeneratePDFArguments arguments = argumentsObject as GeneratePDFArguments;

                FileStream outputStream = new FileStream(arguments.OutputFilename, FileMode.Create);

                List<string> fileNamesSortList = new List<string>(arguments.InputFilenames);
                fileNamesSortList.Sort(StringComparer.CurrentCultureIgnoreCase);
                arguments.InputFilenames = fileNamesSortList.ToArray();

                int totalNmberOfFiles = arguments.InputFilenames.Length;
                int numberOfFilesProcessed = 0;

                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, outputStream);
                writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);
                writer.CompressionLevel = PdfStream.BEST_COMPRESSION;

                document.Open();
                PdfContentByte content = writer.DirectContent;
                
                foreach (string file in arguments.InputFilenames)
                {
                    string dliName = String.Empty;

                    try
                    {
                        FileInfo info = new FileInfo(file);
                        string name = info.Name.Split(new char[] { '.' })[0];
                        string formatString = string.Empty;

                        if (System.IO.File.Exists(outputFolderLabel.Text + @"\formatString.txt"))
                        {
                            formatString = System.IO.File.ReadAllText(outputFolderLabel.Text + @"\formatString.txt");
                        }
                        dliName = string.Format(formatString, name);
                    }
                    catch
                    {
                    }

                    try
                    {
                        iTextSharp.text.Image image;

                        if (arguments.useOriginalImages)
                        {
                            image = iTextSharp.text.Image.GetInstance(file);
                        }
                        else
                        {
                            image = iTextSharp.text.Image.GetInstance(ConvertImage(file, arguments.imageScaleFactor, arguments.imageQuality));
                        }

                        // scale image to fit either the 8.5 or 11 inch margins
                        // default dpi is 72

                        float scaleFactor = 1f;
                        if (image.Height > 11*72f)
                        {
                            scaleFactor = 11f / (image.Height/72f);
                        }
                        if (image.Width > 8.5*72f)
                        {
                            float widthScaleFactor = 8.5f / (image.Width/72f);
                            if (widthScaleFactor > scaleFactor)
                            {
                                scaleFactor = widthScaleFactor;
                            }
                        }

                        if (scaleFactor != 1f)
                        {
                            image.ScalePercent(scaleFactor * (float)100.0);
                        }

                        document.SetPageSize(new iTextSharp.text.Rectangle(image.Width*scaleFactor, image.Height*scaleFactor));
                        document.NewPage();

                        image.SetAbsolutePosition(0, 0);
                        content.AddImage(image);

                        if (this.AddWatermarktoPDF && !string.IsNullOrEmpty(dliName))
                        {
                            BaseFont baseFont = FontFactory.GetFont(FontFactory.COURIER).GetCalculatedBaseFont(false);
                                
                            content.BeginText();
                            content.SetFontAndSize(baseFont, 35);
                            content.ShowTextAligned(PdfContentByte.ALIGN_CENTER, dliName, image.Width / 2, 35, 0);
                            content.EndText();
                        }

                        int progress = this.CalculatePercentage(++numberOfFilesProcessed, totalNmberOfFiles);
                        this.progressBarBook.Invoke(new SetInt(SetBookProgress), progress);
                        this.statusListView.Invoke(new AddStatusItemDelegate(AddStatusItem), new object[] { file, "Added" });
                    }
                    catch (ThreadAbortException)
                    {
                    }
                    catch (Exception ex)
                    {
                        this.statusListView.Invoke(new AddStatusItemDelegate(AddStatusItem), new object[] { file, ex.Message });
                    }

                }

                document.Close();

                if (OpenPDFAfterCreation)
                {
                    OpenFile(arguments.OutputFilename);
                }

                if (deleteImagesAfterPDFCreationToolStripMenuItem.Checked)
                {
                    DeleteTemporaryFiles(arguments);
                }
            }
            catch (ThreadAbortException)
            {
                return;
            }
            catch (Exception e)
            {
                this.Invoke(new ShowException(ShowError), e);
            }
            finally
            {
                this.downloadButton.Invoke(new SetButtonStatusDelegate(SetButtonStatus), new object[] { this.downloadButton, true });
                this.allWorkerThreads.Clear();
            }

        }

        private void DeleteTemporaryFiles(GeneratePDFArguments arguments)
        {
            if (deleteImagesAfterPDFCreationToolStripMenuItem.Checked)
            {
                string locationFilename = arguments.InputDirectory + @"\location.txt";
                string formatStringFilename = arguments.InputDirectory + @"\formatString.txt";

                if (System.IO.File.Exists(locationFilename))
                {
                    System.IO.File.Delete(locationFilename);
                }
                if (System.IO.File.Exists(formatStringFilename))
                {
                    System.IO.File.Delete(formatStringFilename);
                }
                foreach (string filename in arguments.InputFilenames)
                {
                    if (System.IO.File.Exists(filename))
                    {
                        System.IO.File.Delete(filename);
                    }
                }
                if (System.IO.Directory.GetFiles(arguments.InputDirectory).Length == 0)
                {
                    System.IO.Directory.Delete(arguments.InputDirectory);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePDF();
        }

        private void cancelDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelBackgroundThread();

            DialogResult dr = MessageBox.Show("Download Cancelled. Delete Temporary Files?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                GeneratePDFArguments arguments = new GeneratePDFArguments();
                arguments.InputDirectory = this.outputFolderLabel.Text;
                arguments.InputFilenames = Directory.GetFiles(this.outputFolderLabel.Text, "*.tif", SearchOption.TopDirectoryOnly);
                DeleteTemporaryFiles(arguments);
            }
        }

        private void cancelPDFCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelBackgroundThread();
            MessageBox.Show("Done");
        }

        DLISearchFrom searchForm = null;
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (searchForm == null)
            {
                searchForm = new DLISearchFrom();
            }
            DialogResult result = searchForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

//            this.URLTextBox.Text = searchForm.Url;

            this.bookUrl = searchForm.Url;
            this.bookUrlRelative = searchForm.UrlRelative;
            this.URLTextBox.Text = searchForm.TitleValue;
            this.txtBarcode.Text = searchForm.BarcodeValue;

            this.progressBarBook.Value = 0;
            //this.progressBarPage.Value = 0;
            this.startUpDown.Value = 0;
            this.endUpDown.Value = 0;
            this.labelFormatString.Text = string.Empty;
            this.buttonPrepare_Click(null, null);
        }

        string bookUrl;
        string bookUrlRelative;

        private void openTargetFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(this.outputFolderLabel.Text))
            {
                Process process = new Process();
                process.StartInfo.FileName = this.outputFolderLabel.Text;
                process.StartInfo.Verb = "Open";
                process.Start();
            }
            else
            {
                MessageBox.Show("Directory does not exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notes notes = new Notes();
            notes.Show();
        }

        private void loadFilesFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statusListView.BeginUpdate();
            this.statusListView.Items.Clear();

            if (!System.IO.Directory.Exists(this.outputFolderLabel.Text))
            {
                MessageBox.Show("Unable to find directory", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] inputFilenames;
            
            inputFilenames = Directory.GetFiles(this.outputFolderLabel.Text, "*.tif", SearchOption.TopDirectoryOnly);
            if (inputFilenames.Length == 0)
            {
                inputFilenames = Directory.GetFiles(this.outputFolderLabel.Text, "*.png", SearchOption.TopDirectoryOnly);
            }

            List<string> fileNamesSortList = new List<string>(inputFilenames);
            fileNamesSortList.Sort(StringComparer.CurrentCultureIgnoreCase);

            foreach (string file in fileNamesSortList)
            {
                ListViewItem item = new ListViewItem(file);
                this.statusListView.Items.Add(item);
            }

            this.statusListView.EndUpdate();
        }

        private void buttonBarcodeInitialize_Click(object sender, EventArgs e)
        {
            this.URLTextBox.Clear();
            this.URLTextBox.Update();
            this.labelFormatString.Clear();
            this.labelFormatString.Update();


            try
            {
                Regex targetRegex = new Regex("href=\"(.*)/scripts/FullindexDefault.htm\\?path1=([^&\n]*)(\n|&)", RegexOptions.Multiline);
                Regex pagesRegex = new Regex("first=([0-9]*)&last=([0-9]*)", RegexOptions.Multiline);
                Regex titleRegex = new Regex(@"Title</font></strong></div></td>[^>]*>[^>]*>[^>]*>([^>]*)<", RegexOptions.Multiline);
                Regex barcodeRegex = new Regex(@"[0-9]*");

                string barcodeOnly = barcodeRegex.Match(this.txtBarcode.Text).Value;

    //            Title</font></strong></div></td>
    //<td width="71%" bgcolor="#E8EEF7"><div align="center"><font face="Arial  size="2", Helvetica, sans-serif">VARAHAMIHIRAHORAS'ASTRAM</font></div></t

                string uriString = string.Format(@"{0}/cgi-bin/DBscripts/allmetainfo.cgi?barcode={1}", serverComboBox.Text, barcodeOnly);
                HttpWebRequest request = WebRequest.Create(uriString) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string htmlString = reader.ReadToEnd();

                Match m = targetRegex.Match(htmlString);
                string server = m.Groups[1].Value;
                string path = m.Groups[2].Value;

                m = pagesRegex.Match(htmlString);

                this.startUpDown.Value = 1;
                this.endUpDown.Value = 1;

                Decimal temp;
                if (Decimal.TryParse(m.Groups[1].Value, out temp))
                {
                    this.startUpDown.Value = Decimal.Parse(m.Groups[1].Value);
                }

                if (Decimal.TryParse(m.Groups[2].Value, out temp))
                {
                    this.endUpDown.Value = Decimal.Parse(m.Groups[2].Value);
                }

                m = titleRegex.Match(htmlString);
                this.URLTextBox.Text = m.Groups[1].Value;

                if (string.IsNullOrEmpty(server))
                {
                    server = @"http://www.new.dli.ernet.in";
                }

                string link = path + "/PTIFF/{0:00000000}.tif";
                this.labelFormatString.Text = link;

                this.downloadButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Unable to find a book with this barcode. " + ex.Message);
            }
        }

        private void checkDLIServersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDLIServers();
        }

        private void CheckDLIServers()
        {
            this.statusListView.Items.Clear();

            this.AddStatusItem(string.Format("Checking all {0} servers for page {1} of this book ...",
                this.serverComboBox.Items.Count, this.startUpDown.Value), string.Empty);

            foreach (object o in this.serverComboBox.Items)
            {
                string serverName = o as string;
                string fileNameFormat = string.Format(@"{0}{1}", serverName, this.labelFormatString.Text);
                string fileName = string.Format(fileNameFormat, this.startUpDown.Value);

                Thread workerThread = new Thread(new ParameterizedThreadStart(CheckDLIFileExistenceStart));
                workerThread.Start(fileName);                
            }
        }

        private void CheckDLIFileExistenceStart(object filenameObject)
        {
            string filename = filenameObject as string;
            WebRequest request = WebRequest.Create(new Uri(filename));
            request.Method = "HEAD";
            request.Timeout = 30000;

            string responseDescription;
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                WebResponse response = request.GetResponse();
                watch.Stop();

                responseDescription = string.Format("{0}. Size={1}. ElapsedTime={2}ms.", response.ContentType, response.ContentLength, watch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                responseDescription = e.Message;
            }

            EmptyDelegate myDelegate = delegate()
            {
                ListViewItem item = new ListViewItem(filename);
                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, responseDescription);
                item.SubItems.Add(subItem);
                statusListView.Items.Add(item);
            };

            this.statusListView.Invoke(myDelegate);
        }

        private void removeSuccesfulDownloadsFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.statusListView.BeginUpdate();

            List<ListViewItem> itemsToRemove = new List<ListViewItem>();

            foreach (ListViewItem item in this.statusListView.Items)
            {
                string value = item.SubItems[1].Text;
                if (
                        value.Equals("Success", StringComparison.InvariantCultureIgnoreCase) ||
                        value.Equals("Added", StringComparison.InvariantCultureIgnoreCase) ||
                        value.Equals("Already Exists", StringComparison.InvariantCultureIgnoreCase)
                    )
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (ListViewItem item in itemsToRemove)
            {
                this.statusListView.Items.Remove(item);
            }

            this.statusListView.EndUpdate();
        }

        private void startDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.downloadButton_Click(null, null);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.buttonSearch.Focus();
            this.statusListView.ListViewItemSorter = new ListViewItemComparer(0);
            AddToolTips();
        }

        public static void AddSingleToolTip(Control c, string caption)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(c, caption);
        }

        public static  void AddMenuItemToolTip (bool checkable, ToolStripMenuItem item, string caption)
        {
            if (checkable)
            {
                caption += "\nClick to enable/disable this option.";
            }
            item.ToolTipText = caption;
        }

        private void AddToolTips()
        {
            //AddSingleToolTip(buttonSearch, "Find a book by searching for a part of the book title.");
            AddSingleToolTip(buttonBarcodeInitialize, "Find a book by using a DLI book identifier (barcode) that someone has provided.");
            AddSingleToolTip(txtBarcode, "Type/Paste a DLI book barcode that someone has provided, and then click the button to the left.");
            AddSingleToolTip(folderButton, "Choose where to save the DLI book images.");
            AddSingleToolTip(outputFolderLabel, "Choose where to save the DLI book images. If it does not exist, it will be created for you.");
            AddSingleToolTip(serverComboBox, "Choose the DLI server to download the book from.");
            AddSingleToolTip(labelFormatString, "The remote server location to download files from. Only advanced users should change this value.");
            AddSingleToolTip(groupBox1, "Choose the pages to download.");
            AddSingleToolTip(startUpDown, "Choose the first page to download.");
            AddSingleToolTip(endUpDown, "Choose the last page to download.");
            AddSingleToolTip(upDownThreads, "Decide how many pages to download in parallel.");

            AddMenuItemToolTip(false, checkDLIServersToolStripMenuItem, "Contact all of the DLI servers to see if the server is online, and the book is available.");
            AddMenuItemToolTip(false, removeSuccesfulDownloadsFromListToolStripMenuItem, "Remove all downloads that completely successfully, to quickly see the downloads that failed.");
            AddMenuItemToolTip(false, copyBookDetailsToolStripMenuItem, "Copy the book title, barcode and download details to the clipboard");
            AddMenuItemToolTip(true, overwriteExistingFilesToolStripMenuItem, "Download all files, even if they have already been downloaded");

            AddMenuItemToolTip(true, addWatermarkToPDFToolStripMenuItem, "When creating the PDF, write the original DLI file location to the page footer.");
            AddMenuItemToolTip(true, showAdvancedPDFOptionsToolStripMenuItem, "Before creating the PDF, prompt for options to change the pdf quality and size.");
            AddMenuItemToolTip(true, deleteImagesAfterPDFCreationToolStripMenuItem, "After creating the PDF file, delete the temporary image files automatically.");
            AddMenuItemToolTip(true, openPDFAfterCreationToolStripMenuItem, "After creating the PDF, open it in the default PDF application.");

            AddMenuItemToolTip(false, openTargetFolderToolStripMenuItem, "Open the folder to which the images files are being downloaded.");
            AddMenuItemToolTip(false, loadFilesFromFolderToolStripMenuItem, "Load all the file names from a folder to which the image files were previously downloaded.");
            AddMenuItemToolTip(false, notepadToolStripMenuItem, "Open a notepad window to save notes for this DLI book");
        }

        private void copyBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendFormat(
@"Title: {0}
Barcode: {1}
Pages: {2}
Server: {3}
Path: {4}",
                URLTextBox.Text,
                txtBarcode.Text,
                endUpDown.Value,
                serverComboBox.Text,
                labelFormatString.Text);
            outputBuilder.AppendLine();
            outputBuilder.AppendLine();
            foreach (ListViewItem item in this.statusListView.Items)
            {
                outputBuilder.AppendFormat("{0}: {1}",
                    item.SubItems[0].Text,
                    item.SubItems[1].Text);
                outputBuilder.AppendLine();
            }

            Clipboard.SetText(outputBuilder.ToString());
            MessageBox.Show("Details copied to clipboard.");
        }

        private void optimizePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(outputFolderLabel.Text))
            {
                Directory.CreateDirectory(outputFolderLabel.Text);
            }

            DialogResult dialogResult;
            string inputFile = GetInputPDFFilename(out dialogResult);

            this.allWorkerThreads.Clear();
            Thread workerThread = new Thread(new ParameterizedThreadStart(ExtractPDFImages));
            workerThread.Start(inputFile);
            this.allWorkerThreads.Add(workerThread);
        }

        private void ExtractPDFImages(object inputFileObject)
        {
            string inputFile = inputFileObject as string;

            PdfReader reader = new PdfReader(inputFile);
            PdfReaderContentParser parser = new PdfReaderContentParser(reader);
            MyImageRenderListener listener = new MyImageRenderListener(outputFolderLabel.Text, this.statusListView, this);


            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                //string outputStatus = string.Format("Extracting images from page {0:0000}", i);
                //this.statusListView.Invoke(new AddStatusItemDelegate(AddStatusItem), new object[] { outputStatus, string.Empty });
                parser.ProcessContent(i, listener);

                int progress = (int)Math.Ceiling((float)i / (float)reader.NumberOfPages * 100f);
                progressBarBook.Invoke(new SetInt(SetBookProgress), progress);
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            this.downloadButton.Enabled = false;
        }

        private void buttonCreatePDF_Click(object sender, EventArgs e)
        {
            this.CreatePDF();
        }
    }

    public class MyImageRenderListener : IRenderListener
    {
        public void RenderText(TextRenderInfo renderInfo) { }
        public void BeginTextBlock() { }
        public void EndTextBlock() { }

        ListView statusListView;
        string outputPath;
        MainForm mainForm;

        public MyImageRenderListener(string outputPath, ListView statusListView, MainForm form)
        {
            this.statusListView = statusListView;
            this.outputPath = outputPath;
            this.mainForm = form;
        }

        int imageNumber = 1;
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            PdfImageObject image = renderInfo.GetImage();
            try
            {
                image = renderInfo.GetImage();
                if (image == null) return;

                using (MemoryStream ms = new MemoryStream(image.GetImageAsBytes()))
                {
                    string filename = string.Format(@"{0}\Image-{1:0000}.{2}", outputPath, imageNumber++, image.GetFileType());
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(ms.ToArray(), 0, (int)ms.Length);
                    }
                    this.statusListView.Invoke(new MainForm.AddStatusItemDelegate(mainForm.AddStatusItem), new object[] { filename, "Extracted" });
                }
            }
            catch (IOException ie)
            {
                /*
                 * pass-through; image type not supported by iText[Sharp]; e.g. jbig2
                */
            }
        }
    }        
}
