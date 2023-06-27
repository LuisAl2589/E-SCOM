$(function () {

    $('#correcto').hide();
    $('#incorrecto').hide();

    $('#login').click(function () {
        $.ajax({
            
            method: "POST",
            url: '@Url.Action("ValidarUsuario", "Usuarios")',
            dataType: "json",
            data: {

                _correo: $('#correo').val(),
                _password: $('#password').val()
                // expiresInMins: 60, // optional
            },
            success: function (response) {
                if (response != null) {
                    $('#correcto').show('slow');

                } else {
                    $('#incorrecto').show('slow');
                }
            }

        })
    });


})