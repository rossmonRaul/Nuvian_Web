
﻿jQuery(document).ready(function ($) {
	$(document).ready(function () {
		$('#slAeropuerto').select2();
	});

});

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
		case "txtIdentificacion":
			validarDatos(expresiones.numeros, e.target, 'Identificacion');
			break;
		case "txtPassword":
			validarDatos(expresiones.password, e.target, 'Password');
			break;
		case "txtNombre":
			validarDatos(expresiones.nombre, e.target, 'Nombre');

			break;
		case "txtApellido1":
			validarDatos(expresiones.nombre, e.target, 'Apellido1');
			break;
		case "txtApellido2":
			validarDatos(expresiones.nombre, e.target, 'Apellido2');
			break;
		case "txtCorreo":
			validarDatos(expresiones.correo, e.target, 'Correo');
			break;
		case "txtTelefono":
			validarDatos(expresiones.numeros, e.target, 'Telefono');
			break;
		case "txtFecha_nacimiento":
			validarFecha();
			break;


	}

}

/*Activar mensajes de error personalizados para cada input*/
const validarDatos = (vali, input, campo) => {

    if (vali.test(input.value)) {
        document.querySelector(`#g${campo} .mensaje_error`).classList.remove('mensaje_error_activo');
        campos[campo] = true;
    } else {
        document.querySelector(`#g${campo} .mensaje_error`).classList.add('mensaje_error_activo');
        campos[campo] = false;
    }
    ActivarBtnGuardar();
}

inputs.forEach((input) => {
    input.addEventListener('keyup', validarFormulario);
    input.addEventListener('blur', validarFormulario);
});


/*Validacion de fecha, para que no acepte nulos*/
function validarFecha() {

	const fecha = document.getElementById('txtFecha_nacimiento').value;


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

	const aeropuerto = document.getElementById('slAeropuerto').value;


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


	const id = document.getElementById('txtId_usr').value;
	

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

			"Nombre": $("#txtNombre").val(),
			"Apellido1": $("#txtApellido1").val(),
			"Apellido2": $("#txtApellido2").val(),
			"Cedula": $("#txtIdentificacion").val(),
			"Id_aeropuerto": $("#slAeropuerto").val(),
			"Correo": $("#txtCorreo").val(),
			"Telefono": $("#txtTelefono").val(),
			"Fecha_nacimiento": $("#txtFecha_nacimiento").val(),
			"Contraseña": $("#txtPassword").val()
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
		EditarUsuario();
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

			var user = {
				"Id_usr": Id,
			}
			$.ajax({
				type: "POST",
				url: "/User/EliminarUsuario",
				data: user,
				cache: false
			}).done(function (res) {
				
				if (res == true) {
					Swal.fire('Se eliminó el usuario')

					$('#Users_table').DataTable().ajax.reload();


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
				$('#slAeropuerto').get(0).options[item.iD_Aeropuerto] = new Option(item.nombre + "-" + item.nombre_OACI, item.iD_Aeropuerto);
			}
		}
	})


}

/*Consumo del api listar usuarios en DataTable*/

$('#Users_table').DataTable({

	ajax: {
		url: '/User/ListarUsuarios',
		dataSrc: ''
	},
	columns: [{ data: 'id_usr' },
	{ data: 'cedula' },
	{ data: 'nombre' },
	{ data: 'primer_apellido' },
	{ data: 'segundo_apellido' },
	{ data: 'aeropuerto' },
	{ data: 'correo' },
	{ data: 'fecha_ingreso' },
	{
		'data': 'id_usr', render: function (data, type, row) {
			return '<button " class="btn btn-success btn-sm btnEdit" data-Id=' + row.id_usr + '><i class="bi bi-pencil-square"></i></button>';

		}
	},
	{
		'data': 'id_usr', render: function (data, type, row) {
			return '<button class="btn btn-danger btn-sm btnDelete" data-Id=' + row.id_usr + '><i class="bi bi-trash"></button>';

		}
	}

	]
});

$("#Users_table").on('click', '.btnEdit', function () {
	var Id = $(this).attr("data-Id");
	$.ajax({
		url: '/User/BuscarUsarioID',
		type: 'GET',
		dataType: 'json',
		data: { id: Id },
		success: function (data) {
			let fechaNacimiento;
			let fechaFinal;
			for (const item of data) {
				fechaNacimiento = new Date(item.fecha_nacimiento);
				fechaFinal = fechaNacimiento.toISOString().split('T')[0];
				document.getElementById('txtId_usr').value = item.id_usr;
				document.getElementById('txtIdentificacion').value = item.identificacion;
				document.getElementById('txtPassword').value = item.contrasena;
				document.getElementById('txtNombre').value = item.nombre;
				document.getElementById('txtApellido1').value = item.primer_apellido;
				document.getElementById('txtApellido2').value = item.segundo_apellido;
				document.getElementById('txtCorreo').value = item.correo;
				document.getElementById('txtTelefono').value = item.telefono;
				document.getElementById('txtFecha_nacimiento').value = fechaFinal;
				var select = document.getElementById("slAeropuerto");

				// recorremos todos los valores del select
				for (var i = 1; i < select.length; i++) {
					if (select.options[i].value == item.id_aeropuerto) {
						// seleccionamos el valor que coincide
						select.selectedIndex = i;
						var txt = select.options[select.selectedIndex].text;
						$('#slAeropuerto').get(0).options[0] = new Option(txt, "");
						select.options[0].style.display = "none";
					}
				}

				campos['Identificacion'] = true;
				campos['Password'] = true;
				campos['Nombre'] = true;
				campos['Apellido1'] = true;
				campos['Apellido2'] = true;
				campos['Correo'] = true;
				campos['Telefono'] = true;
				campos['Fecha'] = true;
				campos['Aeropuerto'] = true;

				document.getElementById("btnGuardar").disabled = false;
			}
		}
	})
})

function EditarUsuario() {

	const actualizar = {
		ID_USR: document.getElementById('txtId_usr').value,
		Contrasena: document.getElementById('txtPassword').value,
		Nombre: document.getElementById('txtNombre').value,
		Apellido1: document.getElementById('txtApellido1').value,
		Apellido2: document.getElementById('txtApellido2').value,
		Cedula: document.getElementById('txtIdentificacion').value,
		ID_Aeropuerto: document.getElementById("slAeropuerto").value,
		Correo: document.getElementById('txtCorreo').value,
		Telefono: document.getElementById('txtTelefono').value,
		FechaNacimiento: document.getElementById('txtFecha_nacimiento').value
	}
	$.ajax({
		url: '/User/EditarUsuario',
		type: 'POST',
		dataType: 'json',
		data: { actualizar },
		success: function (data) {
			if (data == true) {
				Swal.fire({
					title: "Usuario editado con éxito",
					text: 'El usuario ' + actualizar.Nombre + ' ' + actualizar.Apellido1 + ' ' + actualizar.Apellido2 + ' se ha actualizado correctamente',
					icon: 'success',
					timer: 5000
				})
				$('#Users_table').DataTable().ajax.reload();
				document.getElementById('txtId_usr').value = '';
				document.getElementById('txtPassword').value = '';
				document.getElementById('txtNombre').value = '';
				document.getElementById('txtApellido1').value = '';
				document.getElementById('txtApellido2').value = '';
				document.getElementById('txtIdentificacion').value = '';
				document.getElementById('txtCorreo').value = '';
				document.getElementById('txtTelefono').value = '';
				document.getElementById('txtFecha_nacimiento').value = '';
				cargarcombo();

			} else {
				Swal.fire({
					title: "Ha ocurrido un error",
					text: 'El usuario ' + actualizar.Nombre + ' ' + actualizar.Apellido1 + ' ' + actualizar.Apellido2 + ' no se ha podido actualizar, revise que los datos estén correctos.',
					icon: 'error',
					timer: 5000
				})
			}
		}
	})
}



