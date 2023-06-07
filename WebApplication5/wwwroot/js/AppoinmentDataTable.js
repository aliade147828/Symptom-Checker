var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = new DataTable('#myTable', {
        responsive: true,
        "ajax": {
            "url": "/Appoinment/GetAll"
        },
        "columns": [
            { "data": "name" },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "doctorName" },
            { "data": "date" },
            { "data": "status" },



            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                            <a href="/Appoinment/Details?id=${data}" class="btn btn-primary"> Details</a>
                        </div>
                            
                        `
                },
                
            }
        ]
    });
}