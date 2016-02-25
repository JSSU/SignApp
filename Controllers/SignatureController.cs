using SignApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace SignApp.Controllers
{
    public class SignatureController : ApiController
    {
        public IHttpActionResult Post([FromBody] Signature data)
        {
            var photo = Convert.FromBase64String(data.Value);

            var dir = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);

            using (var fs = System.IO.File.Create(Path.Combine(dir.FullName, string.Format("Img_{0}.png", Guid.NewGuid()))))
            {
                fs.Write(photo, 0, photo.Length);
            }

            return Ok();
        }
    }
}
