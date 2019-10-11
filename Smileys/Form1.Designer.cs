namespace Smileys
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
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tssBottom = new System.Windows.Forms.ToolStripStatusLabel();
            this.flpSmileys = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbAllwaysOnTop = new System.Windows.Forms.CheckBox();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.ssBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssBottom
            // 
            this.ssBottom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssBottom});
            this.ssBottom.Location = new System.Drawing.Point(0, 245);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssBottom.Size = new System.Drawing.Size(287, 25);
            this.ssBottom.SizingGrip = false;
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "ssBottom";
            // 
            // tssBottom
            // 
            this.tssBottom.Name = "tssBottom";
            this.tssBottom.Size = new System.Drawing.Size(76, 20);
            this.tssBottom.Text = "tssBottom";
            // 
            // flpSmileys
            // 
            this.flpSmileys.AutoScroll = true;
            this.flpSmileys.BackColor = System.Drawing.Color.White;
            this.flpSmileys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSmileys.Location = new System.Drawing.Point(0, 0);
            this.flpSmileys.Margin = new System.Windows.Forms.Padding(4);
            this.flpSmileys.Name = "flpSmileys";
            this.flpSmileys.Size = new System.Drawing.Size(287, 212);
            this.flpSmileys.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flpSmileys);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbAllwaysOnTop);
            this.splitContainer1.Panel2.Controls.Add(this.cbSize);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(287, 245);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            // 
            // cbAllwaysOnTop
            // 
            this.cbAllwaysOnTop.AutoSize = true;
            this.cbAllwaysOnTop.Checked = true;
            this.cbAllwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllwaysOnTop.Location = new System.Drawing.Point(127, 6);
            this.cbAllwaysOnTop.Margin = new System.Windows.Forms.Padding(4);
            this.cbAllwaysOnTop.Name = "cbAllwaysOnTop";
            this.cbAllwaysOnTop.Size = new System.Drawing.Size(128, 21);
            this.cbAllwaysOnTop.TabIndex = 1;
            this.cbAllwaysOnTop.Text = "Allways On Top";
            this.cbAllwaysOnTop.UseVisualStyleBackColor = true;
            this.cbAllwaysOnTop.CheckedChanged += new System.EventHandler(this.cbAllwaysOnTop_CheckedChanged);
            // 
            // cbSize
            // 
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(4, 4);
            this.cbSize.Margin = new System.Windows.Forms.Padding(4);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(113, 24);
            this.cbSize.TabIndex = 0;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 270);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ssBottom);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1011, 781);
            this.MinimumSize = new System.Drawing.Size(302, 307);
            this.Name = "MainForm";
            this.Text = "Smileys";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripStatusLabel tssBottom;
        private System.Windows.Forms.FlowLayoutPanel flpSmileys;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.CheckBox cbAllwaysOnTop;
    }
}

