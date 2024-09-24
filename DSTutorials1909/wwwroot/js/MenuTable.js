

$(document).ready(function () {
    showTable();
});


function showTable() {
    $("#tblmenu").DataTable({
        "ajax": { url: "/Menu/GetAll" },
        "columns": [
            { data: 'menuId' },
            { data: 'menuName' },
            { data: 'courses.courseName' },
            
            { data: 'menuSequence' },

            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Menu/Edit/' + row.menuId + '" class="btn btn-secondary"><i class="bi bi-pencil-square"></i> Edit</a>';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Menu/Delete/' + row.menuId + '" class="btn btn-danger"><i class="bi bi-trash3"></i> Delete</a>';
                }
            }
        ]
    });

}