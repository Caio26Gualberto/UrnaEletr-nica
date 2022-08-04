// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function corrigir() {
    document.getElementById("resultado1").value = ''
    document.getElementById("resultado2").value = ''
}

function numero(valor) {
    if (valor === 0 || valor === 1 || valor === 2 || valor === 3 || valor === 4 || valor === 5 || valor === 6 || valor === 7 || valor === 8 || valor === 9) {
        if (document.getElementById("resultado1").value == "") {
            document.getElementById("resultado1").value = valor
        } else {
            document.getElementById("resultado2").value = valor
            var resultado = parseInt(document.getElementById("resultado1").value + document.getElementById("resultado2").value)
            var url = "https://localhost:44368/api/candidate/candidate/ " + resultado
            $.ajax({
                url: url,
                method: "GET",
                data: JSON.stringify({
                    CandidateId: resultado
                }),
                contentType: "application/json; charset=UTF-8",
                success: function (result) {
                    document.getElementById("presidente").innerHTML = result.name
                    document.getElementById("vice").innerHTML = result.viceName
                },
                error: function (xhr, status, error) {
                    alert("Não foi possível encontrar o candidato");
                    document.getElementById("resultado1").value = ''
                    document.getElementById("resultado2").value = ''
                    document.getElementById("presidente").innerHTML = ''
                    document.getElementById("vice").innerHTML = ''
                }
            })
        }
    }

}

function confirmar() {
    var resultado = parseInt(document.getElementById("resultado1").value + document.getElementById("resultado2").value)
    $.ajax({
        url: "https://localhost:44368/api/vote/vote",
        method: "POST",
        data: JSON.stringify({
            CandidateId: resultado
        }),
        contentType: "application/json; charset=UTF-8",
        success: function (result) {
            alert('Successfully received Data ');
            console.log(result);
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
            document.getElementById("resultado1").value = ''
            document.getElementById("resultado2").value = ''
        }
    })
    

}

