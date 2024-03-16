using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ListViewHeaderContextMenu
{
    public partial class Form1 : Form
    {

        private ColumnHeader _columnHeader1;
        private ColumnHeader _columnHeader2;
        private ColumnHeader _columnHeader3;

        // The area occupied by the ListView header. 
        private Rectangle _headerRect;

        public Form1()
        {
            InitializeComponent();
            SetupListView();

            headerMenu.Items[0].Tag = _columnHeader1;
            headerMenu.Items[1].Tag = _columnHeader2;
            headerMenu.Items[2].Tag = _columnHeader3;
        }

        private void SetupListView()
        {

            // Define column headers
            _columnHeader1 = new ColumnHeader();
            _columnHeader2 = new ColumnHeader();
            _columnHeader3 = new ColumnHeader();

            // Add column headers
            listView1.Columns.AddRange(new ColumnHeader[] {
                _columnHeader1,
                _columnHeader2,
                _columnHeader3
            });

            _columnHeader1.Text = "One";
            _columnHeader2.Text = "Two";
            _columnHeader3.Text = "Three";

            // Add listview item
            ListViewItem lvi = new ListViewItem(
                new string[] {
                                "data 1",
                                "data 2",
                                "data 3"
                }
            );
            listView1.Items.Add(lvi);
        }

        // This returns an array of ColumnHeaders in the order they are displayed by the ListView.
        private static ColumnHeader[] GetOrderedHeaders(ListView lv)
        {
            ColumnHeader[] arr = new ColumnHeader[lv.Columns.Count];

            foreach (ColumnHeader header in lv.Columns)
            {
                arr[header.DisplayIndex] = header;
            }

            return arr;
        }    

        // Called when the user right-clicks anywhere in the ListView, including the
        // header bar.  It displays the appropriate context menu for the data row or
        // header that was right-clicked. 
        private void regularListViewMenu_Opening(object sender, CancelEventArgs e)
        {
            // This call indirectly calls EnumWindowCallBack which sets _headerRect
            // to the area occupied by the ListView's header bar.
            EnumChildWindows(listView1.Handle, new EnumWinCallBack(EnumWindowCallBack), IntPtr.Zero);

            // If the mouse position is in the header bar, cancel the display
            // of the regular context menu and display the column header context menu instead.
            if (_headerRect.Contains(Control.MousePosition))
            {
                e.Cancel = true;
                HandleRightClickOnHeader();
            }
            else
            {
                // Allow the regular context menu to be displayed.
                // We may want to update the menu here.
            }
        }

        private void HandleRightClickOnHeader()
        {
            // We can do anything here, but most likely we want to 
            // display a context menu for the header.  This code
            // displays the same context menu for every header.
            headerMenu.Show(Control.MousePosition);
        }


        // This should get called with the only child window of the ListView,
        // which should be the header bar.
        private bool EnumWindowCallBack(IntPtr hwnd, IntPtr lParam)
        {
            // Determine the rectangle of the ListView header bar and save it in _headerRect.
            RECT rct;

            if (!GetWindowRect(hwnd, out rct))
            {
                _headerRect = Rectangle.Empty;
            }
            else
            {
                _headerRect = new Rectangle(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
            }

            return false; // Stop the enum
        }


        // Delegate that is called for each child window of the ListView.
        private delegate bool EnumWinCallBack(IntPtr hwnd, IntPtr lParam);

        // Calls EnumWinCallBack for each child window of hWndParent (i.e. the ListView).
        [DllImport("user32.Dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, EnumWinCallBack callBackFunc, IntPtr lParam);

        // Gets the bounding rectangle of the specified window (ListView header bar).
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private void HeaderMenuClick(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            int itemIndex = headerMenu.Items.IndexOf(clickedItem);
            ColumnHeader ch = (ColumnHeader)clickedItem.Tag;

            // toggle check mark
            clickedItem.Checked = !clickedItem.Checked;

            if (clickedItem.Checked)
            {
                int i = 0;
                int visibleColumnHeaderCount = 0;

                // Loop through the header menu context items before itemIndex and count the checked ones
                while (i < itemIndex)
                {
                    ToolStripMenuItem currentMenuItem = (ToolStripMenuItem)headerMenu.Items[i];
                    if (currentMenuItem.Checked)
                    {
                        // accumulate
                        visibleColumnHeaderCount++;
                    }
                    // increment for the next pass
                    i++;
                }
                // Re-insert the column. The column to be inserted's index is equal to visibleColumnHeaderCount.
                listView1.Columns.Insert(visibleColumnHeaderCount, ch);
            }
            else
            {
                if (listView1.Columns.Count > 1)
                {
                    listView1.Columns.Remove(ch);
                }
                else
                {
                    MessageBox.Show("At least 1 column must be visible.");
                }
            }
        }
    }
}