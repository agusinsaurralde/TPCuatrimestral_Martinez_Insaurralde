<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="WebApplication1.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Médicos</h1>
    <hr />

    <div class="container">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
                 <asp:TextBox class="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostBack="true" aria-describedby="button-addon2" runat="server" />
                 <asp:Button Text="Buscar" Font-Bold="true" OnClick ="Click_Buscar" class="btn btn-primary" runat="server" />
            </div>
          </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>

        <asp:Label ID="lblBusquedaIncorrecta" Text="No se encontraron resultados." Visible="false" runat="server" />
        

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                       <div  >
                           <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoPostback="true"  AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
                               <Columns>
                                   <asp:BoundField datafield = "ID" HeaderText ="ID" />
                                   <asp:BoundField datafield = "Matricula" HeaderText ="MATRÍCULA" />
                                   <asp:BoundField datafield = "NombreCompleto" HeaderText ="NOMBRE" />              
                                   <asp:BoundField datafield = "Telefono" HeaderText ="TELÉFONO" />
                                   <asp:BoundField datafield = "Email" HeaderText ="EMAIL" />
                                   <asp:BoundField datafield = "Dirección" HeaderText ="DIRECCIÓN" />
                                   <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}"  HeaderText ="FECHA DE NACIMIENTO" />
                                   <asp:BoundField datafield = "Estado" HeaderText ="ESTADO" />
                                   <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="+ INFO" ControlStyle-Font-Bold="true" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BorderStyle="None" />
                                   <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                                   <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
                                   
                               </Columns>
                           </asp:gridview>
                      </div>
                </ContentTemplate>
        </asp:UpdatePanel>

 
    </div>
   
 <!-- modal eliminar-->
    <asp:Button  style="display:none" runat="server" ID="btnEliminar" />
    
   <ajaxToolkit:ModalPopupExtender ID="btnEliminar_Modal" CancelControlID="exitEliminar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminar_Modal" TargetControlID="btnEliminar" PopupControlID="Panel">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="Panel" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar Médico</h5>
          <button id="exitEliminar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="¿Está seguro que desea eliminar el médico?" runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarEliminar" Text="Aceptar" OnClick="btnAceptarEliminar_Click" runat="server" />
        </div>
    </asp:Panel>

</asp:Content>






