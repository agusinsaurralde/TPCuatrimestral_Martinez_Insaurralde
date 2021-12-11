<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EspecialidadesMedico.aspx.cs" Inherits="WebApplication1.EspecialidadesMedico" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3> Especialidades</h3>
    <hr />
    <%
      foreach (var item in listaEsp) 
      {
            objDias = ((List<Dominio.DiasHabilesMedico>)Session["DiasHabiles"]).Find(x => x.Especialidad.Id == item.especialidad.Id) ;%>
              <h5><%: item.especialidad.Nombre %></h5>
                 <hr />
            <table class="table">
             <thead>
               <tr>
                 <th scope="col">Dia</th>
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
                    <% } %>
            </table>


     <% } %>


</asp:Content>
