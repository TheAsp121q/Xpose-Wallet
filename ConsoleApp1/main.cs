using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
 
class Program
{
    class Loading
    {
        public string content {get; set;}
    }
    class Wallet 
    {
        public string name {get; set;}  
    }
    static void Main(string[] args)
    {
        HttpListener listener = new HttpListener();

        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();

        Console.WriteLine("Listening...");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerResponse response = context.Response;

            bool loaded = false;
            if (context.Request.Url.AbsolutePath == "/loading")
            {
                StreamReader reader = new StreamReader(context.Request.InputStream);
                string json = reader.ReadToEnd();

                Loading load = JsonSerializer.Deserialize<Loading>(json);

                Console.WriteLine(load.content);
                loaded = true;

                if (loaded == true)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Error");
                    continue;
                }

                response.Close();
                continue;
            }

            string path = context.Request.Url.AbsolutePath;

            string file;

            if (path == "/")
            {
                file = "index.html";
            }
            else
            {
                file = path.TrimStart('/');
            }

            if (!File.Exists(file))
            {
                response.StatusCode = 404;
                response.Close();
                continue;
            }

            byte[] buffer = File.ReadAllBytes(file);

            if (file.EndsWith(".html"))
                response.ContentType = "text/html";
            else if (file.EndsWith(".css"))
                response.ContentType = "text/css";
            else if (file.EndsWith(".js"))
                response.ContentType = "text/javascript";
            else if (file.EndsWith(".png"))
                response.ContentType = "image/png";
            else if (file.EndsWith(".jpg") || file.EndsWith(".jpeg"))
                response.ContentType = "image/jpeg";

            response.ContentLength64 = buffer.Length;
            
            if (context.Request.HttpMethod == "POST")
            {
                StreamReader reader = new StreamReader(context.Request.InputStream);
                string fetched_wallet = reader.ReadToEnd();

                Wallet wallet = JsonSerializer.Deserialize<Wallet>(fetched_wallet);
                Console.WriteLine(wallet.name);
            }

            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}