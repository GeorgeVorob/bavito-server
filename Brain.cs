using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace bavito_server
{
    
    class brain
    {
        Delegate message;
        string imgpath = @"..\..\Materials\Images\";
        HttpListenerRequest request;
        HttpListenerResponse response;
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\GithubDesktop\bavito_server\BavitoDB\Database1.mdf;Integrated Security=True;Connect Timeout=30";
        static string sqlExpression;
        public brain(Delegate msgdel)
        {
            message = msgdel;
            message.DynamicInvoke("Server created");
        }
        private void Answer(string responseString, HttpListenerResponse response)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public string POSTInputStreamReader(HttpListenerRequest request)
        {
            try
            {
                string s = "";
                System.IO.Stream body = request.InputStream;
                System.Text.Encoding encoding = request.ContentEncoding;
                System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                if (request.ContentType != null)
                {
                    s = "Client data content type " + request.ContentType;
                    message.DynamicInvoke(s);
                }
                s = "Client data content length " + request.ContentLength64.ToString();
                message.DynamicInvoke(s);

                message.DynamicInvoke("Start of client data:");
                // Convert the data to a string and display it on the console.
                s = reader.ReadToEnd();
                return s;
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
                return "";
            }
        }
        public void Categories_loader()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT CategoryName FROM dbo.Category";
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    // Отображаем данные в сетке    
                    Answer(JsonConvert.SerializeObject(ds.Tables[0]), response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Signs_loader() 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql;
                    if (HttpUtility.ParseQueryString(request.Url.Query).Get("isexpanded") == "true")
                    {
                        string input = POSTInputStreamReader(request);
                        SearchInput searchinput = new SearchInput();
                        searchinput = JsonConvert.DeserializeObject<SearchInput>(input);
                        sql = "SELECT * FROM dbo.Sign WHERE Name LIKE(N'%" + searchinput.GetParam("Name") + "%') AND Category LIKE N'" + (searchinput.GetParam("Category") ?? "%") + "' AND Date BETWEEN '" + (searchinput.Datefrom ?? "2019-01-01") + "' AND '" + (searchinput.Dateto ?? DateTime.Now.ToString("yyyy-MM-dd")) + "' AND Price BETWEEN " + (searchinput.Pricefrom ?? "0") + " AND " + (searchinput.Priceto ?? "999999999999") + "";
                    }
                    else
                    {
                        string name = HttpUtility.ParseQueryString(request.Url.Query).Get("name");
                        sql = "SELECT * FROM dbo.Sign WHERE Name LIKE(N'%" + name + "%')";
                    }
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    // Отображаем данные в сетке    
                    Answer(JsonConvert.SerializeObject(ds.Tables[0]), response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Sign_load()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM dbo.Sign WHERE Id=" + HttpUtility.ParseQueryString(request.Url.Query).Get("signid").ToString();
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    // Отображаем данные в сетке    
                    Answer(JsonConvert.SerializeObject(ds.Tables[0]), response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Image_load()
        {
            try
            {
                response.ContentType = "image/jpg";
                string imgid = HttpUtility.ParseQueryString(request.Url.Query).Get("imgid");
                string img = imgpath + imgid + ".jpg";
                Byte[] bytes = File.ReadAllBytes(img);
                response.ContentLength64 = bytes.Length;
                Stream output = response.OutputStream;
                output.Write(bytes, 0, bytes.Length);
                output.Close();
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Login_check()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT count(*) as counter FROM dbo.[User] " +
                    "WHERE Login='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                    "' AND Password='" + HttpUtility.ParseQueryString(request.Url.Query).Get("password") + "'";
                    message.DynamicInvoke("Логин:" + HttpUtility.ParseQueryString(request.Url.Query).Get("login"));
                    message.DynamicInvoke("Пароль:" + HttpUtility.ParseQueryString(request.Url.Query).Get("password"));
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows[0].Field<int>("counter") >= 1)
                        Answer("true", response);
                    else
                        Answer("false", response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Get_User_Data()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Login, FIO, 'E-mail', Adress, Phone, Rating, RegDate FROM dbo.[User] " +
                    "WHERE Login='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                    "'";
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.StatusCode = 200;
                        Answer(JsonConvert.SerializeObject(ds.Tables[0]), response);
                    }
                    else
                    {
                        response.StatusCode = 400;
                        Answer("Неверные логин или пароль", response);
                    }
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Registration()
        {
            try
            {
                string input = POSTInputStreamReader(request);
                Account account = JsonConvert.DeserializeObject<Account>(input);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT count(*) as counter from dbo.[User] WHERE Login='" + account.Login + "'";
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows[0].Field<int>("counter") >= 1)
                    {
                        response.StatusCode = 400; //bad
                        Answer("Такой логин уже существует", response);
                    }
                    else
                    {
                        response.StatusCode = 200; //good
                        Answer("Регистрация успешна", response);
                        sql = "insert into dbo.[User] values ('" + account.Login + "','" + account.Password + "','" + account.FIO + "','" + account.Email + "','" + account.Adress + "','" + account.Phone + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Sign_Update()
        {
            try
            {
                string input = POSTInputStreamReader(request);
                SignUpdate signupdate = JsonConvert.DeserializeObject<SignUpdate>(input);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT count(*) as counter FROM dbo.[User] " +
                    "WHERE Login='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                    "' AND Password='" + HttpUtility.ParseQueryString(request.Url.Query).Get("password") + "'";
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows[0].Field<int>("counter") < 1)
                    {
                        response.StatusCode = 400;
                        Answer("Неверный логин или пароль", response);
                        return;
                    }
                    string updatingid = HttpUtility.ParseQueryString(request.Url.Query).Get("signid");
                    sql = "EXEC UpdateSign N'" + signupdate.GetParam("Name") + "', N'" + signupdate.GetParam("Category") + "', N'" + signupdate.GetParam("Adress") + "', " + signupdate.GetParam("Price") + ", " + updatingid.ToString() + "";
                    SqlCommand command = new SqlCommand(sql, connection);
                    string test = signupdate.GetParam("Category");
                    command.ExecuteNonQuery();
                    response.StatusCode = 200; //good
                    Answer("Данные обновлены", response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void SignDelete()
        {
            try
            {
                string input = POSTInputStreamReader(request);
                SignUpdate signupdate = JsonConvert.DeserializeObject<SignUpdate>(input);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT count(*) as counter FROM dbo.[User] " +
                    "WHERE Login='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                    "' AND Password='" + HttpUtility.ParseQueryString(request.Url.Query).Get("password") + "'";
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows[0].Field<int>("counter") < 1)
                    {
                        response.StatusCode = 400;
                        Answer("Неверный логин или пароль", response);
                        return;
                    }
                    sql = "SELECT count(*) from dbo.Sign WHERE Author='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                        "' AND Id=" + HttpUtility.ParseQueryString(request.Url.Query).Get("id");
                    SqlCommand command = new SqlCommand(sql, connection);
                    if (command.ExecuteScalar().ToString() == "1")
                    {
                        sql = "DELETE FROM dbo.[Sign] " + "WHERE id=" + HttpUtility.ParseQueryString(request.Url.Query).Get("id");
                        command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        response.StatusCode = 400;
                        Answer("Это объявление не ваше", response);
                        return;
                    }
                    response.StatusCode = 200; //good
                    Answer("Запись удалена", response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public void Add_Sign()
        {
            try
            {
                string input = POSTInputStreamReader(request);
                SignUpdate NewSign = JsonConvert.DeserializeObject<SignUpdate>(input);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "SELECT count(*) as counter FROM dbo.[User] " +
                    "WHERE Login='" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") +
                    "' AND Password='" + HttpUtility.ParseQueryString(request.Url.Query).Get("password") + "'";
                    connection.Open();
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект Dataset
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows[0].Field<int>("counter") < 1)
                    {
                        response.StatusCode = 400;
                        Answer("Неверный логин или пароль", response);
                        return;
                    }
                    sql = "INSERT INTO Sign VALUES(N'" + NewSign.GetParam("Name") + "', N'" + NewSign.GetParam("Category") +
                        "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', N'" + NewSign.GetParam("Adress") + "', 0, " + NewSign.GetParam("Price") +
                        ", '" + HttpUtility.ParseQueryString(request.Url.Query).Get("login") + "','Active'); select scope_identity()";
                    SqlCommand command = new SqlCommand(sql, connection);
                    string test = NewSign.GetParam("Category");
                    var addingid = command.ExecuteScalar();
                    if (NewSign.Base64image != null)
                    {
                        sql = "select scope_identity()";
                        string pureimage = NewSign.Base64image.Substring(NewSign.Base64image.IndexOf(',') + 1);
                        File.WriteAllBytes(imgpath + addingid.ToString() + ".jpg", Convert.FromBase64String(pureimage));
                    }
                    response.StatusCode = 200; //good
                    Answer("Объявление добавлено", response);
                }
            }
            catch (Exception e)
            {
                message.DynamicInvoke("Ошибка:" + e.Message);
            }
        }
        public async Task Listen()
        {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:8888/");
                listener.Start();
                message.DynamicInvoke("Ожидание подключений...");

                while (true)
                {
                    try
                    {
                        string s = "";
                        string responseString = "";
                        HttpListenerContext context = await listener.GetContextAsync();
                        request = context.Request;
                        response = context.Response;
                        response.Headers.Add("Access-Control-Allow-Origin", "*");
                            s = HttpUtility.ParseQueryString(request.Url.Query).Get("func");
                            message.DynamicInvoke("Значение параметра func: " + s);
                    if (request.HttpMethod == "OPTIONS")
                        Answer("yes",response);
                            var func = typeof(brain).GetMethod(s);
                            if (func == null)
                            {
                                message.DynamicInvoke("Запрос несуществующего метода");
                                responseString = "https://cdn.discordapp.com/attachments/492708867965321216/677874444395347988/-qLqvyZeWqQ.jpg";
                            }
                            else
                            {
                                //responseString = (string)func.Invoke(this, null);
                                func.Invoke(this, null);
                            }
                        //Answer(responseString, response);
                        message.DynamicInvoke("Отвечено");
                    }
                    catch (Exception e)
                    {
                        message.DynamicInvoke("Ошибка:" + e.Message);
                    }
                }
        }
        public async void Main()
        {

            //using (SqlConnection conn = new SqlConnection(connString))
            //{
            //    string sqlcomm = "insert into [dbo].[Users] values(12,'dada','da','dadada')";   //Работает
            //    conn.Open(); // открыть соединение 
            //    SqlCommand command = new SqlCommand(sqlcomm, conn);
            //    command.ExecuteNonQuery();
            //}

            await Listen();
        }
    }
}
