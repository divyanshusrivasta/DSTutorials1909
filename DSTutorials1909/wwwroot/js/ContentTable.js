$(document).ready(function () {
    showTable();
});

function showTable() {
    $("#tblcontent").DataTable({
        "ajax": { url: "/Content/GetAll" },
        "columns": [
            { data: 'contentId' },
            { data: 'courses.courseName' },
            { data: 'menu.menuName' },
            { data: 'subMenu.subMenuName' },
            // { data: 'sideSubMenuUrl' }, // Uncomment if needed

            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Content/Details/' + row.contentId + '" class="btn btn-primary"><i class="bi bi-file-earmark-text"></i> Details</a>';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Content/Edit/' + row.contentId + '" class="btn btn-secondary"><i class="bi bi-pencil-square"></i> Edit</a>';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Content/Delete/' + row.contentId + '" class="btn btn-danger"><i class="bi bi-trash3"></i> Delete</a>';
                }
            }
        ]
    });
}
