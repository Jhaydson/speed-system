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


function SaveClient() {
    debugger;

    var Clients_TypePerson = $('#Clients_TypePerson').val();
    var Clients_PhysicalOrLegalName = document.getElementById('Clients_PhysicalOrLegalName').value;
    var Clients_LastNameOrFantasyName = document.getElementById('Clients_LastNameOrFantasyName').value;
    var Clients_Email = document.getElementById('Clients_Email').value;
    var Clients_Genre = document.getElementById('Clients_Genre').value;
    var Clients_CpfOrCnpj = document.getElementById('Clients_CpfOrCnpj').value;
    var Clients_Responsible = document.getElementById('Clients_Responsible').value;
    var Clients_DateBirthOrOpening = document.getElementById('Clients_DateBirthOrOpening').value;
    var Clients_StatusClient = document.getElementById('Clients_StatusClient').value;
    //var Clients_PhotoFile = $document.getElementById('Clients_PhotoFile').value;

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Clients/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    //Gravar 
    var url = "/Clients/Create";

    $.ajax({
        url: url
        , type: "POST"
        , dataType: "json"
        , headers: headersadr
        , data: ({
            Clients_PersonId: 0,
            Clients_TypePerson: Clients_TypePerson,
            Clients_PhysicalOrLegalName: Clients_PhysicalOrLegalName,
            Clients_LastNameOrFantasyName: Clients_LastNameOrFantasyName,
            Clients_Email: Clients_Email,
            Clients_Genre: Clients_Genre,
            Clients_CpfOrCnpj: Clients_CpfOrCnpj,
            Clients_Responsible: Clients_Responsible,
            Clients_DateBirthOrOpening: Clients_DateBirthOrOpening,
            Clients_StatusClient: Clients_StatusClient,
           // Clients_PhotoFile: Clients_PhotoFile,
            __RequestVerificationToken: token
        })
        , sucess: function (data) {
            if (data.ResultClient) {
                debugger;
            }
        }

    }
    );
};
