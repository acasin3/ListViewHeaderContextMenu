# Adding Context Menu on ListView Column Headers To Show or Hide Columns

While the listview control has a ContextMenuStrip property for items, it does not have one for the column headers. 

The intuitive approach to implement this would be to add code to the listview's ColumnClick event. But doing it this way is not possible since the ColumnClickEventArgs does not expose which mouse button was clicked. As we know, the context menu appears when the mouse is right-clicked.

An alternative approach is to build upon the demo project [Handling Right-Click Events in ListView Column Headers](https://www.codeproject.com/Articles/23330/Handling-Right-Click-Events-in-ListView-Column-Hea) in Code Project. 

Below are the code blocks of interest to implement context menu to hide or show columns:

**Form1.cs**
```C#
        private ColumnHeader _columnHeader1;
        private ColumnHeader _columnHeader2;
        private ColumnHeader _columnHeader3;

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

        private void HandleRightClickOnHeader(ColumnHeader header)
        {
            // We can do anything here, but most likely we want to 
            // display a context menu for the header.  This code
            // displays the same context menu for every header.
            headerMenu.Show(Control.MousePosition);
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
```

**Form1.Designer.cs**
```C#
        private void InitializeComponent()
        {
            this.headerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.One = new System.Windows.Forms.ToolStripMenuItem();
            this.Two = new System.Windows.Forms.ToolStripMenuItem();
            this.Three = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // headerMenu
            // 
            this.headerMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.headerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.One,
            this.Two,
            this.Three});
            this.headerMenu.Name = "headerMenu";
            this.headerMenu.Size = new System.Drawing.Size(116, 82);
            // 
            // One
            // 
            this.One.Checked = true;
            this.One.CheckState = System.Windows.Forms.CheckState.Checked;
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(115, 26);
            this.One.Text = "One";
            this.One.Click += new System.EventHandler(this.HeaderMenuClick);
            // 
            // Two
            // 
            this.Two.Checked = true;
            this.Two.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(115, 26);
            this.Two.Text = "Two";
            this.Two.Click += new System.EventHandler(this.HeaderMenuClick);
            // 
            // Three
            // 
            this.Three.Checked = true;
            this.Three.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(115, 26);
            this.Three.Text = "Three";
            this.Three.Click += new System.EventHandler(this.HeaderMenuClick);
        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip headerMenu;
        private System.Windows.Forms.ToolStripMenuItem One;
        private System.Windows.Forms.ToolStripMenuItem Two;
        private System.Windows.Forms.ToolStripMenuItem Three;
```
## Screenshots
#### Context Menu for ListView With All Headers Visible
![image](https://github.com/acasin3/ListViewHeaderContextMenu/assets/59311849/73b3e75b-a098-471f-bc95-edde0df04acc)

#### Context Menu for ListView With Column Two Hidden
![image](https://github.com/acasin3/ListViewHeaderContextMenu/assets/59311849/0dbba9a1-28e6-4bd0-9a64-a27ba92fec62)

#### ListView Items Context Menu
![image](https://github.com/acasin3/ListViewHeaderContextMenu/assets/59311849/862abc3d-5bdf-4661-839a-6aa7b91dcc73)



