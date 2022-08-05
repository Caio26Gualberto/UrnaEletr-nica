//$(document).ready(function () {
//	// Activate tooltip
//	$('[data-toggle="tooltip"]').tooltip();

//	// Select/Deselect checkboxes
//	var checkbox = $('table tbody input[type="checkbox"]');
//	$("#selectAll").click(function () {
//		if (this.checked) {
//			checkbox.each(function () {
//				this.checked = true;
//			});
//		} else {
//			checkbox.each(function () {
//				this.checked = false;
//			});
//		}
//	});
//	checkbox.click(function () {
//		if (!this.checked) {
//			$("#selectAll").prop("checked", false);
//		}
//	});
//});
var table;
$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44368/api/vote/votes",
        type: "GET",
        datatype: 'json',
        success: function (data) {
          table =  $('#tabela').DataTable({
                data: data,
                columns: [
                    { 'data': 'name' },
                    { 'data': 'viceName' },
                    { 'data': 'subject' }
                ]
            });
        }
    });
});

function confirmar() {
    var name = document.getElementById("name").value;
    var vicename = document.getElementById("vicename").value;
    var subject = parseInt(document.getElementById("subject").value);


    $.ajax({
        url: "https://localhost:44368/api/candidate/candidate",
        type: "POST",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify({
            Name: name,
            ViceName: vicename,
            Subject: subject
        }),
        success: function (data) {
            window.location.reload()
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function deletar() {
  var subject = "https://localhost:44368/api/candidate/candidate/" + (document.getElementById("deletar").value);

    $.ajax({
        url: subject,
        type: "DELETE",
        datatype: 'json',
        success: function (data) {
            window.location.reload();
        }
    });
}
