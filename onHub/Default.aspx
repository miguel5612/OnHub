<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="airQ._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	

    <style>
        #myCarousel
        {
            width:90rem;
        }
        .carousel-image
        {
            width:100%;
            height:1200px;
        }
    </style>


    <div class="container" id="divBody">
  
        <div class="col-md-4" >
  <div id="divBody">
    <h1 id="logoParagraph">Onmotica.com</h1>
    <p>Onmotica es la plataforma web en la cual puedes registrar todos tus dispositivos, 
    dispositivos como sistemas de supervision y apagado remoto, estaciones metereologicas,
  medidores de temperatura, humedad, corriente, voltaje, potencia, lo que tu quieras,
  puedes personalizarlo, darle tu estilo y recibir a diario reportes del estado de tus equipos.</p>
  </div>
</div>


<div class="col-md-8">



        
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


<%--	<link href="Content/Default.css" rel="stylesheet" />

	<header>

  <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
	<ol class="carousel-indicators">
	  <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
	  <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
	  <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
	</ol>
	<div class="carousel-inner" role="listbox">
	  <!-- Slide One - Set the background image for this slide in the line below -->
	  <div class="carousel-item active" style="background-image: url('/Static/Images/SSAR3D.jpg'">
		<div class="carousel-caption d-none d-md-block">
		  <h2 class="display-4">Sistema de supervision y apagado remoto para equipos de impresion 3D</h2>
		  <p class="lead">Si deseas poder apagar remotamente tus impresoras y conocer la temperatura a la cual estan imprimiendo te invitamos a seguir este enlace <a href="#">Articulo</a>.</p>
		</div>
	  </div>
	  <!-- Slide Two - Set the background image for this slide in the line below -->
	  <div class="carousel-item" style="background-image: url('/Static/Images/powerMeter.jpg')">
		<div class="carousel-caption d-none d-md-block">
		  <h2 class="display-4">Monitores de linea Mono-Bi-TriFasico</h2>
		  <p class="lead">Monitorea el consumo electrico de tu hogar.</p>
		</div>
	  </div>
	  <!-- Slide Three - Set the background image for this slide in the line below -->
	  <div class="carousel-item" style="background-image: url('/Static/Images/airQ.jpg')">
		<div class="carousel-caption d-none d-md-block">
		  <h2 class="display-4">Estaciones metereologicas</h2>
		  <p class="lead">AirQ V1.00.</p>
		</div>
	  </div>
	</div>
	<a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
		  <span class="carousel-control-prev-icon" aria-hidden="true"></span>
		  <span class="sr-only">Previous</span>
		</a>
	<a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
		  <span class="carousel-control-next-icon" aria-hidden="true"></span>
		  <span class="sr-only">Next</span>
		</a>
  </div>
</header>

<!-- Page Content -->
<section class="py-5">
  <div class="container">
	<h1 class="display-4">Full Page Image Slider</h1>
	<p class="lead">The background images for the slider are set directly in the HTML using inline CSS. The images in this snippet are from <a href="https://unsplash.com">Unsplash</a>, taken by <a href="https://unsplash.com/@joannakosinska">Joanna Kosinska</a>!</p>
  </div>
</section>--%>
 </asp:Content>
