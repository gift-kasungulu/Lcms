function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}
function focusDatePicker(datePickerId) {
    // Focus on the MudDatePicker with the provided ID
    var datePicker = document.getElementById(datePickerId);
    if (datePicker) {
        datePicker.focus();
    }
}

let calendar;

export function renderCalendar(calendarElement, events) {
    calendar = new FullCalendar.Calendar(document.getElementById(calendarElement), {
        events: events,
        // Add other FullCalendar options as needed
    });
    calendar.render();
}

export function getCalendarInstance() {
    return calendar;
}

// wwwroot/js/site.js

window.downloadFile = function (filename, base64Content) {
    // Convert base64 content to blob
    const byteCharacters = atob(base64Content);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/octet-stream' });

    // Create a download link and trigger download
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
};
