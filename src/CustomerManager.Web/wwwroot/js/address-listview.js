/// <reference path="subscriber.js" />
/// <reference path="address.js" />
const addressDataList = new AddressList();
const itemAddressStr = (address) => `<tr>
        <td>${address.Street}</td>
        <td>${address.City}</td>
        <td>${address.ZipCode}</td>
        <td>
            <a href="#" class="btn link-button btn-sm btn-edit text-success" data-bs-toggle="modal" data-bs-target="#modalAddressRegisterForm" data-id="${address.Id}" data-customerId="${address.CustomerId}" title="Editar endereço"><i class="bi bi-pencil-square"></i></a>
            <a href="#" class="btn link-button btn-sm btn-remove text-danger" data-id="${address.Id}" data-customerId="${address.CustomerId}" title="Remover endereço"><i class="bi bi-trash"></i></a>
        </td>
    </tr>`;
const emptyListStr = () => `<tr>
                    <td colspan="4">
                        <p class="text-center mb-0">Nenhum endereço cadastrado.</p>
                    </td>
                </tr>`;
const updateAddressListView = () => {
    var addresses = addressDataList.getAddresses()
    var result = document.querySelector("#addressResult");
    result.innerHTML = "";
    var itemListHtml = "";
    addresses.forEach(addr => itemListHtml += itemAddressStr(addr));
    result.insertAdjacentHTML('afterbegin', itemListHtml);
    eventRemoveAddress();
    if (addresses.length == 0) {
        result.insertAdjacentHTML('afterbegin', emptyListStr());
    }
}
function eventRemoveAddress() {
    const addressListHidenField = $("#addressListHidenField");
    var btnRemove = $('a.btn-remove');
    var btnEdit = $('a.btn-edit');
    btnEdit.each((index, btn) => {
        btn.addEventListener('click', function () {
            const { id, customerid } = this.dataset;

            const addressForm = $("#addressForm");
            addressForm[0].reset();

            var fields = addressForm.find("input");

            fetch(`/Address/${customerid}`)
                .then((res) => res.json())
                .then((addresses) => {
                    var address = addresses.filter(adr => adr.Id == id)[0];
                    fields.each((index, input) => {
                        let { name, value } = input
                        input.value = address[name];
                    });
                });
        });
    });

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
                        addressDataList.clear();
                        addressListHidenField.val(addresses);
                        addresses.forEach(address => addressDataList.add(address));
                        Subscriber.notify("update_address_listview");
                    });
                });
            }
        });
    });
}
function submitAddress(form) {
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

            if (methodOpt == "POST")
                addressDataList.add(address);
            else
                addressDataList.edit(objData);

            loading.style.display = "none";
            modal.hide();
            button.removeAttribute('disabled');
            form.reset();
            Subscriber.notify("update_address_listview")

        }).catch((err) => console.error(err));

        return false;
    } catch (ex) {
        console.error(ex);
        return false;
    }
}
function removeAddress(addressId, customerId) {

    var formData = new FormData();

    formData.append("addressId", addressId);
    formData.append("customerId", customerId);

    fetch('/Address/Remove', {
        method: "DELETE",
        body: formData
    }).then((res) => {
        Subscriber.notify("update_address_listview");
    })
}
$(function () {
    Subscriber.subscribe("update_address_listview", updateAddressListView);
    eventRemoveAddress();

    var btnZipCode = $(".btn-zipcode");

    btnZipCode.on('click', (e) => {
        e.preventDefault();
        const el = $(e.target);
        const form = el.parents("form");
        const fields = form.find('input');
        const zipCode = form.find('input[name="ZipCode"]');
        el.prop('disabled', true);
        if (zipCode.val() != '') {
            fetch(`https://viacep.com.br/ws/${zipCode.val()}/json/`).then((res) => res.json()).then((zipCode) => {
                console.log(zipCode)
                el.prop('disabled', false);
                fields.each((index, input) => {
                    let { name, value } = input;
                    var map = {
                        "City": "localidade",
                        "Street": "logradouro",
                        "State": "uf"
                    };

                    if (map[name])
                        input.value = zipCode[map[name]];

                })
            })
        } else {
            el.prop('disabled', false);
            alert('Insira um valor no CEP')
        }
    })
});

