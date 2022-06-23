//Funcionamiento del popover
$(document).ready(function () {
    $('[data-toggle="popover"]').popover();
});

document.querySelector('#log').addEventListener('click', function () {
    let user = document.getElementById('txtUsuario').value;
    let pass = document.getElementById('txtPassword').value;

    validarLogin(user, pass);

})

function validarLogin(user, pass) {
    if (user != null || pass != null) {
        $.ajax({
            url: '/Home/Login',
            type: 'POST',
            data: { cedula: user, contra: pass },
            success: function (data) {
                console.log(data)
                if (data === 'True') {
                    window.location.href = 'http://localhost:9284/Home/HomeView'
                } else {
                    document.getElementById('errormsg').innerHTML = 'Usuario y/o contraseña incorrecta';
                }
            },
            error: function (data) { }
        });
    }
}