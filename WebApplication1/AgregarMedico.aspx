<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web113" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h1>Agregar Médico</h1>
        <hr />
        <div class="Container">
            <div class="row">
                <div class="col">
                    <asp:Label Text="DNI" runat="server" />
                    <asp:TextBox ID="txtDNI" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Matrícula" runat="server"  />
                    <asp:TextBox ID="txtMatricula" runat="server" />
                </div>
            </div>
        </div>
        <div class="Container">
            <div class="row">
                <div class="col">
                    <asp:Label Text="Apellido" runat="server" />
                    <asp:TextBox ID="txtApellido" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Nombre" runat="server" />
                    <asp:TextBox ID="txtNombre" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Especialidad" runat="server" />
                    <asp:DropDownList ID="ddlistEspecialidad" class="btn btn-secondary btn-sm dropdown-toggle" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label Text="Fecha de Nacimiento" runat="server" />
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" />
                </div>
            </div>
        </div>
        <div class="Container">
            <div class="row">
                <div class="col">
                    <asp:Label Text="Teléfono" runat="server" />
                    <asp:TextBox ID="txtTelefono" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Email" type="email" runat="server" />
                    <asp:TextBox ID="txtEmail" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Dirección" runat="server" />
                    <asp:TextBox ID="txtDireccion" runat="server" />
                </div>
            </div>
        </div>
        <div class="Container">
            <div class="row">
                <div class="col">
                    <asp:Label Text="Turno" runat="server" />
                    <asp:DropDownList ID="ddlist" class="btn btn-secondary btn-sm dropdown-toggle" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <asp:Label Text="Horario de Entrada" runat="server" />
                    <asp:TextBox ID="txtHorarioEntrada" runat="server" />
                </div>
                <div class="col">
                    <asp:Label Text="Horario de Salida" runat="server" />
                    <asp:TextBox ID="txtHorarioSalida" runat="server" />
                </div>
            </div>
            <asp:Button ID="btnAceptar" Text="Aceptar" runat="server" Onclick="btnAceptar_Click" />
        </div>
    </body>

</asp:Content>
