const editAddress = (addresses) => {
    const addressForm = $("#addressForm");
    var btnEdit = $('a.btn-edit');
    var fields = addressForm.find("input");

    const reset = () => {
        addressForm[0].reset()
        addressForm.find('input[name="Id"]').val("0");
    };

    const result = (address, addressId) => {
        var address = addresses.filter(adr => adr.Id == addressId)[0];
        fields.each((index, input) => {
            let { name, value } = input
            input.value = address[name];
        });
    }

    btnEdit.each((index, btn) => {
        btn.addEventListener('click', function () {
            const { id, customerid } = this.dataset;

            reset();

            fetch(`/Address/${customerid}`)
                .then((res) => res.json())
                .then((addresses) => {
                    result(addresses, id);
                });
        });
    });

}
const removeAddress = (callback) => {
    var btnRemove = $('a.btn-remove');

    btnRemove.each((index, btn) => {
        btn.addEventListener('click', function (e) {
            e.preventDefault();
            var removeWarning = confirm('ATENÇÃO: Tem certeza que deseja excluir este endereço?');
            if (removeWarning) {
                const { id, customerid } = this.dataset;
                const formData = new FormData();
                formData.append("addressId", id);
                formData.append("customerId", customerid);
                fetch("/Address/Delete", {
                    method: "DELETE",
                    body: formData
                }).then(() => {
                    fetch(`/Address/${customerid}`).then(res => res.json()).then((addresses) => {
                        callback(addresses);
                    });
                });
            }
        });
    });
}
const addAddress = (form, callback) => {
    try {
        const _form = $(form);
        const _isValid = _form.valid();
        const modalAddressRegisterForm = $('#modalAddressRegisterForm');
        const loading = document.querySelector("#loading");
        const modal = bootstrap.Modal.getInstance(modalAddressRegisterForm[0]);
        var fields = form.querySelectorAll("input");
        var button = form.querySelector('button[type="submit"]');
        var formData = new FormData();
        var objData = {};


        let urlApi = "/Address/Register";
        let methodOpt = "POST";



        if (!_isValid) return false;

        fields.forEach(input => {
            const { name, value } = input
            objData[name] = value;

            if (name == "Id" && value != 0) {
                urlApi = "/Address/Update";
                methodOpt = "PUT";
            }

            formData.append(input.name, input.value);
        });



        button.setAttribute('disabled', true);
        loading.style.display = "inline-block";

        fetch(urlApi, {
            method: methodOpt,
            body: formData
        }).then(res => res.json()).then((address) => {

            console.log(callback, typeof callback)
            if (methodOpt == "POST")
                callback(address,"POST");
            else
                callback(objData, "PUT");

            loading.style.display = "none";
            modal.hide();
            button.removeAttribute('disabled');
            form.reset();
            fields[0].value=0;
        }).catch((err) => console.error(err));

        return false;
    } catch (ex) {
        console.error(ex);
        return false;
    }


}