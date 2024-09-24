

$(document).ready(function () {
    showTable();
});


function showTable() {
    $("#tblsubmenu").DataTable({
        "ajax": { url: "/SubMenu/GetAll" },
        "columns": [
            { data: 'subMenuId' },
            { data: 'subMenuName' },
            { data: 'courses.courseName' },
            { data: 'menu.menuName' },
            { data: 'subMenuSequence' },

            { data: 'subMenuUrl' },

            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/SubMenu/Edit/' + row.subMenuId + '" class="btn btn-secondary"><i class="bi bi-pencil-square"></i> Edit</a>';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/SubMenu/Delete/' + row.subMenuId + '" class="btn btn-danger"><i class="bi bi-trash3"></i> Delete</a>';
                }
            }
        ]
    });

}