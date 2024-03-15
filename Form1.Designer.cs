namespace ListViewHeaderContextMenu
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.regularListViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewCommand2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.headerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.One = new System.Windows.Forms.ToolStripMenuItem();
            this.Two = new System.Windows.Forms.ToolStripMenuItem();
            this.Three = new System.Windows.Forms.ToolStripMenuItem();
            this.regularListViewMenu.SuspendLayout();
            this.headerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.ContextMenuStrip = this.regularListViewMenu;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 42);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(710, 294);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // regularListViewMenu
            // 
            this.regularListViewMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.regularListViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.listViewCommand2ToolStripMenuItem});
            this.regularListViewMenu.Name = "regularListViewMenu";
            this.regularListViewMenu.Size = new System.Drawing.Size(218, 52);
            this.regularListViewMenu.Opening += new System.ComponentModel.CancelEventHandler(this.regularListViewMenu_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 24);
            this.toolStripMenuItem1.Text = "ListView Command 1";
            // 
            // listViewCommand2ToolStripMenuItem
            // 
            this.listViewCommand2ToolStripMenuItem.Name = "listViewCommand2ToolStripMenuItem";
            this.listViewCommand2ToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.listViewCommand2ToolStripMenuItem.Text = "ListView Command 2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Right click a column header to show the context menu that allows showing or hidin" +
    "g a column.";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Right Click a Header";
            this.regularListViewMenu.ResumeLayout(false);
            this.headerMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip regularListViewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listViewCommand2ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip headerMenu;
        private System.Windows.Forms.ToolStripMenuItem One;
        private System.Windows.Forms.ToolStripMenuItem Two;
        private System.Windows.Forms.ToolStripMenuItem Three;
    }
}

