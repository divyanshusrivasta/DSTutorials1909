

$(document).ready(function () {
    showTable();
});


function showTable() {
    $("#tblcourse").DataTable({
        "ajax": { url: "/Course/GetAll" },
        "columns": [
            { data: 'coursesId' },
            { data: 'courseName' },
            { data: 'courseDetails' },
            {
                "data": "courseImage",
                "render": function (data) {
                    return '<img src="' + data + '" style="width:80px;height:80px" class="rounded" />';
                }
            },
            { data: 'courseSequence' },
            
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Course/Edit/' + row.coursesId + '" class="btn btn-secondary"><i class="bi bi-pencil-square"></i> Edit</a>';
                }
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="/Course/Delete/' + row.coursesId + '" class="btn btn-danger"><i class="bi bi-trash3"></i> Delete</a>';
                }
            }
        ]
    });

}