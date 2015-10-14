<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAPS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Bienvenido</h1>
        <p class="lead">Usted acaba de acceder al Sistema Administrador de Proyectos de Software (SAPS). Para poder acceder a las funcionalidades
            del sistema, es necesario que inicie sesión.
        </p>
        <p><a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazLogin" class="btn btn-primary btn-lg">Ingresar &raquo;</a></p>
    </div>
</asp:Content>
