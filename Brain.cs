using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace bavito_server
{
    //class brain
    //{
    //    Delegate message;
    //    public brain(Delegate msgdel) 
    //    {
    //        message = msgdel;
    //        message.DynamicInvoke("I am created!");
    //    }
    //    public void think() 
    //    {
    //        message.DynamicInvoke("I am thinking!");
    //    }
    //}
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
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
        public string POSTInputStreamReader(HttpListenerRequest request)
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
        public void Categories_loader()
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
                Answer(JsonConvert.SerializeObject(ds.Tables[0]),response);
            }
        }
        public void Signs_loader() 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM dbo.Sign";
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
        public void Image_load()
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

                    if (request.HttpMethod == "POST")
                    {
                        s = POSTInputStreamReader(request);
                        message.DynamicInvoke("Данные запроса POST: " + s);
                        responseString = "Ответ от сервера! Был написан POST параметр: " + s;
                    }
                    else
                    {
                        s = HttpUtility.ParseQueryString(request.Url.Query).Get("func");
                        message.DynamicInvoke("Значение параметра func: " + s);
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
