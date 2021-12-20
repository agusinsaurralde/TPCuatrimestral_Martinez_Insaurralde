using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Dominio;
using DBClinica;

namespace WebApplication1
{
   
    public partial class Formulario_web116 : System.Web.UI.Page
    {
        public bool valido { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Cobertura NuevaCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string agregado = "Cobertura";
            string error = "cobertura";

            if (Page.IsValid)
            {
                try
                {
                    NuevaCobertura.Nombre = txtCobertura.Text;
                    NuevaCobertura.Estado = true;
                    cargar.AgregarCobertura(NuevaCobertura);
                    // Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
                }
                catch (Exception)
                {
                    Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
                }
            }
           

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CoberturaDB coberturaDB = new CoberturaDB();
            List<Cobertura> lista = coberturaDB.lista();
            if (lista.Find(x => x.Nombre.ToUpper() == args.Value.ToUpper() && x.Estado == true) != null)
            {
                args.IsValid = false;
                return;
            }
            else
            {
                args.IsValid = true;
                return;
            }
        }
    }
}