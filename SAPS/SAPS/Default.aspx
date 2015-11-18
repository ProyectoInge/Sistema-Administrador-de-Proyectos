<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAPS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_home").addClass("active");
    });
    </script>
    <div class="barra-default">
    </div>
    <div class="row titulo-default">
        <div class="col-md-9 col-md-offset-1 col-sm-9 col-sm-offset-1 col-lg-5 col-lg-offset-2">
            <div class="hvr-grow">
                <h1 style="font-size: 60px">SAPS es su herramienta para administrar proyectos de software.</h1>
            </div>
        </div>
    </div>
    <div class="row contenido-default">
        <div class="col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1 col-lg-8 col-lg-offset-2">
            <div class="form-horizontal">
                <div class="form-group ">
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                        <h3>Recursos humanos</h3>
                        <hr />
                        <p>
                            Aquí podrá administrar y consultar todos los recursos humanso disponibles en el sistema. 
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazRecursosHumanos.aspx" class="btn btn-primary">Recursos humanos &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                            <h3>Proyectos de prueba</h3>
                            <hr />
                            <p>
                                En esta sección podrá encontrar información a cerca de todos los proyectos que se encuentran en el sistema. Podrá consultar, modificar y eliminar los proyectos dependiendo de sus permisos. 
                            </p>
                            <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazProyectosDePruebas.aspx" class="btn btn-primary">Proyectos de prueba &raquo;</a>
                        </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                        <h3>Diseños de prueba</h3>
                        <hr />
                        <p>
                            En los diseños de prueba se va a pdoer llevar control de todos los diseños disponibles para un proyecto. En este apartado
                            se incluye todos los requerimientos que tiene un proyecto para probarlos.
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazDisenoPruebas.aspx" class="btn btn-primary">Diseños de prueba &raquo;</a>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                        <h3>Casos de prueba</h3>
                        <hr />
                        <p>
                            En este apartado podra gestionar todo lo relacionado con los casos de prueba del proyecto que se desee trabajar.
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazCasosDePruebas.aspx" class="btn btn-primary">Casos de prueba &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                        <h3>Ejecución de pruebas</h3>
                        <hr />
                        <p>
                            <!-- @todo -->
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazEjecucionPruebas.aspx" class="btn btn-primary">Ejecución de pruebas &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12 hvr-float">
                        <h3>Generación de reportes</h3>
                        <hr />
                        <p>
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/" class="btn btn-primary">Generación de reportes &raquo;</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
