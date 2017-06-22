$(document).ready(function () {
    $("#IdRA").mask("0000000");
    $("#IdDataNasc").mask("00/00/0000", { placeholder: "__/__/____" });
    $("#IdCEP").mask("00000-000", { placeholder: "_____-___" });
    $("#IdTelefone").mask("(00) 00000-0000", { placeholder: "(__) _____-____" });

    $("#IdCEP").blur(function () {
        preencheEndereco();
    });
});



$("#IdEnviar").click(function () {
    //$.toaster({ priority: 'danger', title: '❌', message: 'TESTE' });
    //success warning danger ✅

    var user = {
        RA: $("#IdRA").val(),
        Nome: $("#IdNome").val(),
        Email: $("#IdEmail").val(),
        DataNasc: $("#IdDataNasc").val(),
        Telefone: $("#IdTelefone").val(),
        Curso: $("#IdCurso").val(),
        Semestre: $("#IdSemestre").val(),
        CEP: $("#IdCEP").val(),
        Endereco: $("#IdEndereco").val(),
        Cidade: $("#IdCidade").val(),
        Estado: $("#IdEstado").val(),
        Sexo: $("input[name=Sexo]:checked").val(),
        Interno: $("#IdInterno").val(),
    }

    $.ajax({
        URL: "/Home/Cadastro",
        dataType: "json",
        type: "post",
        data: { dados: user },
        success: function (data) {
            $.toaster({ priority: 'success', title: '✅', message: 'Cadastro realizado com sucesso!\nVocê será redirecionado em instantes...' });
            setTimeout(function () {
                window.location.href = "/Home/Index";
            }, 2000);
        },
        error: function (error) {
            $.toaster({ priority: 'danger', title: '❌', message: error.statusText });
        }
    });

});

var preencheEndereco = function () {
    var cep = $("#IdCEP").val().replace(/\D/g, '');

    if (cep != "") {
        $('#IdEndereco').val("Aguarde...");
        $('#IdCidade').val("Aguarde...");
        $('#IdEstado').val("...");

        $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
            if (!("erro" in dados)) {
                $("#IdEndereco").val(dados.logradouro + ". Bairro: " + dados.bairro);
                $("#IdCidade").val(dados.localidade);
                $("#IdEstado").val(dados.uf);
                $("#IdEnviar").focus();
            } 
            else {
                limpaEndereco();
                $.toaster({ priority: 'warning', title: '❌', message: 'CEP não encontrado! Favor preencher.' });
            }
        });
    } 
    else {
        limpaEndereco();
        $.toaster({ priority: 'warning', title: '❌', message: 'CEP não informado!' });
    }
};

var limpaEndereco = function()
{
    $("#IdEndereco").val("");
    $("#IdCidade").val("");
    $("#IdEsdado").val("0");
}