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
    public partial class EspecialidadesMedico : System.Web.UI.Page
    {
        //para armar tabla
        public List<MedicoEspecialidades> listaEsp { get; set; }
        public List<DiasHabilesMedico> listaDias { get; set; }
        public DiasHabilesMedico objDias { get; set; }
        public DiasHabilesMedico datosModal { get; set; }

        //para listar usuario
        public Usuario usuario { get; set; }

   


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaEsp = (List<Dominio.MedicoEspecialidades>)Session["EspMedico"];
                listaDias = (List<Dominio.DiasHabilesMedico>)Session["DiasHabiles"];

                int idMedico = listaEsp[0].ID;

                UsuarioDB usuarioDB = new UsuarioDB();
                List<Usuario> listaUsuarios = usuarioDB.listar();
                usuario = listaUsuarios.Find(x => x.IDUsuario == idMedico);
            }


            if (Request.QueryString["id"] != null) 
            {
                MedicoDB medicoDB = new MedicoDB();
                int id = Convert.ToInt32(Request.QueryString["id"]);

                if(Request.QueryString["accion"] == "eliminar")
                {
                    
                }
               else if (Request.QueryString["accion"] == "editar")
                {
                    DiasHabilesMedico diaSeleccionado = listaDias.Find(x => x.ID == id);
                    Session.Add("dia", diaSeleccionado);                    
                }
                datosModal.ID = id;
            }

        }
        /*
        protected void Grilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string dia = Convert.ToString(Grilla.Rows[e.RowIndex].FindControl("NombreDia"));
            int id = Convert.ToInt32(Grilla.SelectedDataKey);
            Session.Add("idEliminar", id);
            //Session.Add("nombreDiaEliminar", dia);
            btn_ModalPopupExtender.Show();

        }

        protected void Grilla_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            medicoDB.eliminarDias((int)Session["idEliminar"]);
        }*/
    }
}
