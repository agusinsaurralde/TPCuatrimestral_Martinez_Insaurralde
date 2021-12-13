<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="WebApplication1.About" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Pacientes</h1>
    <hr />
    
    <div class="container">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>
    </div>
   <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField datafield = "DNI" HeaderText ="DNI" />
                <asp:BoundField datafield = "NombreCompleto" HeaderText ="NOMBRE" />
                <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}" HeaderText ="FECHA DE NACIMIENTO" />    
                <asp:BoundField datafield = "Cobertura.Nombre" HeaderText ="COBERTURA" />
                <asp:BoundField datafield = "Telefono" HeaderText ="TELÉFONO" />
                <asp:BoundField datafield = "Email" HeaderText ="EMAIL" />
                <asp:BoundField datafield = "Dirección" HeaderText ="DIRECCIÓN" />
                <asp:BoundField datafield = "Estado" HeaderText ="ESTADO" />
                <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/> 
            </Columns>
        </asp:gridview>
    </div>



<!-- modal eliminar paciente -->
    <asp:Button  style="display:none" runat="server" ID="btnEliminarPacienteModal" />
   <ajaxToolkit:ModalPopupExtender ID="EliminarPaciente_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="EliminarPaciente_Modal" TargetControlID="btnEliminarPacienteModal" PopupControlID="PanelEliminarPaciente">
    </ajaxToolkit:ModalPopupExtender>
   

    <asp:Panel ID="PanelEliminarPaciente" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar el paciente?</label>
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary" ID="btnAceptarEliminar" Text="Aceptar" OnClick="btnAceptarEliminar_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>



</asp:Content>
