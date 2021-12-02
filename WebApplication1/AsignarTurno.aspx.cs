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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadDB espDB = new EspecialidadDB();
            MedicoDB medicoDB = new MedicoDB();
            ConexionDB conexion = new ConexionDB();

            if (!IsPostBack)
            {
                List<Especialidad> esp = espDB.lista();
                ddlistEspecialidad.DataSource = esp;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();
                ddlistEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));


                List<Medico> medico = medicoDB.listarMedico();
                Session["listaMedico"] = medico;
               
                ddlistMedico.DataSource = medico;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar", "0"));


            }

        }
        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            ddlistMedico.DataSource = ((List<Medico>)Session["listaMedico"]).FindAll(x => x.Especialidad.Id == ID);
            ddlistMedico.DataBind();
            ddlistMedico.Enabled = true;
        }

        protected void Click_Buscar(object sender, EventArgs e)
        { 
            
        }

    }
}