using SignApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignApp
{
    public partial class loadimage : System.Web.UI.Page
    {
        DPW_OBC_PrequalEntities dbcontent = new DPW_OBC_PrequalEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsub_Click(object sender, EventArgs e)
        {
            int inp = Convert.ToInt32(inpsearch.Value);
            var rs = (from it in dbcontent.saveimgs
                      where it.CaseID == inp
                      select it).FirstOrDefault();
            if (rs != null)
            {
                string imgpath = rs.imgpath;
                inpimg.ImageUrl = "PicDB/"+imgpath;
            } 
           
        }
    }
}