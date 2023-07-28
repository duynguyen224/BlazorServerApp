function showAlert(show, bootstrapType, alertText) {
    const $alert = $("#bootstrap-alert");
    if (show == true) {
        $alert.removeClass("d-none");
        $alert.addClass(`alert-${bootstrapType}`);
        $alert.html(alertText);

        setTimeout(() => {
            $alert.addClass("d-none");
        }, 3000)
    } else {
        $alert.removeClass("d-none");
    }
}