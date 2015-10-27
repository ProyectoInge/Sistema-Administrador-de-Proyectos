<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAPS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-default">
    </div>
    <div class="row titulo-default">
        <div class="col-md-7 col-md-offset-1 col-sm-7 col-sm-offset-1 col-lg-5 col-lg-offset-1">
            <h1>SAPS es su herramienta para administrar proyectos de software.</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1 col-lg-10 col-lg-offset-1">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
                        <h3>Recursos humanos</h3>
                        <hr />
                        <p>
                            Aquí podrá administrar y consultar todos los recursos humanso disponibles en el sistema. 
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazRecursosHumanos.aspx" class="btn btn-primary">Recursos humanos &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
                        <h3>Proyectos de prueba</h3>
                        <hr />
                        <p>
                            En esta sección podrá encontrar información a cerca de todos los proyectos que se encuentran en el sistema. Podrá consultar, modificar y eliminar los proyectos dependiendo de sus permisos. 
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazProyectosDePruebas.aspx" class="btn btn-primary">Proyectos de prueba &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
                        <h3>Diseños de prueba</h3>
                        <hr />
                        <p>
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/" class="btn btn-primary">Diseños de prueba &raquo;</a>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
                        <h3>Casos de prueba</h3>
                        <hr />
                        <p>
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/" class="btn btn-primary">Casos de prueba &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
                        <h3>Ejecución de pruebas</h3>
                        <hr />
                        <p>
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/" class="btn btn-primary">Ejecución de pruebas &raquo;</a>
                    </div>
                    <div class="col-md-4 col-sm-4 col-lg-4 col-xs-12">
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
