const showInModal = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: (response) => {

            $('#modal-body').html(response);
            $('#modal-title').html(title);
            $('#form-modal').modal('show');

        },
        error: (err) => {
            console.log(err);
        }
    });
};


const ajaxPost = (form) => {
    try {

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form), // lo mismo que multipart/fotm-data
            contentType: false,
            processData: false,
            success: (response) => {

                if (response.isValid) {
                    $('#list-all').html(response.html);
                    $('#modal-body').html('');
                    $('#modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else {
                    $('#modal-body').html(response.html);
                }

            },
            error: (err) => {
                console.log(err);
            }
        });

        return false;
    } catch (ex) {
        console.log(ex);
    }
};

//const handleDeleteModalShow = (vm) => {
//    const name = vm.split('-')[0];
//    const id = parseInt(vm.split('-')[1]);

//    const title = document.getElementById('modal-title');
//    const message = document.getElementById("delete-message");
//    const btn = document.getElementById("delete-btn");

//    btn.setAttribute("href", '/Pais/Delete/' + id);

//    message.innerText = "Esta seguro que quiere eliminar " + name;
//    btn.innerText = "Eliminar";
//    title.innerText = "Eliminar pais";
//    btn.classList.remove('btn-success');
//    btn.classList.add('btn-danger');


//    $('#delete-modal').modal("show");
//}