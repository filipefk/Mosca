using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace Mosca
{
    public partial class frmDisparaMoscas : Form
    {
        private NotifyIcon _SysTray = new NotifyIcon();
        private ContextMenu _SysTrayMenu;
        private int _Quant = GetRandomNumber(1, 10);
        //private frmMosca[] _Moscas = null;
        ArrayList _Moscas = new ArrayList();
        ArrayList _Comidas = new ArrayList();
        private bool _ComSom = true;
        private bool _SeguirOMouse = false;
        private bool _ComSysTray = true;
        private bool _ComandosAleatorios = false;

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }

        private void InicializaSysTray()
        {
            _SysTrayMenu = new ContextMenu();
            if (_ComSom) // 0
            {
                _SysTrayMenu.MenuItems.Add("Sem Som", OnSom);
            }
            else
            {
                _SysTrayMenu.MenuItems.Add("Com Som", OnSom);
            }
            if (_SeguirOMouse) // 1
            {
                _SysTrayMenu.MenuItems.Add("Fugir do Mouse", OnSeguirMouse);
            }
            else
            {
                _SysTrayMenu.MenuItems.Add("Seguir o mouse", OnSeguirMouse);
            }

            _SysTrayMenu.MenuItems.Add("Dar Comida", OnDarComida); // 2
            _SysTrayMenu.MenuItems.Add("Mais Uma Mosca", OnMaisUmaMosca); // 3
            _SysTrayMenu.MenuItems.Add("Menos Uma Mosca", OnMenosUmaMosca); // 4
            _SysTrayMenu.MenuItems.Add("Roubar o Mouse", OnRoubarMouse); // 5

            if (_ComandosAleatorios) // 6
            {
                _SysTrayMenu.MenuItems.Add("Para Comandos Aleatorios", OnComandosAleatorios);
            }
            else
            {
                _SysTrayMenu.MenuItems.Add("Iniciar Comandos Aleatorios", OnComandosAleatorios);
            }

            _SysTrayMenu.MenuItems.Add("Matar as moscas", OnExit); // 6
            

            _SysTray.Text = "Bzzzzzzz";
            _SysTray.Icon = this.Icon;

            _SysTray.Visible = _ComSysTray;
            _SysTray.ContextMenu = _SysTrayMenu;
        }

        private void FormTransparente()
        {
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public frmDisparaMoscas()
        {
            InitializeComponent();
            this.InicializaSysTray();
        }

        public frmDisparaMoscas(int p_Quant)
        {
            InitializeComponent();
            _SysTrayMenu = new ContextMenu();
            this.InicializaSysTray();
            if (p_Quant > 0)
            {
                _Quant = p_Quant;
            }
        }

        public frmDisparaMoscas(int p_Quant, string p_Comando)
        {
            InitializeComponent();
            _SysTrayMenu = new ContextMenu();
            if (p_Comando.IndexOf("SEM_SYSTRAY", 0) > -1)
            {
                _ComSysTray = false;
            }
            if (p_Comando.IndexOf("SEM_SOM", 0) > -1)
            {
                _ComSom = false;
            }
            if (p_Comando.IndexOf("SEGUIR_O_MOUSE", 0) > -1)
            {
                _SeguirOMouse = true;
            }
            if (p_Comando.IndexOf("COMANDOS_ALEATORIOS", 0) > -1)
            {
                _ComandosAleatorios = true;
            }
            if (_ComSysTray)
            {
                this.InicializaSysTray();
            }
            
            if (p_Quant > 0)
            {
                _Quant = p_Quant;
            }

            tmrComandosAleatorios.Enabled = _ComandosAleatorios;
        }

        private void _MenosUmaMosca()
        {
            if ((_Quant == 0) || (_Moscas.Count == 0))
            {
                return;
            }
            _Quant--;
            _SysTray.Text = "Bzzzzzzz " + _Quant.ToString();
            frmMosca _Mosca = (frmMosca)_Moscas[0];
            _Moscas.Remove(_Mosca);
            _Mosca.Close();
            _Mosca.Dispose();
        }

        private void _MaisUmaMosca()
        {
            _Quant++;
            tmrDisparaMoscas.Enabled = true;
            _SysTray.Text = "Bzzzzzzz " + _Quant.ToString();
        }

        private void _DarComida()
        {
            frmItem _frmItem = new frmItem(frmItem.enuTipoItem.Aleatorio);
            _frmItem.Show();
            Application.DoEvents();
            _frmItem.Moscas = _Moscas;
            _Comidas.Add(_frmItem);
            foreach (frmMosca _Mosca in _Moscas)
            {
                _Mosca.Comidas = _Comidas;
                _Mosca.TopMost = false;
                _Mosca.TopMost = true;
            }

            tmrControleItens.Enabled = true;
        }

        private void _SeguirMouse()
        {
            _SeguirOMouse = !_SeguirOMouse;
            foreach (frmMosca _Mosca in _Moscas)
            {
                _Mosca.SeguirOMouse = _SeguirOMouse;
            }
            if (_ComSysTray)
            {
                if (_SeguirOMouse)
                {
                    _SysTrayMenu.MenuItems[1].Text = "Fugir do Mouse";
                }
                else
                {
                    _SysTrayMenu.MenuItems[1].Text = "Seguir o mouse";
                }
            }
            
            Application.DoEvents();
        }

        private void _Som()
        {
            _ComSom = !_ComSom;
            foreach (frmMosca _Mosca in _Moscas)
            {
                _Mosca.ComSom = _ComSom;
            }
            if (_ComSysTray)
            {
                if (_ComSom)
                {
                    _SysTrayMenu.MenuItems[0].Text = "Sem Som";
                }
                else
                {
                    _SysTrayMenu.MenuItems[0].Text = "Com Som";
                }
            }
            
            Application.DoEvents();
        }

        private void _Exit()
        {
            foreach (frmMosca _Mosca in _Moscas)
            {
                _Mosca.MataMosca();
                Application.DoEvents();
            }

            Thread.Sleep(2000);
            _SysTray.Visible = false;
            Application.Exit();
        }

        private void _ComandoAleatorio()
        {
            int _Sorteio = GetRandomNumber(0, 20);

            //this._MenosUmaMosca();
            //this._MaisUmaMosca();
            //this._DarComida();
            //this._Som();
            //this._Exit();

            switch (_Sorteio)
            {
                case 0:
                    if (_Moscas.Count == 0)
                    {
                        this._MaisUmaMosca();
                    }
                    else
                    {
                        this._MenosUmaMosca();
                    }
                    break;
                case 1:
                    this._MaisUmaMosca();
                    break;
                case 2:
                    if (_Moscas.Count == 0)
                    {
                        this._MaisUmaMosca();
                    }
                    else
                    {
                        this._DarComida();
                    }
                    break;
                case 3:
                    if (_Moscas.Count == 0)
                    {
                        this._MaisUmaMosca();
                    }
                    else
                    {
                        this._Som();
                    }
                    break;
                case 4:
                    if (_Moscas.Count == 0)
                    {
                        this._MaisUmaMosca();
                    }
                    else
                    {
                        this._SeguirMouse();
                    }
                    break;
                case 5:
                    if (_Moscas.Count == 0)
                    {
                        this._MaisUmaMosca();
                    }
                    else
                    {
                        this._RoubarMouse();
                    }
                    break;
            }
        }

        private void OnComandosAleatorios(object sender, EventArgs e)
        {
            _ComandosAleatorios = !_ComandosAleatorios;
            tmrComandosAleatorios.Enabled = _ComandosAleatorios;

            if (_ComSysTray)
            {
                if (_ComandosAleatorios)
                {
                    _SysTrayMenu.MenuItems[6].Text = "Para Comandos Aleatorios";
                }
                else
                {
                    _SysTrayMenu.MenuItems[6].Text = "Iniciar Comandos Aleatorios";
                }
            }
            

        }

        private void _RoubarMouse()
        {
            tmrRoubarMouse.Enabled = true;
        }

        private void OnRoubarMouse(object sender, EventArgs e)
        {
            this._RoubarMouse();
        }

        private void OnMenosUmaMosca(object sender, EventArgs e)
        {
            this._MenosUmaMosca();
        }

        private void OnMaisUmaMosca(object sender, EventArgs e)
        {
            this._MaisUmaMosca();
        }

        private void OnDarComida(object sender, EventArgs e)
        {
            this._DarComida();
        }

        private void OnSeguirMouse(object sender, EventArgs e)
        {
            this._SeguirMouse();
        }

        private void OnSom(object sender, EventArgs e)
        {
            this._Som();
        }

        private void OnExit(object sender, EventArgs e)
        {
            this._Exit();
        }

        private void frmDisparaMoscas_Load(object sender, EventArgs e)
        {
            this.FormTransparente();
            _Moscas = new ArrayList();
            this.MoscasNaTela();
            _SysTray.Text = "Bzzzzzzz " + _Quant.ToString();
        }

        private void MoscasNaTela()
        {
            this.VaiMosca();
            tmrDisparaMoscas.Enabled = true;
        }

        private void tmrDisparaMoscas_Tick(object sender, EventArgs e)
        {
            this.VaiMosca();
        }

        private void VaiMosca()
        {
            if (_Moscas.Count >= _Quant)
            {
                tmrDisparaMoscas.Enabled = false;
                return;
            }
            frmMosca _Mosca = new frmMosca();
            _Mosca.Comidas = _Comidas;
            _Mosca.ComSom = _ComSom;
            _Mosca.SeguirOMouse = _SeguirOMouse;
            _Mosca.Show();
            _Moscas.Add(_Mosca);
            Application.DoEvents();
        }

        private void tmrControleItens_Tick(object sender, EventArgs e)
        {
            if (_Comidas.Count > 0)
            {
                bool _Removeu = false;
                do
                {
                    _Removeu = false;
                    foreach (frmItem _frmItem in _Comidas)
                    {
                        if (!_frmItem.Visible)
                        {
                            _Comidas.Remove(_frmItem);
                            foreach (frmMosca _Mosca in _Moscas)
                            {
                                _Mosca.Comidas = _Comidas;
                            }
                            _Removeu = true;
                            break;
                        }
                    }
                } while (_Removeu);
                
            }
            else
            {
                tmrControleItens.Enabled = false;
            }
        }

        private void tmrComandosAleatorios_Tick(object sender, EventArgs e)
        {
            this._ComandoAleatorio();
        }

        private void tmrRoubarMouse_Tick(object sender, EventArgs e)
        {
            tmrRoubarMouse.Enabled = false;
            if (_Moscas.Count > 0)
            {
                foreach (frmMosca _Mosca in _Moscas)
                {
                    _Mosca.RoubarMouse();
                }
            }
        }
    }
}
