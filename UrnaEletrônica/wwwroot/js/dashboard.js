$.ajax({
    url: "https://localhost:44368/api/vote/votes",
    method: "GET",
    contentType: "application/json; charset=UTF-8",
    success: function (result) {
        alert('Successfully received Data ');
        
        document.getElementsByClassName("lideranca").innerHTML = result[0].name
    },
    error: function (xhr, status, error) {
        alert(xhr.responseText);
        document.getElementById("resultado1").value = ''
        document.getElementById("resultado2").value = ''
    }
})

