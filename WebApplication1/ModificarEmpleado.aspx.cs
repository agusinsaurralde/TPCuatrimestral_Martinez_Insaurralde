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
    public partial class ModificarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TipoEmpleadoDB db = new TipoEmpleadoDB();
            try
            {
                if (!IsPostBack)
                {
                    List<TipoEmpleado> tipo = db.listar();
                    ddlistTipoEmpleado.DataSource = tipo;
                    ddlistTipoEmpleado.DataTextField = "Nombre";
                    ddlistTipoEmpleado.DataValueField = "ID";
                    ddlistTipoEmpleado.DataBind();

                    Empleado empleado = new Empleado();
                    empleado = (Empleado)Session["modificar"];
                    txtDNI.Text = empleado.DNI;
                    txtApellido.Text = empleado.Apellido;
                    txtNombre.Text = empleado.Nombre;
                    ddlistTipoEmpleado.SelectedValue = empleado.TipoEmp.ID.ToString();
                    txtFechaNac.Text = empleado.FechaNacimiento.ToString();
                    txtTelefono.Text = empleado.Telefono;
                    txtEmail.Text = empleado.Email;
                    txtDireccion.Text = empleado.Dirección;
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
            Empleado modEmpleado = new Empleado();
            EmpleadoDB cargar = new EmpleadoDB();
            string modificado = "Empleado";
            string error = "empleado";

            try
            {
                modEmpleado.ID = ((Empleado)Session["modificar"]).ID;
                modEmpleado.DNI = txtDNI.Text;
                modEmpleado.Apellido = txtApellido.Text;
                modEmpleado.Nombre = txtNombre.Text;
                modEmpleado.TipoEmp = new TipoEmpleado();
                modEmpleado.TipoEmp.ID = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                modEmpleado.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modEmpleado.Telefono = txtTelefono.Text;
                modEmpleado.Email = txtEmail.Text;
                modEmpleado.Dirección = txtDireccion.Text;
                
                cargar.modificar(modEmpleado);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }
    }
}
