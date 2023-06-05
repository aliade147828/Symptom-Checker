var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = new DataTable('#myTable', {
        responsive: true,
        "ajax": {
            "url": "/Department/GetAll"
        },
        "columns": [
            { "data": "name" },
            {
                "data": "dno",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Department/Details?id=${data}" class="btn btn-primary"> Details</a>
                            <a href="/Department/Edit?id=${data}" class="btn btn-primary"> Edit</a>
                            <a href="/Department/Delete?id=${data}" class="btn btn-primary"> Delete</a>
                        
                        </div>
                            
                        `
                },
                "width" : "50%"
            }
        ]
    });
}