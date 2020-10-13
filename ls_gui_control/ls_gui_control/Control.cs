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
        public class Products
        {
            public string id { get; set; }
            public string name { get; set; }
            public string active { get; set; }
            public string file_name { get; set; }
        }
        public class getSubscriptions
        {
            public string id { get; set; }
            public string user_id { get; set; }
            public string product_id { get; set; }
            public string date_begin { get; set; }
            public string date_end { get; set; }
        }
        private void GetUsers()
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
        private void GetProducts()
        {
            // Отправим запрос на получение продуктов
            HttpContent content = new HttpContent();
            content.ContentType = "application/x-www-form-urlencoded"; //is default
            content["token"] = mastertoken_.Text;
            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/getProducts", content);

            var response = JObject.Parse(res.Content).SelectToken("response");
            Products users;
            foreach (var x in response)
            {
                // Преобразуем данные в Json 
                users = JsonConvert.DeserializeObject<Products>(x.ToString());
                // Добавим данные на Grid
                products_.Rows.Add(users.id, users.name, users.active, users.file_name);
            }
        }
        private void Control_Load(object sender, EventArgs e)
        {
            // getUsers
            GetProducts();
            // getUsers
            GetUsers(); 
        }

        private void getsubscriptions_check_Click(object sender, EventArgs e)
        {
            // Отправим запрос на получение подписок
            HttpContent content = new HttpContent();
            content.ContentType = "application/x-www-form-urlencoded"; //is default
            content["token"] = mastertoken_.Text;
            content["username"] = getsubscriptions_username.Text;
            content["product"] = getsubscriptions_product.Text;
            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/getSubscriptions", content);

            var response = JObject.Parse(res.Content).SelectToken("response");
            getSubscriptions users;
            foreach (var x in response)
            {
                // Преобразуем данные в Json 
                users = JsonConvert.DeserializeObject<getSubscriptions>(x.ToString());
                // Добавим данные на Grid
                subscriptions_.Rows.Add(users.id, users.user_id, users.product_id, users.date_begin, users.date_end);
            }
        }

        private void ap_add_Click(object sender, EventArgs e)
        {
            // Отправим запрос на добавление продукта
            HttpContent content = new HttpContent("{\"name\":\""+ap_name.Text+"\",\"token\":\""+ mastertoken_.Text + "\",\"active\": "+ap_active.Text+",\"file_name\":\""+ap_file_name_.Text+"\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/addProduct", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void dp__Click(object sender, EventArgs e)
        {
            // Отправим запрос на удаление продукта
            HttpContent content = new HttpContent("{\"name\":\"" + dp.Text + "\",\"token\":\"" + mastertoken_.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/delProduct", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отправим запрос на изменение продукта
            HttpContent content = new HttpContent("{\"name\":\""+modifyProduct_name.Text+"\",\"token\":\""+ mastertoken_.Text + "\",\"active\": "+modifyProduct_active.Text + ",\"file\":{\"name\":\""+modifyProduct_file_name.Text + "\",\"contents\":\""+modifyProduct_file_contents.Text + "\"}}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/modifyProduct", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void au_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на добавление пользователя
            HttpContent content = new HttpContent("{\"name\":\"" + au_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/addUser", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void du_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на удаление пользователя
            HttpContent content = new HttpContent("{\"name\":\"" + delUser.Text + "\",\"token\":\"" + mastertoken_.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/delUser", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void bu_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на блокировку пользователя
            HttpContent content = new HttpContent("{\"name\":\"" + banUser.Text + "\",\"token\":\"" + mastertoken_.Text + "\",\"date\":0}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/banUser", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void rh_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на обнуление HWID пользователя
            HttpContent content = new HttpContent("{\"name\":\"" + resetHwid.Text + "\",\"token\":\"" + mastertoken_.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/resetHwid", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void saa_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на установление уровня доступа пользователя к API
            HttpContent content = new HttpContent("{\"name\":\"" + saa_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\",\"level\":" + saa_level.Text + "}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/setApiAccess", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void as_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на добавление подписки
            string json = "{\"username\":\"" + as_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\",\"product\":\"" + as_product.Text + "\",\"date\":{\"begin\":" + as_db.Text + ",\"end\":" + as_de.Text + "}}";
            HttpContent content = new HttpContent(json);
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/addSubscription", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void ms_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на изменение подписки
            string json = "{\"username\":\"" + ms_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\",\"product\":\"" + ms_product.Text + "\",\"date\":{\"begin\":" + ms_db.Text + ",\"end\":" + ms_de.Text + "}}";
            HttpContent content = new HttpContent(json);
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/modifySubscription", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void ds_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на удаление подписки
            HttpContent content = new HttpContent("{\"username\":\"" + ds_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\",\"product\":\"" + ds_product.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/delSubscription", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }

        private void dss_b_Click(object sender, EventArgs e)
        {
            // Отправим запрос на удаление всех подписок
            HttpContent content = new HttpContent("{\"username\":\"" + dss_name.Text + "\",\"token\":\"" + mastertoken_.Text + "\"}");
            content.ContentType = "application/json";

            var hr = new HttpRequest() { Ssl = false };

            var res = hr.Post(hostname_.Text + "/api/delSubscriptions", content);

            var response = JObject.Parse(res.Content).SelectToken("msg");

            MessageBox.Show(response.ToString(), "Message");
        }
    }
}
