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
window.ConfirmSwal = () => {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });
    return swalWithBootstrapButtons.fire({
        title: "Do you want to delete this product and it's image?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete",
        cancelButtonText: "No, cancel",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            //swalWithBootstrapButtons.fire({
            //    title: "Deleted!",
            //    text: "Your product has been deleted.",
            //    icon: "success"
            //});
            return true;
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            //swalWithBootstrapButtons.fire({
            //    title: "Cancelled",
            //    icon: "error"
            //});
            return false;
        }
        return false;
        //if (type == "product") {
        //    return swalWithBootstrapButtons.fire({
        //        title: "Do you want to delete this product and it's image?",
        //        icon: "warning",
        //        showCancelButton: true,
        //        confirmButtonText: "Yes, delete",
        //        cancelButtonText: "No, cancel",
        //        reverseButtons: true
        //    }).then((result) => {
        //        if (result.isConfirmed) {
        //            swalWithBootstrapButtons.fire({
        //                title: "Deleted!",
        //                text: "Your product has been deleted.",
        //                icon: "success"
        //            });
        //            return true;
        //        } else if (result.dismiss === Swal.DismissReason.cancel) {
        //            swalWithBootstrapButtons.fire({
        //                title: "Cancelled",
        //                icon: "error"
        //            });
        //            return false;
        //        }
        //        return false;
        //    });
        //}
        //if (type == "category") {
        //    return swalWithBootstrapButtons.fire({
        //        title: messageSwal,
        //        icon: "warning",
        //        showCancelButton: true,
        //        confirmButtonText: "Yes, delete",
        //        cancelButtonText: "No, cancel",
        //        reverseButtons: true
        //    }).then((result) => {
        //        if (result.isConfirmed) {
        //            swalWithBootstrapButtons.fire({
        //                title: "Deleted!",
        //                text: resultTextSwal,
        //                icon: "success"
        //            });
        //            return true;
        //        } else if (result.dismiss === Swal.DismissReason.cancel) {
        //            swalWithBootstrapButtons.fire({
        //                title: "Cancelled",
        //                icon: "error"
        //            });
        //            return false;
        //        }
        //        return false;
        //    });
        //}

    })
}