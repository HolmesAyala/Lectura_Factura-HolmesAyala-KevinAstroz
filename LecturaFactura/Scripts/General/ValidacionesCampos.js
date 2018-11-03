

$.validator.addMethod("cVacio", function (value, element) {
    return value.trim() != "";
}, "<p class='RFV_CampoVacio text-danger font-italic mb-0'>Campo vacio</p>");
$.validator.addClassRules("campo_vacio", { cVacio: true });

$.validator.addMethod("pVacio", function (value, element) {
    return value != "";
}, "<p class='RFV_CampoVacio text-danger font-italic mb-0'>Campo vacio</p>");
$.validator.addClassRules("contrasena_vacio", { pVacio: true });

$.validator.addMethod("sNumeros", $.validator.methods.digits, "<p class='RFV_SoloNumeros text-danger font-italic mb-0'>Solo numeros</p>");
$.validator.addClassRules("solo_numeros", { sNumeros: true });

$.validator.addMethod("vEmail", $.validator.methods.email, "<p class='RFV_Correo text-danger font-italic mb-0'>Correo no valido</p>");
$.validator.addClassRules("email_valido", { vEmail: true });

$.validator.addMethod("vCaracteresEspeciales", function (value, element) {
    return /^[\w\s]*$/i.test(value);
}, "<p class='RFV_CaracteresNoValidos text-danger font-italic mb-0'>Caracteres no validos</p>");
$.validator.addClassRules("caracteres_especiales", { vCaracteresEspeciales: true });

//$("form").each(function () {
//    $(this).validate();
//});