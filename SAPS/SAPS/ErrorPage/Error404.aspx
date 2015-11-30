<%@ Page Title="Página no encontrada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="SAPS.ErrorPage.Error404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-celeste"></div>
    <div style="margin-top: -100px">
        <section id="login">
            <div class="row">
                <div id="panel_login" class="col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div id="row1" class="form-group">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <h2>Error 404<small> página no encontrada</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <div id="row2" class="form-group">
                                    <div class="col-md-4 col-md-offset-3">
                                        <img src="http://download-telegram.ru/wp-content/uploads/2015/06/animals-7.png" class="img-rounded" alt="imagen error" width="170" height="200">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-10 col-md-offset-1">
                                        <p>La página que estas buscando no existe, puede que la dirección que escribiste en el navegador esté incorrecta.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="col-md-12">
                            <button class="btn btn-warning btn-block" type="button">Volver al inicio</button>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
