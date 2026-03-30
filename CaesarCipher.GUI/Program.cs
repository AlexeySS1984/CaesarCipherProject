using System;
using System.Windows.Forms;

namespace CaesarCipher.GUI
{
    /// <summary>
    /// Точка входа в графическое приложение «Шифр Цезаря».
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
