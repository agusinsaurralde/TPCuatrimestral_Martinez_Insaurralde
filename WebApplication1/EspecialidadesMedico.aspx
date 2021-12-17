<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspecialidadesMedico.aspx.cs" Inherits="WebApplication1.EspecialidadesMedico" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3 style="margin-top: 50px"> Especialidades</h3>
    <hr />
    <%
      foreach (var item in listaEsp) 
      {
            objDias = ((List<Dominio.DiasHabilesMedico>)Session["DiasHabiles"]).Find(x => x.Especialidad.Id == item.especialidad.Id) ;%>
              <h5 style="margin-top:50px"><%: item.especialidad.Nombre.ToUpper() %></h5>
            <table class="table" style="margin-bottom:70px">
             <thead>
               <tr>
                 <th scope="col">Día</th>
                 <th scope="col">Horario</th>
               </tr>
             </thead>
                <tbody>
                <% List<Dominio.DiasHabilesMedico> diasFiltradosPorEspecialidad = listaDias.FindAll(x => x.Especialidad.Id == item.especialidad.Id);
                    
                    
                        foreach (Dominio.DiasHabilesMedico dias in diasFiltradosPorEspecialidad)
                        {%>
                                       <tr>
                                         <td><%: dias.NombreDia%> </td>
                                         <td><%:dias.HorarioEntrada.ToString("HH:mm") + " - " + objDias.HorarioSalida.ToString("HH:mm")%></td> 
                                       </tr>
                     <% }
                         if(diasFiltradosPorEspecialidad.Count == 0)
                          { %>
                                <tr>
                                    <td><asp:Label Text="No se encontraron resultados." runat="server" /></td>
                                </tr>
                                 
                          <% }
                         %>
                        
            </table>


     <% } %>

    <h3 style="margin-top: 50px"> Usuario</h3>
    <hr />
    <div>
        <asp:Label Text="NOMBRE DE USUARIO: "  Font-Bold="true" Font-Size="Small" runat="server" />
        <asp:Label ID="lblUsuario" runat="server" />
    </div>
    <div style="margin-top: 10px">
        <asp:Label Text="CONTRASEÑA: " Font-Bold="true" Font-Size="Small" runat="server" />
        <asp:Label ID="lblContraseña" runat="server" />
     </div>  
   


</asp:Content>
