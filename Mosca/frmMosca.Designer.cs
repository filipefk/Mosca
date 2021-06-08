namespace Mosca
{
    partial class frmMosca
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
            this.tmrMove = new System.Windows.Forms.Timer(this.components);
            this.picMosca = new System.Windows.Forms.PictureBox();
            this.tmrGira = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMosca)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMove
            // 
            this.tmrMove.Interval = 5000;
            this.tmrMove.Tick += new System.EventHandler(this.tmrMove_Tick);
            // 
            // picMosca
            // 
            this.picMosca.Location = new System.Drawing.Point(12, 12);
            this.picMosca.Name = "picMosca";
            this.picMosca.Size = new System.Drawing.Size(51, 51);
            this.picMosca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMosca.TabIndex = 0;
            this.picMosca.TabStop = false;
            this.picMosca.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMosca_MouseDown);
            this.picMosca.MouseEnter += new System.EventHandler(this.picMosca_MouseEnter);
            this.picMosca.MouseHover += new System.EventHandler(this.picMosca_MouseHover);
            // 
            // tmrGira
            // 
            this.tmrGira.Enabled = true;
            this.tmrGira.Interval = 5000;
            this.tmrGira.Tick += new System.EventHandler(this.tmrGira_Tick);
            // 
            // frmMosca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(76, 74);
            this.Controls.Add(this.picMosca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMosca";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmMosca";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMosca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMosca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMosca;
        private System.Windows.Forms.Timer tmrMove;
        private System.Windows.Forms.Timer tmrGira;
    }
}