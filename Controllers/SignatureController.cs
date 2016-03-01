using SignApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Services;

namespace SignApp.Controllers
{
    public class SignatureController : ApiController
    {
        DPW_OBC_PrequalEntities dbcontact = new DPW_OBC_PrequalEntities();
        //api/signature
        private void updateDB(int id, string Path) {
            saveimg update = new saveimg { CaseID = id, imgpath = Path };
            dbcontact.saveimgs.Add(update);
            //dbcontact.saveimgs.InsertOnSubmit(update);
            dbcontact.SaveChanges();
        }
        public IHttpActionResult Post([FromBody] Signature data)
        {
            var photo = Convert.FromBase64String(data.Value);
            int id = data.Id;

            var dir = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
            string fpath=Path.Combine(dir.FullName + "PicDB", string.Format("Img_{0}.png", Guid.NewGuid()));
            Match m = Regex.Match(fpath, "PicDB");
            string dbpath =fpath.Substring(m.Index+5);
            using (var fs = System.IO.File.Create(fpath))
            {
                
                fs.Write(photo, 0, photo.Length);

            }
           
            //updateDB(id,fpath);
            try
            {
                saveimg u = new saveimg();
                var flag = (from it in dbcontact.saveimgs
                           where it.PK==id
                           select it).SingleOrDefault();
                if (flag == null)
                {
                    u.CaseID = id;
                    u.imgpath = dbpath;
                    dbcontact.saveimgs.Add(u); 
                    //dbcontact.saveimgs.AddObject(u); //dbcontact.saveimgs.InsertOnSubmit(update);
                }
                else {
                    flag.imgpath = dbpath;
                    dbcontact.SaveChanges();
                }
                dbcontact.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            

            return Ok(new { p=photo,i=id});
        }

    }
}
