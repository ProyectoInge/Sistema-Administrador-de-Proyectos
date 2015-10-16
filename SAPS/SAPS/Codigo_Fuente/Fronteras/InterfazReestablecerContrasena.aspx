<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReestablecerContrasena.aspx.cs" Inherits="SAPS.Fronteras.InterfazReestablecerContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1 page-header">
                <h1>SAPS <small>Reestablecer contraseña</small></h1>
            </div>
        </div>
    </section>
    <section id="alertas">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <b>
                        <asp:Label runat="server" ID="label_alerta_error" Text="¡Error! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                </div>
            </div>
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <b>
                        <asp:Label runat="server" ID="label_alerta_exito" Text="¡Éxito! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_exito"></asp:Label>
                </div>
            </div>
        </div>
    </section>
    <section id="contenido">
        <div class="row">
            <div id="panel_reestablecer" class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_usuario" CssClass="control-label" AssociatedControlID="input_usuario" Text="Usuario"></asp:Label>
                                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr />
                            <div id="row2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_nueva_contrasena1" CssClass="control-label" AssociatedControlID="input_nueva_contrasena1" Text="Digite su nueva contraseña"></asp:Label>
                                    <asp:TextBox runat="server" ID="input_nueva_contrasena1" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row3" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_nueva_contrasena2" CssClass="control-label" AssociatedControlID="input_nueva_contrasena2" Text="Vuelva a ingresar la contraseña"></asp:Label>
                                    <asp:TextBox runat="server" ID="input_nueva_contrasena2" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row4" class="form-group">
                                <div class="col-md-3 col-md-offset-5">
                                    <asp:Button runat="server" ID="btn_cancelar" CssClass="btn btn-default btn-sm" Text="Volver" OnClick="btn_cancelar_Click" />
                                </div>
                                <div class="col-md-4">
                                    <asp:Button runat="server" ID="btn_reestablecer" CssClass="btn btn-primary btn-sm" Text="Aceptar" OnClick="btn_reestablecer_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
