


var FormCargarArchivo = $("#FormCargarArchivo");

FormCargarArchivo.submit(
    function (event) {
        event.preventDefault();
        var selecionoArchivo = 1;

        var campoArchivo = document.getElementById("Archivo");

        var cantidadArchivos = campoArchivo.files.length;

        if (cantidadArchivos == selecionoArchivo) {
            var archivo = campoArchivo.files[0];

            /* Seria usada de la siguiente manera */
            getBase64FromFile(archivo, function (base64) {
                console.log(base64);
            });

            var form_data = new FormData();
            form_data.append("Data", archivo);

            console.log(archivo);

            var url = "/SubirFactura/cargarFactura";

            //$.post(url, form_data).done(
            //    function (respuesta) {
            //        console.log(respuesta);
            //    }
            //).fail(mostrarErrorRespuestaPost);
        }
    }
);

function getBase64FromFile(img, archivoBase64) {
    let fileReader = new FileReader();

    fileReader.addEventListener('load' , function (evt) {
        archivoBase64(fileReader.result);
    });

    fileReader.readAsDataURL(img);
}
