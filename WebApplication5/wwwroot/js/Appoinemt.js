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
                    clickEvent(event);
                },

            });
        }
        calendar.render();
    } catch (e) {
        console.log(e);
    }
}
function clickEvent(obj) {
    // Get current timestamp
    var todayTimestamp = new Date().setHours(0, 0, 0, 0);

    // Create timestamp to compare to
    var dateToCompareTimestamp = new Date(obj.startStr).setHours(0, 0, 0, 0);

    // Compare timestamps
    if (dateToCompareTimestamp < todayTimestamp) {
        ErrorAlert("Please do not choose a day that has passed")
    } else if (dateToCompareTimestamp == todayTimestamp) {
        ErrorAlert("You Can Make Appoinment Today")
    } else {
        OnShowModal(obj)
    }
}
function OnShowModal(obj, eventDetail) {
    console.log(obj.startStr)
    document.querySelector(".date__input").value = obj.startStr;

    $(".appoinmentModal").modal("show")
}

function OnCloseModal() {
    $(".appoinmentModal").modal("hide")

}
function ErrorAlert(message) {
    console.log(message)
    swal({
        title: "Oops...!",
        text: message,
        icon: "error",
    });

}