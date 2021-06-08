using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Collections;

namespace Mosca
{
    public partial class frmItem : Form
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        private bool _MousePressionado = false;
        private Point _PosicaoInicial = new Point(0, 0);
        public ArrayList Moscas = new ArrayList();

        public enum enuTipoItem
        {
            Aleatorio,
            Merda,
            Lixo
        }


        public frmItem(enuTipoItem p_Tipo)
        {
            InitializeComponent();
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;
            switch (p_Tipo)
            {
                case enuTipoItem.Aleatorio:
                    int _Numero = GetRandomNumber(1, 3);
                    switch (_Numero)
	                {
                        case 1:
                            picItem.Image = Mosca.Properties.Resources.Merda;
                            break;

                        case 2:
                            picItem.Image = Mosca.Properties.Resources.Lixo;
                            break;

                        default:
                            picItem.Image = Mosca.Properties.Resources.Merda;
                            break;
	                }

                    break;

                case enuTipoItem.Merda:
                    picItem.Image = Mosca.Properties.Resources.Merda;
                    break;

                case enuTipoItem.Lixo:
                    picItem.Image = Mosca.Properties.Resources.Lixo;
                    break;
            }

            int _PosX = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Width - 100);
            int _PosY = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Height - 100);
            this.Location = new Point(_PosX, _PosY);
            Application.DoEvents();

        }

        private void tmrSumir_Tick(object sender, EventArgs e)
        {
            tmrSumir.Enabled = false;
            this.Close();
            this.Dispose();
        }

        private void picItem_MouseDown(object sender, MouseEventArgs e)
        {
            _MousePressionado = true;
            _PosicaoInicial = new Point(e.X, e.Y);
        }

        private void picItem_MouseUp(object sender, MouseEventArgs e)
        {
            _MousePressionado = false;
            foreach (frmMosca _Mosca in Moscas)
            {
                _Mosca.TopMost = false;
                _Mosca.TopMost = true;
            }
        }

        private void picItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MousePressionado)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - _PosicaoInicial.X, p.Y - _PosicaoInicial.Y);
            }
        }

        private void picItem_MouseEnter(object sender, EventArgs e)
        {
            tmrMouseLeave.Enabled = false;
            foreach (frmMosca _Mosca in Moscas)
            {
                _Mosca.FugirDestaComida = this;
            }
        }

        private void picItem_MouseLeave(object sender, EventArgs e)
        {
            tmrMouseLeave.Enabled = true;
            
        }

        private void tmrMouseLeave_Tick(object sender, EventArgs e)
        {
            tmrMouseLeave.Enabled = false;
            foreach (frmMosca _Mosca in Moscas)
            {
                _Mosca.FugirDestaComida = null;
            }
        }

        private void picItem_DoubleClick(object sender, EventArgs e)
        {
            picItem.Image = null;
        }
    }
}
