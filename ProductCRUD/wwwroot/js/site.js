

function Cancel() {
    $('#deleteConfirmationModal').modal('hide');
}

function Delete() {
    var ID = $('#HiddenEmployeeId').val();
    $.ajax({
        url: "/Home/Delete/" + ID,
        type: 'POST',
        contentType: 'application/json',
        success: function (result) {
            $('#deleteConfirmationModal').modal('hide');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function ConfirmDelete(EmpID) {
    console.log(EmpID);
    //console.log(ProductName);
    $('#HiddenEmployeeId').val(EmpID);
    $('#deleteConfirmationModal').modal('show');

}