using Nett;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ls_gui_control
{
    public class Config
    {
        public string ls_server { get; set; }
        public string ls_token { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // прочитаем конфиг
            var raw = FileHelper.LoadFile("Config.toml");
            var toml = string.Join("\n", raw.ToArray());
            var sc = Toml.ReadString<Config>(toml);

            Application.Run(new ConfigNotFound());
        }
    }
}
