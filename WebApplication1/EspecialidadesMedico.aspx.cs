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

        public List<MedicoEspecialidades> listaEsp { get; set; }
        public DiasHabilesMedico objDias { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            listaEsp = (List<Dominio.MedicoEspecialidades>)Session["EspMedico"];
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> listaUsuarios = usuarioDB.listar();
            
            usuario = listaUsuarios.Find(x => x.IDUsuario == listaEsp[0].ID);
        }
    }
}
