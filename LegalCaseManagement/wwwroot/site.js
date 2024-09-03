function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

function downloadPdf(dataUrl, fileName) {
    var a = document.createElement('a');
    a.href = dataUrl;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
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

function downloadFileFromStream(fileName, base64String) {
    const link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + base64String;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

export function getCalendarInstance() {
    return calendar;
}
function downloadFile(fileName, base64String) {
    const link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + base64String;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.generatePdf = (cases) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.setFontSize(18);
    doc.text("LawMaster Pro", 105, 15, null, null, "center");
    doc.setFontSize(12);
    doc.text("Chamber No. 600 District Courts, Rohtak - 124001, Haryana, India", 105, 22, null, null, "center");

    doc.setFontSize(14);
    doc.text(`Cases Listed on ${new Date().toLocaleDateString()}`, 14, 35);
    doc.text(`Total Cases : ${cases.length}`, 14, 42);

    const tableColumn = ["Sr No", "Cases", "Petitioner vs Respondent", "Stage of Case", "Next Date"];
    const tableRows = cases.map((caseItem, index) => [
        index + 1,
        caseItem.registrationNo,
        `${caseItem.petitioner} vs ${caseItem.appUser?.firstName} ${caseItem.appUser?.lastName}`,
        caseItem.caseStatus.statusName,
        caseItem.endDate ? new Date(caseItem.endDate).toLocaleDateString() : ''
    ]);

    doc.autoTable({
        head: [tableColumn],
        body: tableRows,
        startY: 50,
        styles: { fontSize: 10, cellPadding: 2 },
        columnStyles: { 0: { cellWidth: 15 }, 1: { cellWidth: 30 } }
    });

    doc.save("cases_list.pdf");
};

window.generatePdf = (cases) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    doc.setFontSize(18);
    doc.text("LCMS", 105, 15, null, null, "center");
    doc.setFontSize(12);
    doc.text("Court", 105, 22, null, null, "center");

    doc.setFontSize(14);
    doc.text(`Cases Listed on ${new Date().toLocaleDateString()}`, 14, 35);
    doc.text(`Total Cases : ${cases.length}`, 14, 42);

    const tableColumn = ["Sr No", "Cases", "Petitioner vs Respondent", "Stage of Case", "Next Date"];
    const tableRows = cases.map((caseItem, index) => [
        index + 1,
        caseItem.registrationNo,
        `${caseItem.petitioner} vs ${caseItem.appUser?.firstName} ${caseItem.appUser?.lastName}`,
        caseItem.caseStatus.statusName,
        caseItem.endDate ? new Date(caseItem.endDate).toLocaleDateString() : ''
    ]);

    doc.autoTable({
        head: [tableColumn],
        body: tableRows,
        startY: 50,
        styles: { fontSize: 10, cellPadding: 2 },
        columnStyles: { 0: { cellWidth: 15 }, 1: { cellWidth: 30 } }
    });

    doc.save("cases_list.pdf");
};

window.downloadreportFile = function (fileName, content) {
    const blob = new Blob([content], { type: 'application/pdf' });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
    window.URL.revokeObjectURL(link.href); // Clean up
}