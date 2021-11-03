<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="WebApplication1.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clinica Demar</title>
    <link href="Estilos.css" rel="stylesheet" /> 
</head>

<header>
    <h1>Clínica Demar</h1>
</header>

<body>
    <form class="formIngreso" runat="server">
        <div class="contenedor">   
        <div class="textbox">   
            <asp:TextBox id="txtbxUsuario" runat="server" placeholder="Usuario"/>
        </div>

        <div class="textbox">  
             <asp:TextBox id="txtbxContraseña" type="password" runat="server" placeholder="Contraseña"/>
        </div>

        <div class="lista">  
            <asp:DropDownList ID="ddlListaIngreso" runat="server">
                <asp:ListItem Text="Médico" />
                <asp:ListItem Text="Administrador" />
                <asp:ListItem Text="Recepcionista" />
            </asp:DropDownList>
        </div>

        <div class="boton">  
            <asp:Button id="btnIngresar" Text="Ingresar" runat="server" />
        </div>

        </div>
    </form>
</body>

</html>