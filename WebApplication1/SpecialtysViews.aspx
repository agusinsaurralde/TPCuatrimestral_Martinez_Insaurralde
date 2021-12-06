<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpecialtysViews.aspx.cs" Inherits="WebApplication1.SpecialtysViews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Especialidades</h1>
    <hr />
    <br />
     <div class="input-group mb-3">
          <asp:TextBox class="form-control" ID="txtBusqueda" aria-describedby="button-addon2" runat="server" />
           <asp:Button Text="Buscar" OnClick ="Click_Buscar" class="btn btn-outline-secondary" runat="server" />
     </div>
      <div>       
        <asp:Button Text="Agregar" class="btn btn-primary" OnClick="Click_Agregar" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" runat="server" />
       </div> 

         <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "Id" HeaderText ="ID" />
                <asp:BoundField datafield = "Nombre" HeaderText ="Especialidad" />            
                <asp:BoundField datafield = "Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />   
                <asp:CommandField ButtonType="Button"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC"/> 
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
