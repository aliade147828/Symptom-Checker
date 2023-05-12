$(document).ready()
{
    InitializeCalender();
    var dateSelect;
}

function InitializeCalender() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl) {
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',

                selectable: true,
                editable: false,
                select: function (event) {
                    OnShowModal(event, null);
                },
                //dateClick: function (info) {
                //    dateSelect = info.dateStr
                //    console.log(dateSelect)
                //}
            });
        }
        calendar.render();
    } catch (e) {
        console.log(e);
    }
}

function OnShowModal(obj, eventDetail) {
    console.log(obj.startStr)
    document.querySelector(".date__input").value = obj.startStr;

    $(".appointmentModal").modal("show")
}

function OnCloseModal() {
    $(".appointmentModal").modal("hide")

}
//document.addEventListener('DOMContentLoaded', function () {
//    var calendarEl = document.getElementById('calendar');
//    var calendar = new FullCalendar.Calendar(calendarEl, {
//        initialView: 'dayGridMonth'
//    });
//    calendar.render();
//});