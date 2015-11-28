<%@ Page Title="Generación de reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReportes.aspx.cs" Inherits="SAPS.Fronteras.InterfazReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_rp").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h1>SAPS <small>Generación de reportes</small></h1>
                </div>
            </div>
        </div>
    </section>
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
            <!--Primer caja - Proyecto-->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Proyecto
                                <div class="btn-group col-md-offset-6">
                                    <button type="button" class="btn btn-default" id="btn_estado_proyecto">Habilitado</button>
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="caret"></span>
                                        <span class="sr-only">Toggle Dropdown</span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li id="proyecto_habilitado"><a href="#">Habilitado</a></li>
                                        <li id="proyecto_inhabilitado"><a href="#">Inhabilitado</a></li>
                                    </ul>
                                </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <section id="seccion_filtros_proyecto">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" CssClass="control-label" ID="label_filtros_proyecto" AssociatedControlID="proyecto_input_fecha_inicio" Text="Filtros" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Oficinas" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_oficina" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Estado" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_estado">
                                            <asp:ListItem Text ="-Seleccione-" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Asignado" Value="Asignado"></asp:ListItem>
                                            <asp:ListItem Text="Pendiente de asignación" Value="Pendiente de asignación"></asp:ListItem>
                                            <asp:ListItem Text="En ejecución" Value="En ejecución"></asp:ListItem>
                                            <asp:ListItem Text="Finalizado" Value="Finalizado"></asp:ListItem>
                                            <asp:ListItem Text="Cerrado" Value="Cerrado"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Miembros" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_miembro" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Fecha de inicio" />
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="proyecto_input_fecha_inicio" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Fecha de finalización" />
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="proyecto_input_fecha_final" />
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_proyectos_disponibles">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Proyectos disponibles" AssociatedControlID="tabla_proyectos" />
                                    </div>
                                    <div class="col-md-4 col-md-offset-4">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="proyecto_check_todos" OnCheckedChanged="proyecto_check_todos_CheckedChanged" Text="Seleccionar todos" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div style="height: 250px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_proyectos" CssClass="table table-hover">
                                            </asp:Table>
                                        </div>
                                        <label class="text-info"><small>Los proyectos en rojo ya fueron marcados como "eliminados" en el sistema.</small></label>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_info_incluir_proyecto">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" ID="label_info_proyectos" AssociatedControlID="proyecto_check_miembros" CssClass="control-label" Text="Información a incluir" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_miembros" CssClass="checkbox checkbox-inline" Text="Miembros asociados" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_fechas" CssClass="checkbox checkbox-inline" Text="Fechas" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_disenos" CssClass="checkbox checkbox-inline" Text="Diseños asociados" />
                                    </div>
                                    <div class="col-md-5">
                                        <asp:CheckBox runat="server" ID="proyecto_check_oficina" CssClass="checkbox checkbox-inline" Text="Oficina asociada" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:CheckBox runat="server" ID="proyecto_check_objetivos" CssClass="checkbox checkbox-inline" Text="Objetivos" />
                                    </div>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <!--Segunda caja-->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Diseño</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_generar_reporte">
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-12">
                        <hr />
                    </div>
                </div>
                <div class="form-group">
                    <!-- Aca van los iconos de pdf o excel y los respectivos checkbox-->
                </div>
                <div class="form-group">
                    <div class="col-md-2 col-md-offset-4">
                        <asp:Button runat="server" CssClass="btn btn-success btn-block" ID="btn_generar_reporte" OnClick="btn_generar_reporte_Click" Text="Generar reporte" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button runat="server" CssClass="btn btn-danger btn-block" ID="btn_cancelar" OnClick="btn_cancelar_Click" Text="Cancelar" />
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {

            // ---------------------------------------------------------------------- Panel de proyectos ----------------------------------------------------------------------

            //Revisa si el check de proyectos esta seleccionado para marcar todos
            if ($("#<%=proyecto_check_todos.ClientID%>").is(":checked")) {
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("checked", true);
                //Deshabilito la tabla de los proyectos
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", true);
            } else {
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("checked", false);
                //Habilito la tabla de los proyectos
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", false);
            }

            //Selecciono todos los proyectos
            $("#<%=proyecto_check_todos.ClientID%>").click(function () {
                if ($("#<%=proyecto_check_todos.ClientID%>").is(":checked")) {
                    $("#<%= tabla_proyectos.ClientID%>").find("*").prop("checked", true);
                    //Deshabilito la tabla de los proyectos
                    $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", true);
                } else {
                    $("#<%= tabla_proyectos.ClientID%>").find("*").prop("checked", false);
                    //Habilito la tabla de los proyectos
                    $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", false);
                }
                return true;
            });

            //Habilito los campos
            $("#proyecto_habilitado").click(function () {
                $("#btn_estado_proyecto").text("Habilitado");
                $("#<%=proyecto_drop_estado.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_input_fecha_final.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_input_fecha_inicio.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_drop_miembro.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_drop_oficina.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_disenos.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_fechas.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_miembros.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_objetivos.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_oficina.ClientID%>").prop("disabled", false);
                $("#<%=proyecto_check_todos.ClientID%>").prop("disabled", false);

                //Habilito la tabla de los proyectos
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", false);

            });

            //Deshabilito los campos
            $("#proyecto_inhabilitado").click(function () {
                $("#btn_estado_proyecto").text("Inhabilitado");
                $("#<%=proyecto_drop_estado.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_input_fecha_final.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_input_fecha_inicio.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_drop_miembro.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_drop_oficina.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_disenos.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_fechas.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_miembros.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_objetivos.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_oficina.ClientID%>").prop("disabled", true);
                $("#<%=proyecto_check_todos.ClientID%>").prop("disabled", true);

                //Deshabilito la tabla de los proyectos
                $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", true);
            });
            // ---------------------------------------------------------------------- Fin panel proyectos ---------------------------------------------------------------------
        });
    </script>

</asp:Content>
