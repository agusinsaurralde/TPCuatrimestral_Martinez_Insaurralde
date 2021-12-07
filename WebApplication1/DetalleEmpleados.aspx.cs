using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using DBClinica;

namespace WebApplication1 
{ 

    public partial class DetalleEmpleados : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["DetalleEmpleado"];
        }
    }
}