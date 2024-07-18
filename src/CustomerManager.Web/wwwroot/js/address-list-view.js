/// <reference path="subscriber.js" />
/// <reference path="address.js" />

const addressDataList = new AddressList();

const itemAddressStr = (address) => `<tr>
        <td>${address.Street}</td>
        <td>${address.City}</td>
        <td>${address.ZipCode}</td>
        <td>
            <a href="#">Editar</a>
        </td>
    </tr>`;

var updateAddressListView = () => {
    var addresses = addressDataList.getAddresses()
    var result = document.querySelector("#addressResult");
    result.innerHTML = "";
    var itemListHtml = "";
    addresses.forEach(addr => itemListHtml += itemAddressStr(addr));
    result.insertAdjacentHTML('afterbegin', itemListHtml);
}

Subscriber.subscribe("update_address_listview", updateAddressListView);

function submitAddress(form) {
    try {
        const modalAddressRegisterForm = document.getElementById('modalAddressRegisterForm');
        const loading = document.querySelector("#loading");
        const modal = bootstrap.Modal.getInstance(modalAddressRegisterForm);
        var fields = form.querySelectorAll("input");
        var button = form.querySelector('button[type="submit"]');
        var formData = new FormData();
        var objData = {};
        fields.forEach(input => {
            objData[input.name] = input.value;
            formData.append(input.name, input.value);
        });
        addressDataList.add(objData);
        button.setAttribute('disabled', true);
        loading.style.display = "inline-block";

        fetch('/Address/Register', {
            method: 'POST',
            body: formData
        }).then(res => res.json()).then((res) => {
            Subscriber.notify("update_address_listview")
            loading.style.display = "none";
            modal.hide();
            button.removeAttribute('disabled');
            form.reset();
        })

        return false;
    } catch (ex) {
        console.error(ex);
        return false;
    }
}
