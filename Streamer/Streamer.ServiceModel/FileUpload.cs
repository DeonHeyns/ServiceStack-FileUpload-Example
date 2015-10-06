using System.IO;
using ServiceStack;
using ServiceStack.Web;

namespace Streamer.ServiceModel
{
    [Route("/fileupload")]
    public class FileUpload : IRequiresRequestStream
    {
        public Stream RequestStream { get; set; }
    }
}