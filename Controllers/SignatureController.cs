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
            string fpath=Path.Combine(dir.FullName + "/PicDB", string.Format("Img_{0}.png", Guid.NewGuid()));
            using (var fs = System.IO.File.Create(fpath))
            {
                
                fs.Write(photo, 0, photo.Length);

            }

            return Ok();
        }
    }
}
