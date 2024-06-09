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