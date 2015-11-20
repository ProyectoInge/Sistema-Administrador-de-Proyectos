<%@ Page Title="Ejecución de Pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazEjecucionPruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazEjecucionPruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_ep").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Ejecución de Pruebas</small></h1>
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
            <div class="col-md-6 col-md-offset-3">
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
    <section id="form">
        <div class="row">
            <div id="panel_1" class="col-md-10 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información del diseño</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel1" class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_disenos_disponibles"> Diseño <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-3 col-xs-3">
                                    <asp:DropDownList ID="drop_disenos_disponibles" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_disenos_disponibles_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_diseno"><small>Debe seleccionar un diseño de prueba.</small></asp:Label>
                                </div>
                                <div class="col-md-1 col-md-offset-1 col-xs-2">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="input_ambiente_diseno">Ambiente</asp:Label>
                                </div>
                                <div class="col-md-5 col-xs-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="input_ambiente_diseno" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row2_panel1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_procedimiento_diseno" CssClass="control-label" AssociatedControlID="input_procedimiento_diseno">Procedimiento</asp:Label>
                                    <asp:TextBox ID="input_procedimiento_diseno" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row3_panel1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_criterios_aceptacion_diseno" CssClass="control-label" AssociatedControlID="input_criterios_aceptacion_diseno">Criterios de aceptación</asp:Label>
                                    <asp:TextBox ID="input_criterios_aceptacion_diseno" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_2" class="col-md-10 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Lista de resultados</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel2" class="form-group">
                                <div class="col-md-12" style="height: 250px; overflow-y: scroll">
                                    <asp:Table runat="server" ID="tabla_resultados" CssClass="table table-hover form-group">
                                    </asp:Table>
                                </div>
                            </div>
                            <div id="row2_panel2" class="form-group">
                                <div class="col-md-3 col-md-offset-9">
                                    <asp:Button runat="server" CssClass="btn btn-link" ID="btn_agregar_resultado" Text="Agregar" OnClick="btn_agregar_resultado_Click" />
                                    <asp:Button runat="server" CssClass="btn btn-link" ID="btn_eliminar_resultado" Text="Eliminar" OnClick="btn_eliminar_resultado_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_3" class="col-md-10 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información de la ejecución</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel3" class="form-group">
                                <div class="col-md-2">
                                    <asp:Label runat="server" ID="label_responsable" AssociatedControlID="drop_rh_disponibles" CssClass="control-label">Responsable <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="drop_rh_disponibles" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_rh"><small>Debe seleccionar un responsable para la ejecución.</small></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_fecha" AssociatedControlID="input_fecha" CssClass="control-label">Fecha de la última ejecución <span class="text-danger"">*</span></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox runat="server" ID="input_fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_fecha"><small>Debe seleccionar una fecha.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_panel3" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_incidentes" CssClass="control-label" AssociatedControlID="input_incidentes">Incidentes durante la ejecución <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox ID="input_incidentes" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" Style="resize: none" placeholder="Ingrese N/A si no se presentó ningún incidente"></asp:TextBox>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_incidentes"><small>Este campo no puede quedar vacío.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="row">
        <div class="col-md-3 col-md-offset-9">
            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
        </div>
    </div>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-3 col-md-offset-9">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_Aceptar_Click" />
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_Cancelar_Click" />
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
                <h4>Ejecuciones disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_ejecuciones" CssClass="table table-hover form-group">
                </asp:Table>
            </div>
        </div>
    </section>
    <!-- Modals eliminar -->
    <section id="modal_eliminar">
        <div class="modal fade bs-example-sm" id="modal_alerta" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">
                                    <asp:Label ID="titulo_modal" runat="server" Text="¡Atención!"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="cuerpo_modal" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <div class="alert alert-success" id="mensaje_exito_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="cuerpo_mensaje_exito" Text="Se eliminó correctamente la ejecución."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="Label3" Text="Se presentó un error, intente eliminar nuevamente la ejecución."></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_cancelar_Click" CssClass="btn btn-link" Style="color: darkgray" ID="btn_modal_cancelar" Text="Volver" runat="server" />
                                <asp:Button OnClick="btn_modal_aceptar_Click" CssClass="btn btn-danger" ID="btn_modal_aceptar" Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_ep").addClass("active");// Para activar el elemento en el navbar

            /* Los metodos de aca son para realizar las validacion de datos de lado del cliente. */

            //Escondo los labels de errores
            $("#<%= label_error_diseno.ClientID%>").hide();
            $("#<%= label_error_rh.ClientID%>").hide();
            $("#<%= label_error_fecha.ClientID%>").hide();
            $("#<%= label_error_incidentes.ClientID%>").hide();

            //Validacion del diseño seleccionado
            $("#<%= drop_disenos_disponibles.ClientID%>").blur(function () {
                var diseno_seleccionado = $(this).val();
                if (diseno_seleccionado == "") {
                    $("#<%= label_error_diseno.ClientID%>").show();
                } else {
                    $("#<%= label_error_diseno.ClientID%>").hide();
                }
            });

            //Validacion del responsable seleccionado
            $("#<%= drop_rh_disponibles.ClientID%>").blur(function () {
                var rh_seleccionado = $(this).val();
                if (rh_seleccionado == "") {
                    $("#<%= label_error_rh.ClientID%>").show();
                } else {
                    $("#<%= label_error_rh.ClientID%>").hide();
                }
            });

            //Validacion de la fecha ingresada
            $("#<%= input_fecha.ClientID%>").blur(function () {
                var fecha_seleccionada = $(this).val();
                if (fecha_seleccionada == "") {
                    $("#<%= label_error_fecha.ClientID%>").show();
                } else {
                    $("#<%= label_error_fecha.ClientID%>").hide();
                }
            });

            //Validacion de los incidentes
            $("#<%= input_incidentes.ClientID%>").blur(function () {
                var incidentes_ingresados = $("#<%= input_incidentes.ClientID%>").val();
                if (incidentes_ingresados == "") {
                    $("#<%= label_error_incidentes.ClientID%>").show();
                } else {
                    $("#<%= label_error_incidentes.ClientID%>").hide();
                }
            });
        });
    </script>
</asp:Content>
