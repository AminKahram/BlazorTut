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