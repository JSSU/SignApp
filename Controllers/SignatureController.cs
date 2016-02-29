using SignApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Services;

namespace SignApp.Controllers
{
    public class SignatureController : ApiController
    {
        string fpath;
        //api/signature
        public IHttpActionResult Post([FromBody] Signature data)
        {
            var photo = Convert.FromBase64String(data.Value);
            int id = data.Id;

            var dir = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
            fpath=Path.Combine(dir.FullName + "/PicDB", string.Format("Img_{0}.png", Guid.NewGuid()));
            using (var fs = System.IO.File.Create(fpath))
            {
                
                fs.Write(photo, 0, photo.Length);

            }
            

            return Ok(new { p=photo,i=id});
        }

    }
}
