namespace Mosca
{
    partial class frmItem
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
            this.picItem = new System.Windows.Forms.PictureBox();
            this.tmrSumir = new System.Windows.Forms.Timer(this.components);
            this.tmrMouseLeave = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // picItem
            // 
            this.picItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picItem.Image = global::Mosca.Properties.Resources.Merda;
            this.picItem.Location = new System.Drawing.Point(12, 12);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(86, 81);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItem.TabIndex = 0;
            this.picItem.TabStop = false;
            this.picItem.DoubleClick += new System.EventHandler(this.picItem_DoubleClick);
            this.picItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picItem_MouseDown);
            this.picItem.MouseEnter += new System.EventHandler(this.picItem_MouseEnter);
            this.picItem.MouseLeave += new System.EventHandler(this.picItem_MouseLeave);
            this.picItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picItem_MouseMove);
            this.picItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picItem_MouseUp);
            // 
            // tmrSumir
            // 
            this.tmrSumir.Enabled = true;
            this.tmrSumir.Interval = 40000;
            this.tmrSumir.Tick += new System.EventHandler(this.tmrSumir_Tick);
            // 
            // tmrMouseLeave
            // 
            this.tmrMouseLeave.Interval = 5000;
            this.tmrMouseLeave.Tick += new System.EventHandler(this.tmrMouseLeave_Tick);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(110, 105);
            this.Controls.Add(this.picItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmMosca";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Timer tmrSumir;
        private System.Windows.Forms.Timer tmrMouseLeave;
    }
}