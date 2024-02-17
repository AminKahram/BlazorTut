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