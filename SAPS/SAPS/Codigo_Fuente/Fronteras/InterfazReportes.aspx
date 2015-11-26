<%@ Page Title="Generación de reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReportes.aspx.cs" Inherits="SAPS.Fronteras.InterfazReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_rp").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
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
            <div class="col-md-5 col-md-offset-1">
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
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div style="height: 100px; overflow-y: scroll">
                                        <asp:Table runat="server" ID="tabla_proyectos" CssClass="table table-bordered">
                                            <asp:TableHeaderRow runat="server" ID="header_tabla_proyectos">
                                                <asp:TableHeaderCell runat="server" CssClass="col-md-2 text-center" ID="celda_check_proyectos">
                                                    <asp:CheckBox runat="server" ID="check_header_proyecto" />
                                                </asp:TableHeaderCell>
                                                <asp:TableHeaderCell runat="server" ID="celda_nombre_proyecto" CssClass="text-center" Text="Nombre"></asp:TableHeaderCell>
                                            </asp:TableHeaderRow>
                                        </asp:Table>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" ID="label_info_proyectos" AssociatedControlID="check_miembros" CssClass="control-label" Text="Información a incluir:" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:CheckBox runat="server" ID="check_miembros" />
                                    Miembros asociados
                                   
                                </div>
                                <div class="col-md-5">
                                    <asp:CheckBox runat="server" ID="check_fechas" />
                                    Fechas
                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5">
                                    <asp:CheckBox runat="server" ID="check_disenos" />
                                    Diseños asociados
                                   
                                </div>
                                <div class="col-md-5">
                                    <asp:CheckBox runat="server" ID="check_oficina" />
                                    Oficina asociada
                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:CheckBox runat="server" ID="check_objetivos" />
                                    Objetivos
                                   
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" CssClass="control-label" ID="label_filtros_proyecto" AssociatedControlID="drop_encargado" Text="Filtros:" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_encargado" />
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_fecha_ini" />
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_fecha_fin" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_oficina" />
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_estado" />
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drop_miembro" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!--Segunda caja-->
            <div class="col-md-5">
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
                    <div class="col-md-10 col-md-offset-1">
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
            $("#proyecto_habilitado").click(function () {
                $("#btn_estado_proyecto").text("Habilitado");
                $("#<%=drop_encargado.ClientID%>").prop("disabled", false);
                $("#<%=drop_estado.ClientID%>").prop("disabled", false);
                $("#<%=drop_fecha_fin.ClientID%>").prop("disabled", false);
                $("#<%=drop_fecha_ini.ClientID%>").prop("disabled", false);
                $("#<%=drop_miembro.ClientID%>").prop("disabled", false);
                $("#<%=drop_oficina.ClientID%>").prop("disabled", false);
                $("#<%=check_disenos.ClientID%>").prop("disabled", false);
                $("#<%=check_fechas.ClientID%>").prop("disabled", false);
                $("#<%=check_miembros.ClientID%>").prop("disabled", false);
                $("#<%=check_objetivos.ClientID%>").prop("disabled", false);
                $("#<%=check_oficina.ClientID%>").prop("disabled", false);
            });
            $("#proyecto_inhabilitado").click(function () {
                $("#btn_estado_proyecto").text("Inhabilitado");
                $("#<%=drop_encargado.ClientID%>").prop("disabled", true);
                $("#<%=drop_estado.ClientID%>").prop("disabled", true);
                $("#<%=drop_fecha_fin.ClientID%>").prop("disabled", true);
                $("#<%=drop_fecha_ini.ClientID%>").prop("disabled", true);
                $("#<%=drop_miembro.ClientID%>").prop("disabled", true);
                $("#<%=drop_oficina.ClientID%>").prop("disabled", true);
                $("#<%=check_disenos.ClientID%>").prop("disabled", true);
                $("#<%=check_fechas.ClientID%>").prop("disabled", true);
                $("#<%=check_miembros.ClientID%>").prop("disabled", true);
                $("#<%=check_objetivos.ClientID%>").prop("disabled", true);
                $("#<%=check_oficina.ClientID%>").prop("disabled", true);
            });
        });
    </script>

</asp:Content>
