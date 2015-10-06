using System;
using System.IO;
using System.Linq;
using System.Net;
using ServiceStack;
using Streamer.ServiceModel;

namespace Streamer.ServiceInterface
{
    public class StreamingService : Service
    {
        public object Post(FileUpload request)
        {
            var resultFile = @"{0}.dat".Fmt(RandomString(10));
            using (var file = File.Create(resultFile))
            {
                request.RequestStream.WriteTo(file);
            }
            Response.StatusCode = 200;
            return HttpStatusCode.OK;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}