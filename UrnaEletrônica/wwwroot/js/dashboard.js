$.ajax({
    url: "https://localhost:44368/api/vote/votes",
    method: "GET",
    contentType: "application/json; charset=UTF-8",
    success: function (result) {
        if (result) {
            result.forEach(item => {
                $("#lista").append(`<li><span class="lideranca">${item.name}</span><small class="votos">${item.totalVotes}</small></li>`)
            }) 
        }
       
    }
})

