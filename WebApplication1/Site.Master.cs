using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            /*usuario = (Usuario)Session["Usuario"];
            if (usuario == null)
            {
                Response.Redirect("Ingreso.aspx");
            }*/
       
                
            
        }
    }
}