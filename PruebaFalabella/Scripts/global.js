function SerializarForm($form) {
    var data = {};

    $.each($form.serializeArray(),
        function (index, value) {
            data[value.name] = value.value;
        });

    return data;
}

function EnviarFormularioAjax(selectorForm, callbackFinalizado, callbackFallo) {
    IntercambiarSpinner();

    var $form = $(selectorForm);
    var jqxhr;
    var data = SerializarForm($form);

    jqxhr = $.ajax({
        method: $form.attr("method"),
        url: $form.attr("action"),
        data: data,
        dataType: "json"
    });

    jqxhr.done(function (data, textStatus, jqXHR) {
        callbackFinalizado(data);
    });

    jqxhr.fail(function (jqXHR, textStatus, errorThrown) {
        callbackFallo();
    });

    jqxhr.always(function () {
        IntercambiarSpinner();
    });

    function IntercambiarSpinner() {
        if ($('.spinner:visible').length === 0) {
            $('.spinner').fadeIn(500);
        }
        else {
            $('.spinner').fadeOut(500);
        }
    }

}

function ConstruirNotificacion(exito, texto, selector) {
    var cssClass = exito ? "alert-success" : "alert-danger";

    $(selector).html("");

    $(selector).append('<div class="alert ' + cssClass + ' alert-dismissible fade show" role="alert">' +
        '<span class="alert-inner--text">' + texto + '</span>' +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span></button></div>');
}