﻿<%@ Page Title="Casos de pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazCasosDePruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Caso de Pruebas</small></h1>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default active" ID="btn_crear" Enabled="true" Text="Ingresar" OnClick="btn_crear_Click"/>
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Text="Modificar"  OnClick="btn_modificar_Click"/>
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Text="Eliminar"  OnClick="btn_eliminar_Click"/>
                </div>
            </div>
        </div>
    </section>
    <section id="alertas">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                </div>
                <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_exito"></asp:Label>
                </div>
                <div class="alert alert-warning alert-dismissible" id="alerta_advertencia" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_advertencia"></asp:Label>
                </div>
            </div>
        </div>
    </section>
    <div id="form">
        <div id="panel_izquierda" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Resumen</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-3"> 
                                    <asp:Label runat="server" ID="label_proyecto" CssClass="control-label" AssociatedControlID="drop_proyecto_asociado">Proyecto<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_proyecto_asociado" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_proyecto_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="row2_izq" class="form-group">
                                <div class="col-md-3"> 
                                    <asp:Label runat="server" ID="label_diseno" CssClass="control-label" AssociatedControlID="drop_diseno_asociado">Diseño<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_diseno_asociado" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_diseno_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="row3_izq" class="form-group">
                                <div class="col-md-3"> 
                                    <asp:Label runat="server" ID="label_caracteristicas_diseno" CssClass="control-label" AssociatedControlID="drop_caracteristicas_diseno">Características<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_caracteristicas_diseno" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_diseno_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    <div class="row">
        <div class="col-md-3 col-md-offset-9">
            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
        </div>
    </div>
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-3 col-md-offset-9">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_aceptar_Click" />
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_cancelar_Click" />
            </div>
        </div>
    </section>
    <section id="linea_separadora">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <hr />
            </div>
        </div>
    </section>
    <section id="area_consultas">
        <div class="row">
            <div class="col-md-11 col-md-offset-1">
                <h4>Casos de pruebas disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_casos_pruebas" CssClass="table table-hover form-group">
                    <asp:TableHeaderRow runat="server" ID="tabla_casos_pruebas_header">
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </section>
</asp:Content>
