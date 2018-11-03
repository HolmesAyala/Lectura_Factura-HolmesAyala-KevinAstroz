
var FormCargarArchivo = $("#FormCargarArchivo");

FormCargarArchivo.submit(
    function (event) {
        event.preventDefault();
        var selecionoArchivo = 1;

        var campoArchivo = document.getElementById("Archivo");

        var cantidadArchivos = campoArchivo.files.length;

        if (cantidadArchivos == selecionoArchivo) {
            var archivo = campoArchivo.files[0];

            console.log(archivo);

            if (tipoArchivoValido(archivo)) {
                getBase64FromFile(archivo, function (base64) {
                    enviarFactura(base64);
                });
            }
            else {
                mostrarMensaje("Formato de archivo no valido");
            }
        }
    }
);

function tipoArchivoValido(archivo) {
    var tiposValidos = ["image/jpeg"];

    return tiposValidos.includes(archivo.type);
}

function enviarFactura(facturaBase64) {
    var url = "/SubirFactura/cargarFactura";

    var data = { Data: facturaBase64 };

    $.post(url, data).done(
        function (respuesta) {
            if (respuesta.Estado == MENSAJE_CORRECTO) {

            }

            mostrarMensajeRespuestaPost(respuesta);
        }
    ).fail(mostrarErrorRespuestaPost);
}

function getBase64FromFile(img, archivoBase64) {
    let fileReader = new FileReader();

    fileReader.addEventListener('load', function (evt) {
        archivoBase64(fileReader.result);
    });

    fileReader.readAsDataURL(img);
}