<%@ Page Title="Diseño de Pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazDisenoPruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazDisenoPruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Diseño de pruebas</small></h1>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default active" ID="btn_crear" Enabled="true" Text="Ingresar" OnClick="btn_crear_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Text="Modificar" OnClick="btn_modificar_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Text="Eliminar" OnClick="btn_eliminar_Click" />
                </div>
            </div>
        </div>
    </section>
    <br />
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
    <br />
    <div id="form">
        <div class="row">
            <div id="panel_izquierda" class="col-md-10 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información de diseño</div>
                    </div>
                    <div class="panel-body">
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_proyecto" CssClass="control-label" AssociatedControlID="input_proyecto">Proyecto de prueba <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList runat="server" ID="input_proyecto" CssClass="form-control"></asp:DropDownList>
                                            <asp:Label runat="server" ID="label_error_proyecto" CssClass="text-danger"><small>Debe seleccionar un proyecto.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="row2" class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_nombre" CssClass="control-label" AssociatedControlID="input_nombre">Nombre de diseño: <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox runat="server" ID="input_nombre" CssClass="form-control" />
                                            <asp:Label runat="server" ID="label_nombre_vacio" CssClass="text-danger"><small>Debe ingresar un nombre de diseño.</small></asp:Label>
                                            <asp:Label runat="server" ID="label_error_input_nombre" CssClass="text-danger"><small>El nombre ingresado no es válido.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="row2.5" class="form-group">
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1" style="height: 150px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_disponibles" CssClass="table table-hover form-group">
                                                <asp:TableHeaderRow runat="server" ID="tabla_disponibles_header">
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btn_agregar" CssClass="btn btn-default" Text="Agregar  >>"></asp:Button>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btn_remover" CssClass="btn btn-default" Text="<< Remover"></asp:Button>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1" style="height: 150px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_agregados" CssClass="table table-hover form-group">
                                                <asp:TableHeaderRow runat="server" ID="tabla_asociados_header">
                                                </asp:TableHeaderRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="row3" class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_nivel" CssClass="control-label" AssociatedControlID="drop_nivel">Nivel de prueba: <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drop_nivel" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:Label runat="server" ID="label_error_drop_nivel" CssClass="text-danger"><small>Debe seleccionar un nivel de prueba.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_tecnica" CssClass="control-label" AssociatedControlID="drop_tecnica">Técnica de prueba: <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drop_tecnica" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:Label runat="server" ID="label_error_drop_tecnica" CssClass="text-danger"><small>Debe seleccionar una técnica de prueba.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="row4" class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_tipo" CssClass="control-label" AssociatedControlID="drop_tipo">Tipo de prueba: <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="drop_tipo" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:Label runat="server" ID="label_error_drop_tipo" CssClass="text-danger"><small>Debe seleccionar un tipo de prueba.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_ambiente" CssClass="control-label" AssociatedControlID="input_ambiente">Ambiente de pruebas: <span class="text-danger">*</span></asp:Label>
                                        </div>
                                        <div class="col-md-7">
                                            <asp:TextBox ID="input_ambiente" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Label runat="server" ID="label_error_ambiente" CssClass="text-danger"><small>Debe ingresar un ambiente de pruebas.</small></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="row5" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_criterios" CssClass="control-label" AssociatedControlID="input_criterio">Criterios de aceptación: <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox ID="input_criterio" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                                    <asp:Label runat="server" ID="label_error_criterio" CssClass="text-danger"><small>Debe ingresar un criterio de prueba.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row6" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_procedimiento" CssClass="control-label" AssociatedControlID="input_procedimiento">Procedimiento: <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox ID="input_procedimiento" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                                    <asp:Label runat="server" ID="label_error_procedimiento" CssClass="text-danger"><small>Debe ingresar un procedimiento de pruebas.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row7" class="form-group">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="col-md-5">
                                            <asp:Label runat="server" ID="label_responsable" CssClass="control-label" AssociatedControlID="drop_responsable">Procedimiento: <span class="text-danger">*</span></asp:Label>
                                            <asp:DropDownList ID="drop_responsable" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
