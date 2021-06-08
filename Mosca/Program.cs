using System;
using System.Windows.Forms;

namespace Mosca
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args.Length > 0)
            {
                string _LihaDeComando = args[0].Trim();
                _LihaDeComando = _LihaDeComando.Trim().ToUpper();
                int _Quant = 0;
                if (int.TryParse(_LihaDeComando, out _Quant))
                {
                    if (args.Length > 1)
                    {
                        _LihaDeComando = "";
                        for (int i = 1; i < args.Length; i++)
                        {
                            _LihaDeComando = _LihaDeComando + " " + args[i].Trim().ToUpper();
                        }
                        Application.Run(new frmDisparaMoscas(_Quant, _LihaDeComando));
                    }
                    else
                    {
                        Application.Run(new frmDisparaMoscas(_Quant));
                    }
                }
                else
                {
                    Application.Run(new frmDisparaMoscas(-1, _LihaDeComando));
                }
            }
            else
            {
                Application.Run(new frmDisparaMoscas());
            }
        }
    }
}
