window.showSweetAlert = (title, text, icon) => {
    Swal.fire({
        title: title,
        text: text,
        icon: icon
    });
};

window.showConfirmAlert = async (title, text) => {
    const result = await Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Ya',
        cancelButtonText: 'Batal'
    });

    return result.isConfirmed;
};
