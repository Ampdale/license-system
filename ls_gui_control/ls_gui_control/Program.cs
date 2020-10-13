using System;
using System.Windows.Forms;

namespace ls_gui_control
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // прочитаем конфиг
            var raw = FileHelper.LoadFile("Config.toml");

            // проверяем найден ли конфигурационный файл
            if (Utils.IsAny(raw) == false)
            {
                // если не нашли то вызываем окошко добавления конф. файла
                Application.Run(new ConfigNotFound());
            }
            else
            {
                // нашли конфиг
                Application.Run(new Control());
            }

        }
    }
}
