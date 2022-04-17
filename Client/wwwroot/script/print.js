window.ShowAlert = (message) => {
    alert(message);
}

window.printPage = () => {
    window.print();
}

function focusElement(id) {
    const element = document.getElementById(id);
    element.focus();
}