

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



	var ruta = 'https://metar-taf.com/es/embed/' + aeropuerto + '?bg_color=0057a3&station_id=' + aeropuerto + '&layout=landscape';

	var iframe = document.getElementById("frame1");

	iframe.setAttribute("src", ruta);




}