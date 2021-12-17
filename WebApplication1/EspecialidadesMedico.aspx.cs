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

                lblContraseña.Text = usuario.Contraseña;
                lblUsuario.Text = usuario.NombreUsuario;
            }

        }
    }
}
