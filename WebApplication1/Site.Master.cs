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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Session.Add("Error", "Debes iniciar sesión");
                    Response.Redirect("ErrorIngreso.aspx", false);
                }
                Usuario userLog = (Usuario)Session["Usuario"];

                if (!IsPostBack)
                {
                    EmpleadoDB empleadoDB = new EmpleadoDB();
                    Empleado empleado = new Empleado();
                    if (userLog != null)
                    {
                        empleado = empleadoDB.empleadoLogueado(userLog.IDUsuario);
                        
                    }

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("ErrorIngreso.aspx", false);
            }
        }


    }
}