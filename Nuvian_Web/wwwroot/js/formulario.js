

const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');

const campos = {
	Identificacion: false,
	Password: false,
	Nombre: false,
	Apellido1: false,
	Apellido2: false,
	Correo: false,
	Telefono:false

}


const expresiones = {

	nombre: /^[a-zA-ZñÑáéíóúÁÉÍÓÚ]+$/, 
	password: /^([a-zA-Z0-9_-]){1,25}$/, 
	correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	numeros: /^\d{1,10}$/ 
}


const validarFormulario = (e) => {
	switch (e.target.name) {
		case "identificacion":
			validarDatos(expresiones.numeros,e.target,'Identificacion');
			break;
		case "password":
			validarDatos(expresiones.password, e.target, 'Password');
			break;
		case "nombre":
			validarDatos(expresiones.nombre, e.target, 'Nombre');

			break;
		case "apellido1":
			validarDatos(expresiones.nombre, e.target, 'Apellido1');
			break;
		case "apellido2":
			validarDatos(expresiones.nombre, e.target, 'Apellido2');
			break;
		case "correo":
			validarDatos(expresiones.correo, e.target, 'Correo');
			break;
		case "telefono":
			validarDatos(expresiones.numeros, e.target, 'Telefono');
			break;
		case "fecha":

			break;
	}
}


const validarDatos = (vali,input,campo)=>{

	if (vali.test(input.value)) {
		document.querySelector(`#g${campo} .mensaje_error`).classList.remove('mensaje_error_activo');
		campos[campo] = true;
	} else {
		document.querySelector(`#g${campo} .mensaje_error`).classList.add('mensaje_error_activo');
		campos[campo] = false;
	}
      ActivarBtnGuardar();
}

inputs.forEach((input) =>{
	input.addEventListener('keyup', validarFormulario);
	input.addEventListener('blur', validarFormulario);
});

function ActivarBtnGuardar(){

	if (campos.Identificacion && campos.Password && campos.Nombre && campos.Apellido1 && campos.Apellido2 && campos.Correo && campos.Telefono ) {
		console.log("prueba");
		document.getElementById("btnGuardar").disabled = false;
	} else {
		document.getElementById("btnGuardar").disabled = true;
    }
}

$("#btnGuardar").click(function () {
	
	var user = {
	
		"Nombre": $("#nombre").val(),
		"Apellido1": $("#apellido1").val(),
		"Apellido2": $("#apellido2").val(),
		"Cedula": $("#identificacion").val(),
		"ID_Aeropuerto": '1',
		"Correo": $("#correo").val(),
		"Telefono": $("#telefono").val(),
		"FechaNacimiento": $("#fecha").val(),
		"Contraseña": $("#password").val()
	}
	$.ajax({
		type: "POST",
		url: "/User/NuevoUsuario",
		data: user,
		dataType: "json",
		cache: false,
		success: function (data) {
			alert("Se ingreso");

		},
		error: function (data, textStatus, errorThrown) {
			
		}

	});

});

$("#btnEliminar").click(function () {

	Swal.fire({
		title: "Eliminar usuario",
		text: '¿Esta seguro que desea eliminar el usuario seleccionado?',
		showDenyButton: true,
		confirmButtonColor: '#57BA5B',
		denyButtonColor: '#CF4238',
		confirmButtonText: 'Aceptar',
		denyButtonText: 'Cancelar',
	}).then((result) => {

		if (result.isConfirmed) {

			var user = {
				"ID_USR": '27',
			}
			$.ajax({
				type: "POST",
				url: "/User/EliminarUsuario",
				data: user,
				dataType: "json",
				cache: false

			}).done(function (res) {
				Swal.fire('Se eliminó el usuario')
				
			});

		} else {

		}
	})



});

$(document).ready(function () {
	
	$.ajax({
		url: '/User/CargarCombo',
		type: 'GET',
		dataType: 'json',
		success: function (data) {
			$('#aeropuerto').get(0).options.length = 0;
			

			for (const item of data) {
				$('#aeropuerto').get(0).options[$('#aeropuerto').get(0).options.length] = new Option(item.nombre + "-" + item.nombre_OACI, item.iD_Aeropuerto);
            }
        }
	})
})
