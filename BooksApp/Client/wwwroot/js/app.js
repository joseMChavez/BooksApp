function DataTablesAdd(tabla) {
    $(document).ready(function () {
        $(tabla).DataTable();
    });
}
function DataTablesRemove(table) {
    $(document).ready(function () {
        $(table).DataTable().destroy();
        // Removes the datatable wrapper from the dom.
        var elem = document.querySelector(table + '_wrapper');
        elem.parentNode.removeChild(elem);
    });
}

function Refresh() {
    location.reload();
}
function ShowMessageToast(icono, mensaje) {
    return new Promise(() => {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        Toast.fire({
            icon: icono,
            title: mensaje
        });
    });
}

function ShowMessageConfirmation(mensaje) {
    return new Promise((resolve) => {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: "AnkuraSoft",
            text: mensaje,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Si, Estoy Seguro',
            cancelButtonText: 'No, cancelar!',
            reverseButtons: false


        }).then((result) => {
            resolve(result);
            if (result.isConfirmed) {
                swalWithBootstrapButtons.fire(
                    'AnkuraSoft',
                    'Proceso Completado!',
                    'success'
                )
            } else if (
                /* Read more about handling dismissals below */
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'AnkuraSoft',
                    'Proceso Cancelado!',
                    'info'
                )
            }
        })
    })
}


function ShowMessage(icono, mensaje) {
    return new Promise(() => {
        Swal.fire({
            position: 'top-end',
            icon: icono,
            title: mensaje,
            showConfirmButton: true,
            showCancelButton: false,
            closeOnConfirm: true,
            closeOnCancel: true,
            confirmButtonText: 'OK',
            confirmButtonColor: '#3085d6',
            cancelButtonText: 'Cancel',
            showClass: {
                popup: 'animate__animated animate__fadeInDown'
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
            , timer: 3000

        })


    })
}