﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="WebApplication1.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Empleados</h1>
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
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField datafield = "Apellido" HeaderText ="APELLIDO" />
                <asp:BoundField datafield = "Nombre" HeaderText ="NOMBRE" />
                <asp:BoundField datafield = "Telefono" HeaderText ="TELÉFONO" />
                <asp:BoundField datafield = "Email" HeaderText ="EMAIL" />
                <asp:BoundField datafield = "Dirección" HeaderText ="DIRECCIÓN" />
                <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}"  HeaderText ="FECHA DE NACIMIENTO" />
                <asp:BoundField datafield = "TipoEmp.Nombre" HeaderText ="TIPO"/>
                <asp:CommandField ButtonType="Button"  ShowSelectButton="True" SelectText="Detalle" ControlStyle-CssClass="btn btn-primary rounded-pill"/>  
                <asp:CommandField ButtonType="Image"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" EditImageUrl="Iconos/pencil-square.svg" />   
                <asp:CommandField ButtonType="Image"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary rounded-pill" ControlStyle-BackColor="White" ControlStyle-BorderColor="White"  DeleteImageUrl="Iconos/x-circle.svg"/>  
            </Columns>
        </asp:gridview>
    </div>
</asp:Content>
