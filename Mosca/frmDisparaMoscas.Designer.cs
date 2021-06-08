namespace Mosca
{
    partial class frmDisparaMoscas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisparaMoscas));
            this.tmrDisparaMoscas = new System.Windows.Forms.Timer(this.components);
            this.tmrControleItens = new System.Windows.Forms.Timer(this.components);
            this.tmrComandosAleatorios = new System.Windows.Forms.Timer(this.components);
            this.tmrRoubarMouse = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrDisparaMoscas
            // 
            this.tmrDisparaMoscas.Interval = 500;
            this.tmrDisparaMoscas.Tick += new System.EventHandler(this.tmrDisparaMoscas_Tick);
            // 
            // tmrControleItens
            // 
            this.tmrControleItens.Interval = 1000;
            this.tmrControleItens.Tick += new System.EventHandler(this.tmrControleItens_Tick);
            // 
            // tmrComandosAleatorios
            // 
            this.tmrComandosAleatorios.Interval = 10000;
            this.tmrComandosAleatorios.Tick += new System.EventHandler(this.tmrComandosAleatorios_Tick);
            // 
            // tmrRoubarMouse
            // 
            this.tmrRoubarMouse.Interval = 5000;
            this.tmrRoubarMouse.Tick += new System.EventHandler(this.tmrRoubarMouse_Tick);
            // 
            // frmDisparaMoscas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisparaMoscas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dispara Moscas";
            this.Load += new System.EventHandler(this.frmDisparaMoscas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDisparaMoscas;
        private System.Windows.Forms.Timer tmrControleItens;
        private System.Windows.Forms.Timer tmrComandosAleatorios;
        private System.Windows.Forms.Timer tmrRoubarMouse;

    }
}

