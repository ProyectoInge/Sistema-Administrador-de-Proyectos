<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="SAPS.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #5682a3; height: 220px; margin-top: -50px; margin-left: -15px; margin-right: -15px"></div>
    <div style="margin-top: -100px">
        <section id="contacto">
            <div class="row">
                <div id="panel_contacto" class="col-md-10 col-md-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div id="row1" class="form-group">
                                    <div class="col-md-12">
                                        <h2>SAPS<small> Información del sistema</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <div id="row2" class="form-group">
                                    <div class="col-md-5 col-md-offset-1">
                                        <h4>Datos generales</h4>
                                        <hr />
                                        <p>
                                            El Sistema Administrador de Proyectos de Software <b>(SAPS)</b> es una herramienta que facilita la administración y manejo de cualquier sistema de
                                            desarrollo de software. Este sistema fue desarrollado durante el curso de Ingeniería de Software I de la Universidad de Costa Rica, bajo la supervisión
                                            de la profesora Gabriela Salazar Bermúdez y del asistente del curso German Solís Guerrero.
                                        </p>
                                        <p>
                                            El sistema fue desarrollado utilizando la metodología SCRUM que se aprendió en el curso. El código fuente del sistema se puede encontrar en el repositorio
                                            en <a target="_tab" href="https://github.com/ProyectoInge/Sistema-Administrador-de-Proyectos/tree/Sprint-1">GitHub</a>.
                                        </p>
                                    </div>
                                    <div class="col-md-5">
                                        <h4>Desarrolladores</h4>
                                        <hr />
                                        <p>Los desarrolladores del sistema son:</p>
                                        <ul>
                                            <li>Carlos Mata Guzmán <a href="mailto:carlos.mataguzman@gmail.com">(Contactar)</a></li>
                                            <li>Fabián Rodríguez Obando <a href="mailto:farodriguez.49@gmail.com">(Contactar)</a></li>
                                            <li>Jose Pablo Ureña Gutiérrez <a href="mailto:jpurena14@hotmail.com">(Contactar)</a></li>
                                            <li>Kevin Delgado Sandí <a href="mailto:kefdelgado@gmail.com">(Contactar)</a></li>
                                            <li>Stefano Del Vecchio Cedeño <a href="mailto:sdelvecchioc@gmail.com">(Contactar)</a></li>
                                        </ul>
                                        <p>Todos estudiantes de la carrera de Ciencias de la Computación e Informática de la Universidad de Costa Rica.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-10">
                                    <asp:Button runat="server" CssClass="btn btn-link" Text="Regresar" OnClick="btn_regresar_Click" style="color: darkgray"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
