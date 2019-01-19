$(document).ready(function () {

    var selectorNotif = ".js-notification";

    Inicializar();

    function Inicializar() {
        $('.js-submit').on('click', function (evt) {
            Enviar(evt);
        });
    }

    function Enviar(e) {
        e.preventDefault();
        $("#frmLogin").validate();

        if (!$("#frmLogin").valid()) {
            return;
        }

        EnviarFormularioAjax("#frmLogin", CallbackExito, CallbackFallo);
    }

    function CallbackExito(data) {
        if (data.Success === false) {
            ConstruirNotificacion(data.ResultType, data.Message, selectorNotif);
            return;
        }

        location.replace(data.RedirectUrl);
    }

    function CallbackFallo() {
        ConstruirNotificacion(false,
            'No hemos podido enviar tu solicitud, por favor, intentalo nuevamente',
            selectorNotif);
    }
});