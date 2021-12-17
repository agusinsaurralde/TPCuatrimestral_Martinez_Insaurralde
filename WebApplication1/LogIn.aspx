<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebApplication1.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos.css" rel="stylesheet" />
     <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
</head>
<body style="background-color: royalblue; background-size:100%; background-image:url(https://wallpapercave.com/wp/wp2219750.jpg)">
    <form id="form1" runat="server">
        
        <div class="container">
            <div class="row" style="margin-top: 180px; display:flex">
                 <div class="col-md-4"></div>
                 <div class="col-md-4" style="padding: 40px; border-radius: 10px; background-color:white;">
                     <h1 style="margin-bottom:40px">Iniciar Sesión</h1>

                     <div style="margin-bottom:30px">
                         <asp:Label Text="USUARIO" Font-Bold="true" Font-Size="Medium" runat="server" />
                         <asp:TextBox ID="txtbxUsuario" CssClass="form-control rounded-pill" runat="server" />
                  
                    </div>
                     <div >
                         <asp:Label Text="CONTRASEÑA" Font-Bold="true" Font-Size="Medium" runat="server" />
                         <asp:TextBox ID="txtbxContraseña" CssClass="form-control rounded-pill" type="password" runat="server" />
                     </div>
                     <div style="margin-bottom:40px; margin-top:15px;">
                             <asp:Label id="lblError" ForeColor="Red" runat="server" />
                         </div>
                      <div class="d-flex justify-content-end">
                           <asp:Button ID="btnIngresar" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" OnClick="Click_Ingresar" Text="INGRESAR" runat="server" />
                      </div>
                
            </div>
            <div class="col-md-4"></div>
            </div>
        </div>
    </form>
</body>
</html>
