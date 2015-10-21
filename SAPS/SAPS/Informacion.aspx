<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="SAPS.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #5682a3; height: 220px; margin-top: -50px; margin-left: -15px; margin-right: -15px"></div>
    <div style="margin-top: -100px">
        <section id="informacion">
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
                                    <div class="col-md-10 col-md-offset-1">
                                        <h4>Datos generales</h4>
                                        <hr />
                                        <p>
                                            El Sistema Administrador de Proyectos de Software <b>(SAPS)</b> es una herramienta que facilita la administración y manejo de cualquier sistema de
                                            desarrollo de software. Este sistema fue desarrollado durante el curso de Ingeniería de Software I de la Universidad de Costa Rica, bajo la supervisión
                                            de la profesora Gabriela Salazar Bermúdez y del asistente del curso German Solís Guerrero.
                                        </p>
                                        <p>
                                            El sistema fue desarrollado utilizando la metodología SCRUM que se aprendió en el curso. El código fuente del sistema se puede encontrar en el repositorio
                                            en <a target="_tab" href="https://github.com/ProyectoInge/Sistema-Administrador-de-Proyectos/tree/Sprint-1">GitHub</a>. La documentación técnica completa del proyecto 
                                            se puede encontrar <a target="_tab" href="http://ufkk5befb5e9.fabo49.koding.io/Documentacion/">aquí</a>.
                                        </p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-7 col-md-offset-1">
                                        <h4>Desarrolladores</h4>
                                        <hr />
                                    </div>
                                </div>
                                <div id="row1_tarjetas" class="form-group">
                                    <div class="col-md-4 col-md-offset-2">
                                        <div id="tarjeta_fabo" class="card-container">
                                            <div class="card">
                                                <div class="front">
                                                    <div class="cover">
                                                        <img src="https://scontent-mia1-1.xx.fbcdn.net/hphotos-xaf1/v/t1.0-9/483296_10200477316389513_1363899498_n.jpg?oh=02d9dd9a7d6ffddc754ec7e9354da6bb&oe=5685E15E" />
                                                    </div>
                                                    <div class="user">
                                                        <img class="img-circle" src="https://avatars1.githubusercontent.com/u/9465441?v=3&s=460" />
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h3 class="name">Fabian Rodriguez</h3>
                                                            <p class="profession">Software and Web developer</p>
                                                            <h5><i class="fa fa-map-marker fa-fw text-muted"></i>Heredia, Costa Rica</h5>
                                                            <h5><i class="fa fa-building-o fa-fw text-muted"></i>Universidad de Costa Rica </h5>
                                                            <h5><i class="fa fa-envelope-o fa-fw text-muted"></i>farodriguez.49@gmail.com</h5>
                                                        </div>
                                                        <div class="footer">
                                                            <div class="rating">
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="back">
                                                    <div class="header">
                                                        <h5 class="motto">"Focus on a direction rather than on the destination."</h5>
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h4 class="text-center">Experiencia</h4>
                                                            <p>Llenar con la experiencia laboral que se tenga.</p>
                                                            <h4 class="text-center">Areas de experiencia</h4>
                                                            <p>Poner cosas como: "Conocimiento en Java, C++, C#, HTML, CSS..."</p>
                                                        </div>
                                                    </div>
                                                    <div class="footer">
                                                        <div class="social-links text-center">
                                                            <a target="_tab" href="https://www.facebook.com/farodrioba" class="facebook"><i class="fa fa-facebook fa-fw"></i></a>
                                                            <a target="_tab" href="https://github.com/fabo49" class="github"><i class="fa fa-github fa-fw"></i></a>
                                                            <a target="_tab" href="mailto:farodriguez.49@gmail.com" class="envelope"><i class="fa fa-envelope fa-fw"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div id="tarjeta_stefano" class="card-container">
                                            <div class="card">
                                                <div class="front">
                                                    <div class="cover">
                                                        <img src="https://scontent-mia1-1.xx.fbcdn.net/hphotos-xlp1/v/t1.0-9/11951241_10153639817684759_8448683767459679985_n.jpg?oh=49f85ed94431c247b10eed67b55146df&oe=56BC3ED6" />
                                                    </div>
                                                    <div class="user">
                                                        <img class="img-circle" src="https://scontent-mia1-1.xx.fbcdn.net/hphotos-xfa1/v/t1.0-9/11034208_10153225150924759_5254209157804870948_n.jpg?oh=f64aaac9ccccf35e12b091d02b032aca&oe=56C13C57" />
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h3 class="name">Stefano Del Vecchio</h3>
                                                            <p class="profession">Monigote</p>
                                                            <h5><i class="fa fa-map-marker fa-fw text-muted"></i>San José, Costa Rica</h5>
                                                            <h5><i class="fa fa-building-o fa-fw text-muted"></i>Universidad de Costa Rica </h5>
                                                            <h5><i class="fa fa-envelope-o fa-fw text-muted"></i>sdelvecchioc@gmail.com</h5>
                                                        </div>
                                                        <div class="footer">
                                                            <div class="rating">
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="back">
                                                    <div class="header">
                                                        <h5 class="motto">"Me gusta comer mocos."</h5>
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h4 class="text-center">Experiencia</h4>
                                                            <p>Llenar con la experiencia laboral que se tenga.</p>
                                                            <h4 class="text-center">Areas de experiencia</h4>
                                                            <p>Poner cosas como: "Conocimiento en Java, C++, C#, HTML, CSS..."</p>
                                                        </div>
                                                    </div>
                                                    <div class="footer">
                                                        <div class="social-links text-center">
                                                            <a target="_tab" href="https://www.facebook.com/SDelVecchioC" class="facebook"><i class="fa fa-facebook fa-fw"></i></a>
                                                            <a target="_tab" href="https://github.com/SDelVecchioC" class="github"><i class="fa fa-github fa-fw"></i></a>
                                                            <a target="_tab" href="mailto:sdelvecchioc@gmail.com" class="envelope"><i class="fa fa-envelope fa-fw"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="row2_tarjetas" class="form-group">
                                    <div class="col-md-4 col-md-offset-2">
                                        <div id="tarjeta_kevin" class="card-container">
                                            <div class="card">
                                                <div class="front">
                                                    <div class="cover">
                                                        <img src="https://scontent-mia1-1.xx.fbcdn.net/hphotos-xfp1/v/t1.0-9/10463017_873247436038595_7130496896087249442_n.jpg?oh=2b44824e5d66ba5230d41454dd301a8d&oe=56CB3F48" />
                                                    </div>
                                                    <div class="user">
                                                        <img class="img-circle" src="https://avatars2.githubusercontent.com/u/8368584?v=3&s=460" />
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h3 class="name">Kevin Delgado</h3>
                                                            <p class="profession">Wako</p>
                                                            <h5><i class="fa fa-map-marker fa-fw text-muted"></i>San José, Costa Rica</h5>
                                                            <h5><i class="fa fa-building-o fa-fw text-muted"></i>Universidad de Costa Rica </h5>
                                                            <h5><i class="fa fa-envelope-o fa-fw text-muted"></i>kefdelgado@gmail.com</h5>
                                                        </div>
                                                        <div class="footer">
                                                            <div class="rating">
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                                <i class="fa fa-star"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="back">
                                                    <div class="header">
                                                        <h5 class="motto">"¡Chunga!"</h5>
                                                    </div>
                                                    <div class="content">
                                                        <div class="main">
                                                            <h4 class="text-center">Experiencia</h4>
                                                            <p>Llenar con la experiencia laboral que se tenga.</p>
                                                            <h4 class="text-center">Areas de experiencia</h4>
                                                            <p>Poner cosas como: "Conocimiento en Java, C++, C#, HTML, CSS..."</p>
                                                        </div>
                                                    </div>
                                                    <div class="footer">
                                                        <div class="social-links text-center">
                                                            <a target="_tab" href="https://www.facebook.com/KefDelgado" class="facebook"><i class="fa fa-facebook fa-fw"></i></a>
                                                            <a target="_tab" href="https://github.com/KefDS" class="github"><i class="fa fa-github fa-fw"></i></a>
                                                            <a target="_tab" href="mailto:kefdelgado@gmail.com" class="envelope"><i class="fa fa-envelope fa-fw"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-md-offset-10">
                                    <asp:Button runat="server" CssClass="btn btn-link" Text="Regresar" OnClick="btn_regresar_Click" Style="color: darkgrey" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
