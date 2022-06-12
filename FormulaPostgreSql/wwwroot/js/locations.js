var dataTable;

function DeleteFUNK(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "/LocationInfo/GetAll",
        },
        "columns": [
            { "data": "locationname" },
            { "data": "country.countryname"},
            {
                "data": "id", "render": function (data) {
                    return `
                        <div class="w-75 btn-group">
                            <a href="/LocationInfo/Upsert?id=${data}" class="btn btn-warning mx-2"><i class="bi bi-pencil"> </i> Edit</a>
                            <a onclick=DeleteFUNK('/LocationInfo/Delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash"> </i> Delete</a>
                        </div>
                    `
                }, "width": "15%" 
            },
        ]
    });
}

