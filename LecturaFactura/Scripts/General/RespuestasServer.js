
function mostrarMensaje(m) {
    var mensaje = $('<div/>');

    if (m.Estado == MENSAJE_CORRECTO) {
        mensaje.addClass("alert alert-success").removeClass("alert-danger");
    }
    else if (m.Estado == MENSAJE_ALERTA) {
        mensaje.addClass("alert alert-danger").removeClass("alert-success");
    }

    console.log(m.Mensaje);

    mensaje.text(m.Mensaje);

    $("#mensajes").append(mensaje);
}

function mostrarMensajeRespuestaPost(respuesta) {
    var mensaje = $('<div/>');

    if (respuesta.Estado == MENSAJE_CORRECTO) {
        mensaje.addClass("alert alert-success").removeClass("alert-danger");
    }
    else if (respuesta.Estado == MENSAJE_ALERTA) {
        mensaje.addClass("alert alert-danger").removeClass("alert-success");
    }

    console.log(respuesta.Mensaje);

    mensaje.text(respuesta.Mensaje);

    $("#mensajes").append(mensaje);
}

function mostrarErrorRespuestaPost(error) {
    console.log("Error devuelto post...");
    console.log(error.responseText);
}

function mostrarMensajeRespuestaActionLink(respuesta) {
    var mensaje = $('<div/>');

    if (respuesta.responseJSON.Estado == MENSAJE_CORRECTO) {
        mensaje.addClass("alert alert-success").removeClass("alert-danger");
    }
    else if (respuesta.responseJSON.Estado == MENSAJE_ALERTA) {
        mensaje.addClass("alert alert-danger").removeClass("alert-success");
    }

    console.log(respuesta.responseJSON.Mensaje);

    mensaje.text(respuesta.responseJSON.Mensaje);

    $("#mensajes").append(mensaje);
}