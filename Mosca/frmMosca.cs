using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Collections;

namespace Mosca
{
    public partial class frmMosca : Form
    {
        private bool _ComSom = true;
        private bool _SeguirOMouse = false;
        private int _QualMosca = 1;
        ArrayList _Comidas = new ArrayList();
        public frmItem FugirDestaComida = null;

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        /// <summary>
        /// Retorna ou salva o indicador se deve ou não fazer Bzzzz quando voa
        /// </summary>
        public bool ComSom
        {
            get
            {
                return _ComSom;
            }
            set
            {
                _ComSom = value;
            }
        }

        /// <summary>
        /// Retorna ou salva o indicador se deve seguir o mouse ou figir do mouse
        /// </summary>
        public bool SeguirOMouse
        {
            get
            {
                return _SeguirOMouse;
            }
            set
            {
                _SeguirOMouse = value;
            }
        }

        /// <summary>
        /// Retorna ou define a lista de frmItem que são comida
        /// </summary>
        public ArrayList Comidas
        {
            get
            {
                return _Comidas;
            }
            set
            {
                _Comidas = value;
            }
        }

        public void RoubarMouse()
        {
            int _PosXFinal = 0;
            int _PosYFinal = 0;
            bool _bkp_SeguirOMouse = _SeguirOMouse;

            tmrMove.Enabled = false;

            _SeguirOMouse = true;

            this.MoverParaMouse();
            Application.DoEvents();
            Application.DoEvents();

            _PosXFinal = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Width);
            _PosYFinal = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Height);

            this.MoverPara(_PosXFinal, _PosYFinal, true);

            _SeguirOMouse = _bkp_SeguirOMouse;

            tmrMove.Enabled = true;
        }

        private void MoverParaMouse()
        {
            int _PosXFinal = 0;
            int _PosYFinal = 0;

            _PosXFinal = Cursor.Position.X - 40;
            _PosYFinal = Cursor.Position.Y - 40;

            this.MoverPara(_PosXFinal, _PosYFinal, false);
        }

        private void MoverAleatorio()
        {
            int _PosXFinal = 0;
            int _PosYFinal = 0;

            _PosXFinal = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Width);
            _PosYFinal = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Height);

            this.MoverPara(_PosXFinal, _PosYFinal, false);
        }

        private void MoverPara(int p_PosX, int p_PosY, bool p_CarregarMouse)
        {
            bool _Parar = false;
            int _PosX = this.Location.X;
            int _PosY = this.Location.Y;

            while (!_Parar)
            {
                if (_PosX > p_PosX)
                {
                    _PosX--;
                }
                if (_PosY > p_PosY)
                {
                    _PosY--;
                }
                if (_PosX < p_PosX)
                {
                    _PosX++;
                }
                if (_PosY < p_PosY)
                {
                    _PosY++;
                }
                if ((_PosY == p_PosY) && (_PosX == p_PosX))
                {
                    _Parar = true;
                }

                this.Location = new Point(_PosX, _PosY);
                if (p_CarregarMouse)
                {
                    Cursor.Position = new Point(_PosX + 20, _PosY + 20);
                }
                Application.DoEvents();

                _PosX = this.Location.X;
                _PosY = this.Location.Y;
            }
        }

        private void Bzzzzz() 
        {
            if (_ComSom)
            {
                Stream str = Properties.Resources.Som_de_Mosca;
                SoundPlayer snd = new SoundPlayer(str);
                //snd.LoadTimeout = 0; // GetRandomNumber(500, 1000);
                snd.Play();
            }
        }

        public frmMosca()
        {
            InitializeComponent();
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;
            picMosca.MouseWheel += picMosca_MouseWheel;
        }

        private void picMosca_MouseWheel(object sender, MouseEventArgs e)
        {
            // If the mouse wheel is moved forward (Zoom in)
            tmrGira.Interval = 2000;
            if (e.Delta > 0)
            {
                _QualMosca++;
                if (_QualMosca > 4)
                {
                    _QualMosca = 1;
                }
            }
            else
            {
                _QualMosca--;
                if (_QualMosca < 0)
                {
                    _QualMosca = 4;
                }
            }
            switch (_QualMosca)
            {
                case 1:
                    picMosca.Image = Mosca.Properties.Resources.Mosca01;
                    break;
                case 2:
                    picMosca.Image = Mosca.Properties.Resources.Mosca02;
                    break;
                case 3:
                    picMosca.Image = Mosca.Properties.Resources.Mosca03;
                    break;
                case 4:
                    picMosca.Image = Mosca.Properties.Resources.Mosca04;
                    break;
            }
            //tmrGira.Enabled = false;
            
        }

        private void frmMosca_Load(object sender, EventArgs e)
        {
            int _PosX = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Width);
            int _PosY = GetRandomNumber(0, Screen.FromControl(this).WorkingArea.Height);
            this.Location = new Point(_PosX, _PosY);
            tmrMove.Interval = GetRandomNumber(2000, 5001);
            tmrMove.Enabled = true;
        }

        private void GiraMosca()
        {
            _QualMosca = GetRandomNumber(1, 5);
            switch (_QualMosca)
            {
                case 1:
                    picMosca.Image = Mosca.Properties.Resources.Mosca01;
                    break;
                case 2:
                    picMosca.Image = Mosca.Properties.Resources.Mosca02;
                    break;
                case 3:
                    picMosca.Image = Mosca.Properties.Resources.Mosca03;
                    break;
                case 4:
                    picMosca.Image = Mosca.Properties.Resources.Mosca04;
                    break;
            }
        }
        
        private void MoveMosca()
        {
            this.Bzzzzz();
            this.GiraMosca();

            if (_SeguirOMouse)
            {
                this.MoverParaMouse();
            }
            else
            {
                if (Comidas.Count > 0)
                {
                    if (GetRandomNumber(1, 10) == 1)
                    {
                        this.MoverAleatorio();
                    }
                    else
                    {
                        int _QualComida = 0;
                        int _PosXFinal = 0;
                        int _PosYFinal = 0;

                        _QualComida = GetRandomNumber(0, Comidas.Count);
                        frmItem _frmItem = (frmItem)Comidas[_QualComida];

                        // Pegando canto esquerdo superior do form
                        _PosXFinal = _frmItem.Location.X;
                        _PosYFinal = _frmItem.Location.Y;

                        if (FugirDestaComida != null)
                        {
                            if (FugirDestaComida.Location.X == _PosXFinal && FugirDestaComida.Location.Y == _PosYFinal)
                            {
                                this.MoverAleatorio();
                            }
                            else
                            {
                                _PosXFinal = GetRandomNumber(_PosXFinal + 10, _PosXFinal + 50);
                                _PosYFinal = GetRandomNumber(_PosYFinal + 10, _PosYFinal + 50);
                                this.MoverPara(_PosXFinal, _PosYFinal, false);
                            }
                        }
                        else
                        {
                            _PosXFinal = GetRandomNumber(_PosXFinal + 10, _PosXFinal + 50);
                            _PosYFinal = GetRandomNumber(_PosYFinal + 10, _PosYFinal + 50);
                            this.MoverPara(_PosXFinal, _PosYFinal, false);
                        }
                    }
                }
                else
                {
                    this.MoverAleatorio();
                }
            }

            tmrMove.Interval = GetRandomNumber(2000, 5001);
        }

        private void tmrMove_Tick(object sender, EventArgs e)
        {
            tmrMove.Enabled = false;
            this.MoveMosca();
            tmrMove.Interval = GetRandomNumber(1000, 10001);
            tmrMove.Enabled = true;
        }

        private void picMosca_MouseEnter(object sender, EventArgs e)
        {
            if (!_SeguirOMouse)
            {
                this.MoveMosca();
            }
        }

        public void MataMosca()
        {
            tmrMove.Enabled = false;
            picMosca.SizeMode = PictureBoxSizeMode.Zoom;
            picMosca.Image = Properties.Resources.Mosca_Morta2;
            Application.DoEvents();
        }

        private void tmrGira_Tick(object sender, EventArgs e)
        {
            tmrGira.Enabled = false;
            this.GiraMosca();
            tmrGira.Interval = GetRandomNumber(500, 5000);
            tmrGira.Enabled = true;
        }

        private void picMosca_MouseDown(object sender, MouseEventArgs e)
        {
            if (_SeguirOMouse)
            {
                _SeguirOMouse = false;
                this.MoveMosca();
                if (e.Button == MouseButtons.Left)
                {
                    _SeguirOMouse = true;
                }
            }
            else
            {
                this.MoveMosca();
            }
            
        }

        private void picMosca_MouseHover(object sender, EventArgs e)
        {
            picMosca.Focus();
        }

    }
}
