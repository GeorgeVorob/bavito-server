using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Server
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
        public brain(Delegate msgdel)
        {
            message = msgdel;
            message.DynamicInvoke("I am created!");
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
            message.DynamicInvoke("Client data content length {0}", request.ContentLength64);

            message.DynamicInvoke("Start of client data:");
            // Convert the data to a string and display it on the console.
            s = reader.ReadToEnd();
            return s;
        }
        //  static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\iscsi\profiles\vorobev_g\Desktop\bavito-server-master\Database.mdf;Integrated Security=True";
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\GithubDesktop\bavito-server\Database.mdf;Integrated Security=True";
        static string sqlExpression;
        public async Task Listen()
        {

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();
            message.DynamicInvoke("Ожидание подключений...");

            while (true)
            {
                string s = "";
                string responseString = "";
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                response.Headers.Add("Access-Control-Allow-Origin", "*");

                if (request.HttpMethod == "POST")
                {
                    s = POSTInputStreamReader(request);
                    message.DynamicInvoke("Данные запроса POST: " + s);
                    responseString = "Ответ от сервера! Был написан POST параметр: " + s;
                }
                else
                {
                    s = HttpUtility.ParseQueryString(request.Url.Query).Get("say");
                    message.DynamicInvoke("Данные запроса GET: " + s);
                    responseString = @" <!DOCTYPE html>
<html>
<head>
<title> Title of the document </title>
<meta charset=" + "\"UTF-8\"" + @">
     </head>

   <body>
<img width=" + "\"500\"" + @" src =" + "https://cdn.discordapp.com/attachments/492708867965321216/677874444395347988/-qLqvyZeWqQ.png" + @">
   " + "Answer from server! Your GET parameter: " + s + @"</body>

</html> ";
                }
                message.DynamicInvoke("Отвечено");
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
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
