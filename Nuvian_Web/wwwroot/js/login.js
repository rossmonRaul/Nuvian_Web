////Validaciones login
$(document).ready(function () {
    document.getElementById('txtUsuario').innerHTML = '';
    document.getElementById('txtPassword').innerHTML = '';
})
function validarDATA() {
    let user = document.getElementById('txtUsuario').value;
    let password = document.getElementById('txtPassword').value;
    document.getElementById('errormsg').innerHTML = '';
    if (user === '') {
        document.getElementById('log').disabled = true;
    }

    if (password === '') {
        document.getElementById('log').disabled = true;
    }
    if(password!='' && user !=''){
        document.getElementById('log').disabled = false;
    }
}

//Funcionamiento del popover
$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});

document.querySelector('#log').addEventListener('click', function () {
    let user = document.getElementById('txtUsuario').value;
    let password = document.getElementById('txtPassword').value;
    //se envian los datos a la funcion para realizar la comunicacion con el controller
    validarLogin(user, password);

})

function validarLogin(user, password) {
    $.ajax({
        url: '/Home/Login',
        type: 'POST',
        data: { cedula: user, contrasena: password },//Se indican el o los parametros que el metodo en el controller recibe
        success: function (data) {
            if (data === 'True') {
                window.location.href = 'http://localhost:9284/Home/HomeView'
            } else {
                document.getElementById('errormsg').innerHTML = 'Usuario y/o contraseña incorrecta';
            }
        },
        error: function (data) { }
    });
}