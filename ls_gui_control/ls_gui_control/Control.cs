using System;
using System.Linq;
using System.Windows.Forms;
using MVNet;
using Nett;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ls_gui_control
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent(); 
            
            // прочитаем конфиг
            var raw = FileHelper.LoadFile("Config.toml");
            // сделаем строку
            var toml = string.Join("\n", raw.ToArray());
            // обрабатываем
            var sc = Toml.ReadString<Config>(toml);

            hostname_.Text = sc.ls_server;
            mastertoken_.Text = sc.ls_token;
        }
        public class Config
        {
            public string ls_server { get; set; }
            public string ls_token { get; set; }
        }
        public class Users
        {
            public string id { get; set; }
            public string username { get; set; }
            public string hwid_hash { get; set; }
            public string date_added { get; set; }
            public string ban_date { get; set; }
            public string api_access { get; set; }
            public string api_token { get; set; }
        }
        private void GetUsers ()
        {

            // Отправим запрос на получение пользователей
            HttpContent content = new HttpContent();
            content.ContentType = "application/x-www-form-urlencoded"; //is default
            content["token"] = mastertoken_.Text;
            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/getUsers", content);

            var response = JObject.Parse(res.Content).SelectToken("response");
            Users users;
            foreach (var x in response)
            {
                // Преобразуем данные в Json 
                users = JsonConvert.DeserializeObject<Users>(x.ToString());
                // Добавим данные на Grid
                getUsersGrid.Rows.Add(users.id, users.username, users.hwid_hash, users.date_added, users.ban_date, users.api_access, users.api_token);
            }

        }
        private void Control_Load(object sender, EventArgs e)
        {
            // getUsers
            GetUsers(); 
        }
    }
}
