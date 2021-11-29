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
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoEmpleadoDB db = new TipoEmpleadoDB();
            try
            {
                if (!IsPostBack)
                {
                    List<TipoEmpleado> empleado = db.listar();
                    ddlistTipoEmpleado.DataSource = empleado;
                    ddlistTipoEmpleado.DataTextField = "Nombre";
                    ddlistTipoEmpleado.DataValueField = "ID";
                    ddlistTipoEmpleado.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {

            Empleado NuevoEmpleado = new Empleado();
            EmpleadoDB cargar = new EmpleadoDB();
            string agregado = "Empleado";
            string error = "empleado";

            try
            {

                NuevoEmpleado.DNI = txtDNI.Text;
                NuevoEmpleado.Apellido = txtApellido.Text;
                NuevoEmpleado.Nombre = txtNombre.Text;
                NuevoEmpleado.TipoEmp = new TipoEmpleado();
                NuevoEmpleado.TipoEmp.ID = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                NuevoEmpleado.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                NuevoEmpleado.Telefono = txtTelefono.Text;
                NuevoEmpleado.Email = txtEmail.Text;
                NuevoEmpleado.Dirección = txtDireccion.Text;
                NuevoEmpleado.Estado = true;
                cargar.agregar(NuevoEmpleado);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }
    }
}
