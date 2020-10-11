using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nett;

namespace ls_gui_control
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
        }
        public class Config
        {
            public string ls_server { get; set; }
            public string ls_token { get; set; }
        }
        private void Control_Load(object sender, EventArgs e)
        {
            // прочитаем конфиг
            var raw = FileHelper.LoadFile("Config.toml");
            var toml = string.Join("\n", raw.ToArray());
            var sc = Toml.ReadString<Config>(toml);

            hostname_.Text = sc.ls_server;
            mastertoken_.Text = sc.ls_token;
        }
    }
}
