<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="SAPS.Contacto" %>

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
                                        <h2>SAPS<small> Información de contacto</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <div id="row2" class="form-group">
                                    <div class="col-md-12">
                                        <h4>Desarrolladores</h4>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-1 col-md-offset-11">
                                    <a runat="server" href="~/Default.aspx" class="btn btn-default btn-block">Volver</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
