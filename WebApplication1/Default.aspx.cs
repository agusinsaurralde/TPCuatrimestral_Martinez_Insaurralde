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
                        //lblNombreUsuario.Text = empleado.NombreCompleto;
                    }

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("ErrorIngreso.aspx", false);
            }



            //EspecialidadDB ClinicaDB = new EspecialidadDB();
            //Grilla.DataSource = ClinicaDB.lista();
            //Grilla.DataBind();
        }

        protected void btnLogOut_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear(); // limpia la sesion actual y en las lineas siguientes le asignamos la de error.
            Session.Add("Error", "Debes iniciar sesión");
            Response.Redirect("ErrorIngreso.aspx", false);
        }


    }
}