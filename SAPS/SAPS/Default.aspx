﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAPS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-default">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="row">
                    <div class="col-md-8">
                        <h1 class="titulo">SAPS es su herramienta para administrar proyectos de software.</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-8">
                        <asp:Label runat="server" AssociatedControlID=""><span style="color: lightgray; font-size: 20px">¿Tiene alguna duda?  </span>
                        <a runat="server" href="~/" class="btn btn-link btn-lg" style="background-color:transparent; color: #ffffff; border-color:transparent">Contáctenos &raquo;</a></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-6">
                        <h3>Recursos humanos</h3>
                        <hr />
                        <p>
                            Aquí podrá administrar y consultar todos los recursos humanso disponibles en el sistema. 
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazRecursosHumanos.aspx" class="btn btn-primary">Recursos humanos &raquo;</a>
                    </div>
                    <div class="col-md-6">
                        <h3>Proyectos de prueba</h3>
                        <hr />
                        <p>
                            En esta sección podrá encontrar información a cerca de todos los proyectos que se encuentran en el sistema. Podrá consultar, modificar y eliminar los proyectos dependiendo de sus permisos. 
                        </p>
                        <a runat="server" href="~/Codigo_Fuente/Fronteras/InterfazProyectosDePruebas.aspx" class="btn btn-primary">Proyectos de prueba &raquo;</a>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <h3>Diseños de prueba</h3>
                        <hr />
                        <p>
                            Esta sección se incluirá próximamente en el sistema.
                        </p>
                        <a runat="server" href="~/" class="btn btn-primary">Diseños de prueba &raquo;</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
