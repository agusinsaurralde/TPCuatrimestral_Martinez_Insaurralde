<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpecialtysViews.aspx.cs" Inherits="WebApplication1.SpecialtysViews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function validar() {
            var especialidad = document.getElementById("<% = txtEspecialidad.ClientID %>").value;
            var editarEsp = document.getElementById("<% = txtEditarEspecialidad.ClientID %>").value;

            if (especialidad === "") {
                 $("#txtEspecialidad").addClass("is-invalid");
                 return false;
            }
            else {
                $("#txtEspecialidad").removeClass("is-invalid");
            }

            if (editarEsp == "") {
                $("#txtEditarEspecialidad").addClass("is-invalid");
                return false;
            }
            else {
                $("#txtEditarEspecialidad").removeClass("is-invalid");
            }
             return true;

         }
    </script>



    <link href="Estilos.css" rel="stylesheet" />
    <br />
     <h1>Especialidades</h1>
    <hr />

               <div class="container">
                   <div class="d-flex flex-row-reverse">
                    <div class="col-md-4">
                       <div class="input-group mb-3">
                            <asp:TextBox CssClass="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostback="true" aria-describedby="button-addon2" runat="server" />
                              <asp:Button Text="BUSCAR" Font-Bold="true" Font-Size="Small" CssClass="btn btn-primary" OnClick ="Click_Buscar" runat="server" />
                       </div>

                     </div>
                       <div class="col ">
                             <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
                       </div>
                    </div>
               </div>
    <asp:Label ID="resultados" Text="No se encontraron resultados." Visible="false" runat="server" />
            <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" AutoPostback="true" OnRowDeleting="Grilla_eliminar" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField datafield = "Nombre" HeaderText ="ESPECIALIDAD" />
                <asp:BoundField datafield = "Estado" HeaderText ="ESTADO" />
                <asp:CommandField ButtonType="Image" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" SelectImageUrl="Iconos/pencil-square.svg" />   
                <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                     
            </Columns>
        </asp:gridview>
    </div>
                </ContentTemplate>
    </asp:UpdatePanel>

<!-- modal agregar especialidad-->
    <asp:Button  style="display:none" runat="server" ID="btnAgregarEspecialidadModal" />
    
   <ajaxToolkit:ModalPopupExtender ID="btnAgregarEspecialidad_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnAgregarEspecialidad_Modal" TargetControlID="btnAgregarEspecialidadModal" PopupControlID="PanelAgregarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelAgregarEspecialidad" Width="400px" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Agregar Especialidad</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body" style="margin:25px 15px 35px 15px">
            <div class="row"><asp:Label Text="ESPECIALIDAD" CssClass="form-label" Font-Bold="true" Font-Size="Small" runat="server" /></div>
            <div class="row">
                <div class="col"> <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtEspecialidad"  runat="server" /></div>
            </div>
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptar" Font-Bold="true" Font-Size="Small" Text="ACEPTAR" OnClick="btnAceptar_Click" runat="server" />
        </div>
    </asp:Panel>

     <!-- modal editar especialidad-->
    <asp:Button  style="display:none" runat="server" ID="btnEditarEspecialidad" />
    
   <ajaxToolkit:ModalPopupExtender ID="editarEspecialidad_Modal" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="editarEspecialidad_Modal" TargetControlID="btnEditarEspecialidad" PopupControlID="PanelEditarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelEditarEspecialidad" Width="400px" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Editar Especialidad</h5>
            <asp:Button id="exitEditar" class="btn-close" data-bs-dismiss="modal" runat="server" />
        </div>

       
        <div class="modal-body" style="margin:25px 15px 35px 15px">
             <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <asp:Label Text="ESPECIALIDAD" class="form-label" Font-Bold="true" Font-Size="Small" runat="server" />
                    </div>
                    <div class="row">
                         <div class="col">
                           <asp:TextBox class="form-control rounded-pill" ClientIDMode="Static" ID="txtEditarEspecialidad" runat="server" />
                         </div>
                    </div>
                 </ContentTemplate>
             </asp:UpdatePanel>
        </div>
          
        <div class="modal-footer">

                <asp:Button Text="CANCELAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
                 <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEditar" Font-Bold="true" Font-Size="Small" Text="ACEPTAR" OnClick="btnAceptarEditar_Click" runat="server" />
        </div>
           
    </asp:Panel>


       <!-- modal eliminar especialidad-->
    <asp:Button  style="display:none" runat="server" ID="btnEliminarEspecialidadModal" />
    
   <ajaxToolkit:ModalPopupExtender ID="eliminarEspecialidad_Modal" CancelControlID="exitEliminar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="eliminarEspecialidad_Modal" TargetControlID="btnEliminarEspecialidadModal" PopupControlID="PanelEliminarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>
  
    <asp:Panel ID="PanelEliminarEspecialidad" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar Especialidad</h5>
          <button id="exitEliminar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="¿Está seguro que desea eliminar la especialidad?" runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminar" Text="Aceptar" OnClick="btnAceptarEliminar_Click" runat="server" />
        </div>
    </asp:Panel>

</asp:Content>

