using Nett;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ls_gui_control
{
    public partial class ConfigNotFound : Form
    {
        public ConfigNotFound()
        {
            InitializeComponent();
        }

        private void add_config_Click(object sender, EventArgs e)
        {
            var config = Toml.Create();

            config.Add("ls_server", hostname.Text);
            config.Add("ls_token", masterToken.Text);

            var raw = config.ToString();

            FileHelper.SaveText("Config.toml", raw, false);

            MessageBox.Show(  "Добавили.", "Уведомление");
        }
    }
}
