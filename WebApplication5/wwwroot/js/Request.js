var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = new DataTable('#myTable', {
        responsive: true,
        "ajax": {
            "url": "/Request/GetAll"
        },
        "columns": [
            { "data": "name" },
            { "data": "email" },
            { "data": "status" },



            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Request/Details?id=${data}" class="btn btn-primary"> Details</a>
                        </div>
                            
                        `
                },
                
            }
        ]
    });
}