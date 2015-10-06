using System;
using System.IO;
using System.Net;

namespace Runner
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to a large file and hit enter to upload.");
            var filePath = Console.ReadLine();

            var uri = new Uri($"http://{Environment.MachineName}:8000/fileupload");
            
            
            var client = (HttpWebRequest)WebRequest.Create(uri);
            client.Method = WebRequestMethods.Http.Post;
            client.AllowWriteStreamBuffering = false;
            client.SendChunked = true;
            client.Accept = "application/json";
            client.ContentType = "multipart/form-data;";
            client.Timeout = int.MaxValue;
            using (var fileStream = File.OpenRead(filePath))
            {
                fileStream.CopyTo(client.GetRequestStream());
            }

            var responseStream = client.GetResponse().GetResponseStream();
            var response = new StreamReader(responseStream).ReadToEnd();
            
            Console.WriteLine(response);
            Console.Read();
        }
    }
}
