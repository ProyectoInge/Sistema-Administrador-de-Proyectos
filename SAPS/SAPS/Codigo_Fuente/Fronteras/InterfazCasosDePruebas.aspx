<%@ Page Title="Casos de pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazCasosDePruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_cdp").addClass("active");
    });
    </script>
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
    <div id="form">
        <div class="row">
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
                            <!-- Esto es necesario para pruebas de integracion, ahorita solo vamos a hacer unitarias
                            <div id="row3_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_caracteristicas_diseno" CssClass="control-label" AssociatedControlID="drop_caracteristicas_diseno">Características<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_caracteristicas_diseno" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_diseno_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div> -->
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Requerimientos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_der" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_requerimientos">Requerimientos disponibles<span class="text-danger">*</span></asp:Label>
                                    <asp:DropDownList ID="drop_requerimientos" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_izquierda2" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Datos del caso de prueba</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq_2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lebel_text_proposito" CssClass="control-label" AssociatedControlID="text_proposito">Propósito<span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="text_proposito" CssClass="form-control" Rows="3" Style="resize: none" TextMode="multiline" />
                                </div>
                            </div>
                            <div id="row2_izq_2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lebel_text_flujo_central" CssClass="control-label" AssociatedControlID="text_flujo_central">Flujo Central<span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="text_flujo_central" CssClass="form-control" Rows="3" Style="resize: none" TextMode="multiline" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha_2" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Entrada de datos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="label_valor_entradas" AssociatedControlID="input_entradas_valor" CssClass="control-label">Valor</asp:Label>
                                    <asp:TextBox runat="server" ID="input_entradas_valor" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="label_entradas_estado" AssociatedControlID="drop_entradas_estado" CssClass="control-label">Estado</asp:Label>
                                    <asp:DropDownList runat="server" ID="drop_entradas_estado" CssClass="form-control">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Válido" Value="v"></asp:ListItem>
                                        <asp:ListItem Text="Inválido" Value="i"></asp:ListItem>
                                        <asp:ListItem Text="No aplica" Value="na"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div class="btn-group" role="group">
                                        <asp:Button runat="server" ID="btn_agregar_entrada" CssClass="btn btn-link" Text="Agregar" />
                                        <asp:Button runat="server" CssClass="btn btn-link" ID="btn_entradas_eliminar" Text="Eliminar" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_entradas_disponibles" CssClass="control-label" AssociatedControlID="drop_entradas_disponibles">Entradas disponibles</asp:Label>
                                    <asp:DropDownList runat="server" ID="drop_entradas_disponibles" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_entradas_resultado" AssociatedControlID="input_entradas_resultado" CssClass="control-label">Resultado esperado</asp:Label>
                                    <asp:TextBox runat="server" ID="input_entradas_resultado" CssClass="form-control" Rows="2" Style="resize: none" TextMode="multiline"></asp:TextBox>
                                </div>
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
    <br />
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
                </asp:Table>
            </div>
        </div>
    </section>
</asp:Content>
