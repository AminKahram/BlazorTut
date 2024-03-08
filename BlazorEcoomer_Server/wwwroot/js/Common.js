window.ShowToastr = (type, message, title, timeOut) => { 
    if (type == "success")
    {
        toastr.success(message, title, { timeOut: timeOut });
    }
    if (type == "error")
    {
        toastr.error(message, title, { timeOut: timeOut });
    }
}
window.ShowSwal = (type, message, title, timeOut) => {
    
    Swal.fire({
        icon: type,
        title: title,
        text: message,
        timer: timeOut
    });
    
}
window.ConfirmSwal = (message, resultText) => {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    return swalWithBootstrapButtons.fire({
        title: message,
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete",
        cancelButtonText: "No, cancel",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            swalWithBootstrapButtons.fire({
                title: "Deleted!",
                text: resultText,
                icon: "success"
            });
            return true;
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire({
                title: "Cancelled",
                icon: "error"
            });
            return false;

        }
        return false;

    });
}
