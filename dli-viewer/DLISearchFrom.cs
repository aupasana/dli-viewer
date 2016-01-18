using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace dli_viewer
{
    public partial class DLISearchFrom : Form
    {
        public DLISearchFrom()
        {
            InitializeComponent();
            //this.AcceptButton = ButtonOK;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.listViewSearch.Items.Clear();

            Thread t = new Thread(new ParameterizedThreadStart(Search));
            t.Start(new string[] { this.textBoxSearch.Text, this.comboBoxLanguage.Text, this.comboBoxLocation.Text } );
        }

        delegate void AddLinkItemDelegate(DLISearchItem item);
        delegate void ShowMessageDelegate(string message);
        delegate void SetCursorDelegate(Cursor cursor);
        delegate void EmptyDelegate();

        private void AddLinkItem(DLISearchItem item)
        {
            this.listViewSearch.Items.Add(item);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void SetCursor (Cursor cursor)
        {
            this.Cursor = cursor;
        }

        private void Search(object parametersObject)
        {
            string[] parameters = parametersObject as string[];
            string searchText = parameters[0];
            string searchLanguage = parameters[1];
            string searchLocation = parameters[2];

            string uriString =
                String.Format(@"{0}/cgi-bin/advsearch_db.cgi?perPage=100&listStart={2}&r1=V1&title1={0}&author1=&year1=&year2=&subject1=Any&language1={1}&scentre=Any&search=Search",
                searchLocation,
                searchText,
                searchLanguage,
                (pageNumberUpDown.Value - 1) * 100
                );

            try
            {
                HttpWebRequest request = WebRequest.Create(uriString) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string htmlString = reader.ReadToEnd();

                int index = htmlString.IndexOf(@"Search matched");


                if (index == -1)
                {
                    this.Invoke(new ShowMessageDelegate(ShowMessage), "No results found");
                    return;
                }

                htmlString = htmlString.Substring(0, index);

                Regex hrefRegex = new Regex("<a href=\"([^\"]*)\"");
                MatchCollection matches = hrefRegex.Matches(htmlString);
                int i = ((int)pageNumberUpDown.Value - 1) * 100 + 1;

                EmptyDelegate beginUpdateDelegate = delegate { this.listViewSearch.BeginUpdate(); };
                this.listViewSearch.Invoke(beginUpdateDelegate);

                foreach (Match m in matches)
                {
                    string link = searchLocation + m.Groups[1].Value;
                    DLISearchItem item = new DLISearchItem(link, i++);
                    this.listViewSearch.Invoke(new AddLinkItemDelegate(AddLinkItem), item);
                }

                EmptyDelegate endUpdateDelegate = delegate { this.listViewSearch.EndUpdate(); };
                this.listViewSearch.Invoke(endUpdateDelegate);

                this.listViewSearch.EndUpdate();

                if (listViewSearch.Items.Count == 100)
                {
                    EmptyDelegate updatePageNumber = delegate() { this.pageNumberUpDown.Value++; };
                    this.pageNumberUpDown.Invoke(updatePageNumber);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                this.Invoke(new SetCursorDelegate(SetCursor), Cursors.Default);
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        internal string UrlRelative
        {
            get
            {
                if (this.listViewSearch.SelectedItems.Count <= 0)
                {
                    return string.Empty;
                }
                DLISearchItem item = this.listViewSearch.SelectedItems[0] as DLISearchItem;
                return item.SubItems[8].Text; 
            }
        }
        internal string Url
        {
            get
            {
                if (this.listViewSearch.SelectedItems.Count <= 0)
                {
                    return string.Empty;
                }
                DLISearchItem item  = this.listViewSearch.SelectedItems[0] as DLISearchItem;
                return item.InfoUri.ToString(); 
            }
        }

        internal string TitleValue
        {
            get
            {
                if (this.listViewSearch.SelectedItems.Count <= 0)
                {
                    return string.Empty;
                }
                DLISearchItem item = this.listViewSearch.SelectedItems[0] as DLISearchItem;
                string value = item.SubItems[2].Text;
                return value;
            }
        }

        internal string BarcodeValue
        {
            get
            {
                if (this.listViewSearch.SelectedItems.Count <= 0)
                {
                    return string.Empty;
                }
                DLISearchItem item = this.listViewSearch.SelectedItems[0] as DLISearchItem;
                string value =  item.SubItems[1].Text;
                value = value.TrimEnd(new char[] { '\r', '\n', '\t' });
                return value;
            }
        }

        private void listViewSearch_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                buttonSearch_Click(null, null);
            }
        }

        private DataTable GetSavedSearches()
        {
            DataTable table = new DataTable("savedSearches");
            table.Columns.Add();

            try
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.savedSearches))
                {
                    StringReader reader = new StringReader(Properties.Settings.Default.savedSearches);
                    table.ReadXml(reader);
                }
            }
            catch
            {
            }

            return table;
        }

        private void addToFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.listViewSearch.SelectedItems.Count <= 0)
            //{
            //    return;
            //}

            //DLISearchItem item = new DLISearchItem("abcd", 0);
            //serializer


            //DLISearchItem item = this.listViewSearch.SelectedItems[0] as DLISearchItem;
            //DataTable table = GetSavedSearches();

            //DataRow row = table.NewRow();
            //row[0] = item;
            //table.Rows.Add(row);

            
            //StringBuilder builder = new StringBuilder();
            //StringWriter writer = new StringWriter(builder);
            //table.WriteXml(writer);
            //Properties.Settings.Default.savedSearches = builder.ToString();
        }

        private void loadFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listViewSearch.Items.Clear();

            DataTable table = GetSavedSearches();
            foreach (DataRow row in table.Rows)
            {
                DLISearchItem item = row[0] as DLISearchItem;

                if (item == null)
                {
                    continue;
                }

                this.listViewSearch.Invoke(new AddLinkItemDelegate(AddLinkItem), item);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            this.pageNumberUpDown.Value = 1;
        }

        private void comboBoxLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pageNumberUpDown.Value = 1;
        }

        private void comboBoxLocation_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pageNumberUpDown.Value = 1;
        }

        private void listViewSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewSearch.ListViewItemSorter = new ListViewItemComparer(e.Column); 

        }

        private void pageNumberUpDown_ValueChanged(object sender, EventArgs e)
        {
            int start = (((int)pageNumberUpDown.Value - 1) * 100) + 1;
            int end = start + 99;
            buttonSearch.Text = string.Format("Find Books {0}-{1}", start, end);
        }

        private void DLISearchFrom_Load(object sender, EventArgs e)
        {
            pageNumberUpDown_ValueChanged(null, null);

            MainForm.AddSingleToolTip(pageNumberUpDown, "DLI returns 100 results at a time. Set this value to decide which subset of search results to query");
            MainForm.AddSingleToolTip(textBoxSearch, "Search for a book by entering a portion of it's title. Since the DLI transliteration scheme is not consistent, try different variations.");

            MainForm.AddSingleToolTip(listViewSearch, "Select this item, and press 'enter' or click the 'OK' button to choose this book.\nClick on the column headers to sort the page of results.");
        }

    }

    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }
    [Serializable]
    public class DLISearchItem : ListViewItem
    {
        Uri uri = null;

        public DLISearchItem() : base ()
        {
        }

        internal DLISearchItem(string link, int i)
        {
            uri = new Uri(link);
            string query = uri.Query;

            this.ToolTipText = link;

            NameValueCollection collection = HttpUtility.ParseQueryString(uri.Query);

            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> urlParameters = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                if (null != key)
                {
                    urlParameters.Add(key, collection.Get(key));
                    sb.Append(String.Format("{0}: {1}. ", key, collection.Get(key)));
                }
            }

            this.Text = string.Format("{0:000}", i);
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "barcode" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "title1" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "author1" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "language1" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "year" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "pages" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "publisher1" })));
            this.SubItems.Add(new ListViewSubItem(this, MainForm.FindDictionaryValueForKey(urlParameters, new string[] { "url" })));
            this.SubItems.Add(new ListViewSubItem(this, sb.ToString()));
        }

        internal Uri InfoUri
        {
            get { return this.uri; }
        }
    }
}
