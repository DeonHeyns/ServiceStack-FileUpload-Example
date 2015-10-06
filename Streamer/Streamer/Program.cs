using System;
using System.Diagnostics;
using ServiceStack.Text;

namespace Streamer
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://*:8000/");
            "ServiceStack SelfHost listening at http://localhost:8000 ".Print();
            Process.Start($"http://{Environment.MachineName}:8000");

            Console.ReadLine();
        }
    }
}