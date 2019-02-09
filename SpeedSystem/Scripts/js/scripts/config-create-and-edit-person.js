

$(document).ready(function () {

    $('#Telephones_Number').mask('(99) 99999-9999');



    $("#Clients_TypePerson").change(function () {
        //Variavel que recebe valor do select
        var select = document.getElementById('Clients_TypePerson').value;

        if (select == 1) {
            //TypePerson Selecionado.
            $('#lb-tp').addClass('hide');
            $('#lb-tps').removeClass('hide');

            $('#namelegalp').text("Nome");
            $('#LastName').text("Sobre Nome");
            $('#cpfcnpj').text("Cpf");
            $('#rgeinscricao').text("RG");
            $('#DateNacs').text("Data de Nascimento");

            //Sexo
            $('#Genre').removeClass('hide');
            $('#lb-genre').removeClass('hide');

            //CPF
            $('#bc-cnpj').removeClass('hide');
            $('#Clients_CpfOrCnpj').mask('999.999.999-99');

            //RG
            $('#bc-inscricao').addClass('hide');
            $('#bc-rg').removeClass('hide');

            //Responsável
            $('#bc-resp').addClass('hide');

        } else if (select == 2) {
            //TypePerson Selecionado.
            $('#lb-tp').addClass('hide');
            $('#lb-tps').removeClass('hide');

            $('#namelegalp').text("Razão Social");
            $('#LastName').text("Nome Fantasia");
            $('#cpfcnpj').text("Cnpj");
            $('#rgeinscricao').text("Inscrição Estadual");
            $('#DateNacs').text("Data de Abertura");

            //Sexo
            $('#Genre').addClass('hide');

            //CNPJ
            $('#bc-cnpj').removeClass('hide');
            $('#Clients_CpfOrCnpj').mask('99.999.999/9999-99');

            //Inscrição
            $('#bc-rg').removeClass('hide');

            //Responsável
            $('#bc-resp').removeClass('hide');

        }

    });
});

// Adicionando campos ao telefone
function addTel() {
    $('#contactp').removeClass('hide');

}