$(document).ready(function(){
    var $cep = $('#CEP');
    var $rua = $("#Rua");
    var $bairro = $("#Bairro");
    var $cidade = $("#Cidade");
    var $estado = $("#Estado");

    $cep.blur(function () {
        ConsultarCEP($cep, $rua, $bairro, $cidade, $estado);
    });
});