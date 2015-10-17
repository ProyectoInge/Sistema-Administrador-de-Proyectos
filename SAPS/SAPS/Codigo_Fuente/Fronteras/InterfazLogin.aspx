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
            <div class="col-md-6 col-md-offset-3">
                <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                </div>
            </div>
        </div>
    </section>
    <section id="login">
        <div class="row">
            <div id="panel_login" class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_usuario" CssClass="control-label" AssociatedControlID="input_usuario" Text="Usuario"></asp:Label>
                                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_contrasena" CssClass="control-label" AssociatedControlID="input_contrasena" Text="Contraseña"></asp:Label>
                                    <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <asp:Button runat="server" ID="btn_login" CssClass="btn btn-primary btn-block" Text="Ingresar" OnClick="btn_login_Click" />
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
