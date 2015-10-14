<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazLogin.aspx.cs" Inherits="SAPS.Fronteras.InterfazLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1 page-header">
                <h1>SAPS <small>Ingresar al sistema</small></h1>
            </div>
        </div>
    </section>
    <section id="alertas">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <b>
                        <asp:Label runat="server" ID="titulo_alerta" Text="¡Error! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                </div>
            </div>
        </div>
    </section>
    <section id="form">
        <div class="form-group col-md-offset-4">
            <div id="row1" class="row">
                <asp:Label runat="server" ID="label_usuario" CssClass="col-md-2 control-label" AssociatedControlID="input_usuario" Text="Usuario"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div id="row2" class="row">
                <asp:Label runat="server" ID="label_contrasena" CssClass="col-md-2 control-label" AssociatedControlID="input_contrasena" Text="Contraseña"></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <br />
            <div id="row3" class="row">
                <div class="col-md-2 col-md-offset-4">
                    <asp:Button runat="server" ID="btn_login" CssClass="btn btn-primary" Text="Ingresar" OnClick="btn_login_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
