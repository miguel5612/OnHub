<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="airQ._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="divBody">

        <div class="col-md-6">
            <div id="divBody">
                <h1 id="logoParagraph">Onmotica.com</h1>
                <p>
                    Onmotica es la plataforma web en la cual puedes registrar todos tus dispositivos, 
                    dispositivos como sistemas de supervision y apagado remoto,
                  medidores de temperatura, humedad, corriente, voltaje, potencia, lo que tu quieras,
                  puedes personalizarlo, darle tu estilo y recibir a diario reportes del estado de tus equipos.
                </p>
            </div>
        </div>


        <div class="col-md-6">

            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item active">
                        <img src="Shared/image/Slider/image1.jpg" class="carousel-image">
                    </div>

                    <div class="item">
                        <img src="Shared/image/Slider/image2.jpg" class="carousel-image">
                    </div>

                    <div class="item">
                        <img src="Shared/image/Slider/image3.jpg" class="carousel-image">
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                    <span class="sr-only">Next</span>
                </a>

            </div>

        </div>
    </div>
</asp:Content>
