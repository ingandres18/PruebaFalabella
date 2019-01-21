$(document).ready(function () {

    var selectorNotif = ".js-notification";

    Inicializar();

    function Inicializar() {
        $('.js-consulta-cliente').on('change', function (evt) {
            Consultar(evt);
        });
    }

    function Consultar(e) {
        let doc = $("#NoDocumento").val();
        if (!$.isNumeric(doc))
            return;

        $('#idCliente').val(doc);
        EnviarFormularioAjax("#frmConsultaCliente", CallbackExito, CallbackFallo);
    }

    function CallbackExito(data) {
        if (data.Success === false) {
            ConstruirNotificacion(data.ResultType, data.Message, selectorNotif);
        }

        CargarNombres(data.Message);
        $("#frmConsultaCliente").validate();
    }

    function CargarNombres(nombres)
    {
        let soloLect = true;
        if (!nombres) {
            nombres = "||||";
            soloLect = false;
        }

        $("#PrimerNombre").prop("readonly", soloLect);
        $("#SegundoNombre").prop("readonly", soloLect);
        $("#PrimerApellido").prop("readonly", soloLect);
        $("#SegundoApellido").prop("readonly", soloLect);

        let lstNom = nombres.split("|");

        $("#PrimerNombre").val(lstNom[0]);
        $("#SegundoNombre").val(lstNom[1]);
        $("#PrimerApellido").val(lstNom[2]);
        $("#SegundoApellido").val(lstNom[3]);
    }

    function CallbackFallo() {
        ConstruirNotificacion(false,
            'No hemos podido consultar el cliente, por favor, intentalo nuevamente',
            selectorNotif);
    }
});