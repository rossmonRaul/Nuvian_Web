

const formulario = document.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');

const campos = {
	Identificacion: false,
	Password: false,
	Nombre: false,
	Apellido1: false,
	Apellido2: false,
	Correo: false,
	Telefono: false,
	Fecha: false,
	Aeropuerto: false

}

/*Expresiones regulares de js*/

const expresiones = {

	nombre: /^[a-zA-Z ]{2,254}$/, 
	password: /^([a-zA-Z0-9_-]){1,25}$/, 
	correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
	numeros: /^\d{1,10}$/ 
}


//Validar inputs del formulario

const validarFormulario = (e) => {
	switch (e.target.name) {
		case "identificacion":
			validarDatos(expresiones.numeros, e.target, 'Identificacion');
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
			validarFecha();
			break;


	}
}

/*Activar mensajes de error personalizados para cada input*/
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


/*Validacion de fecha, para que no acepte nulos*/
function validarFecha() {
	const fecha = document.getElementById('fecha').value;

	if (fecha == "") {

		document.querySelector(`#gFecha .mensaje_error`).classList.add('mensaje_error_activo');
		campos["Fecha"] = false;

	} else {
		document.querySelector(`#gFecha .mensaje_error`).classList.remove('mensaje_error_activo');
		campos["Fecha"] = true;
	}
	ActivarBtnGuardar();

}

/*Validacion del aerpuerto, para que no acepte nulos*/
function validarAeropuerto() {
	const aeropuerto = document.getElementById('aeropuerto').value;

	if (aeropuerto == "0") {

		document.querySelector(`#gAeropuerto .mensaje_error`).classList.add('mensaje_error_activo');
		campos["Aeropuerto"] = false;

	} else {
		document.querySelector(`#gAeropuerto .mensaje_error`).classList.remove('mensaje_error_activo');
		campos["Aeropuerto"] = true;
	}
	ActivarBtnGuardar();

}


function ActivarBtnGuardar() {

	if (campos.Identificacion && campos.Password && campos.Nombre && campos.Apellido1 && campos.Apellido2 && campos.Correo && campos.Telefono && campos.Fecha && campos.Aeropuerto) {

		document.getElementById("btnGuardar").disabled = false;

	} else {
		document.getElementById("btnGuardar").disabled = true;
	}
}

/* Consumo del api postUsuarios con ajax desde el controlador user*/

$("#btnGuardar").click(function () {

	const id = document.getElementById('idUSR').value;
	const id2 = document.getElementById('aeropuerto').value;

	if (id == "") {


		var user = {

			"Nombre": $("#nombre").val(),
			"Apellido1": $("#apellido1").val(),
			"Apellido2": $("#apellido2").val(),
			"Cedula": $("#identificacion").val(),
			"ID_Aeropuerto": $("#aeropuerto").val(),
			"Correo": $("#correo").val(),
			"Telefono": $("#telefono").val(),
			"FechaNacimiento": $("#fecha").val(),
			"Contraseña": $("#password").val()
		}
		$.ajax({
			type: "POST",
			url: "/User/NuevoUsuario",
			data: user,
			cache: false,


		}).done(function (res) {
			
			if (res === true) {
				swal.fire({
					title: "Usuario agregado",
					text: "El usuario se guardó de manera exitosa ",
					type: 'success'
				}).then(function () {

					$('#Users_table').DataTable().ajax.reload();

					window.location.href = 'http://localhost:9284/User/BasePage';
				});

				
			} else {
				Swal.fire('Hubo un error al guardar el usuario')
			}
		});



	} else {

	}

});

//Consumo del api deleteUsuarios con ajax

$("#Users_table").on('click', '.btnDelete', function () {


	var Id = $(this).attr("data-Id");

	Swal.fire({
		title: "Eliminar usuario",
		text: '¿Esta seguro que desea eliminar el usuario ' + Id + '?',
		showDenyButton: true,
		confirmButtonColor: '#57BA5B',
		denyButtonColor: '#CF4238',
		confirmButtonText: 'Aceptar',
		denyButtonText: 'Cancelar',
	}).then((result) => {

		if (result.isConfirmed) {

			var user = {
				"ID_USR": Id,
			}
			$.ajax({
				type: "POST",
				url: "/User/EliminarUsuario",
				data: user,
				cache: false
			}).done(function (res) {
				
				if (res == true) {
					Swal.fire('Se eliminó el usuario')

					$('#tablaClientes').DataTable().ajax.reload();

				} else {
					Swal.fire('Hubo un error al eliminar el usuario')
				}
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
			
			$("#aeropuerto").append("<option value="+0+">Seleccione</option>");
			for (const item of data) {
				$('#aeropuerto').get(0).options[$('#aeropuerto').get(0).options.length] = new Option(item.nombre + "-" + item.nombre_OACI, item.iD_Aeropuerto);
            }
        }
	})
})



/*Consumo del api listar usuarios en DataTable*/

$('#Users_table').DataTable({
	ajax: {
		url: '/User/ListarUsuarios',
		dataSrc: ''
	},
	columns: [{ data: 'iD_USR' },
	{ data: 'id' },
	{ data: 'nombre' },
	{ data: 'primer_apellido' },
	{ data: 'segundo_apellido' },
	{ data: 'aeropuerto' },
	{ data: 'correo' },
	{ data: 'fechaIngreso' },
	{
		'data': 'iD_USR', render: function (data, type, row) {
			return '<button " class="btn btn-success btn-sm btnEdit" data-Id=' + row.iD_USR + '><i class="bi bi-pencil-square"></i></button>';

		}
	},
	{
		'data': 'iD_USR', render: function (data, type, row) {
			return '<button class="btn btn-danger btn-sm btnDelete" data-Id=' + row.iD_USR + '><i class="bi bi-trash"></button>';

		}
	}

	]
});

