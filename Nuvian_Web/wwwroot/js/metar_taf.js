
var indicador = false;


$(document).ready(function () {
	cargarcombo();


})

function cargarcombo() {

	$.ajax({
		url: '/User/CargarCombo',
		type: 'GET',
		dataType: 'json',
		success: function (data) {
			$('#slAeropuerto').get(0).options.length = 0;

			$('#slAeropuerto').get(0).options[0] = new Option('---Seleccione---', 0);
			for (const item of data) {
				$('#slAeropuerto').get(0).options[item.iD_Aeropuerto] = new Option(item.nombre + "-" + item.nombre_OACI, item.nombre_OACI);
			}
		}
	})
}


function CargarFrameParam() {

	var aeropuerto = document.getElementById("slAeropuerto").value;

	var clima1 = document.getElementById("clima");


	var ruta = 'https://metar-taf.com/es/embed-js/' + aeropuerto + '?layout=landscape&target=BQSRpk5Y';
	var link = 'https://metar-taf.com/es/' + aeropuerto + '?station_id=MROC';

	if (!indicador) {

		let script = document.createElement('script');

		script.id = "script_widget"
		script.async = true;
		script.defer = true;
		script.crossOrigin = "anonymous"
		script.src = ruta;



		clima.append(script);

		let myHref = document.createElement("a");
		myHref.setAttribute("href", "https://metar-taf.com/es/MRBP?station_id=MROC");
		myHref.setAttribute("id", "metartaf-BQSRpk5Y");
		myHref.setAttribute("style", "font-size:18px; font-weight:500; color:#000; width:350px; height:265px; display:block");
		myHref.textContent = "METAR ";

		clima1.appendChild(myHref);

		script.onload = function () {


		};

		indicador = true;



	} else {


		var enlace = document.getElementById("metartaf-BQSRpk5Y");
		var script1 = document.getElementById("script_widget");
		var eliminar = clima1.removeChild(enlace, script1);

		let script = document.createElement('script');

		script.id = "script_widget"
		script.async = true;
		script.defer = true;
		script.crossOrigin = "anonymous"
		script.src = ruta;



		clima.append(script);

		let myHref = document.createElement("a");
		myHref.setAttribute("href", link);
		myHref.setAttribute("id", "metartaf-BQSRpk5Y");
		myHref.setAttribute("style", "font-size:18px; font-weight:500; color:#000; width:350px; height:265px; display:block");
		myHref.textContent = "METAR ";

		clima1.appendChild(myHref);

		script.onload = function () {


		};

		indicador = true;

	}
}




