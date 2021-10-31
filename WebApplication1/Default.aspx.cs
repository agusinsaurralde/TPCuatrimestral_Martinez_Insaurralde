using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBClinica;
using Dominio;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadDB ClinicaDB = new EspecialidadDB();
            Grilla.DataSource = ClinicaDB.lista();
            Grilla.DataBind();
        }
    }
}