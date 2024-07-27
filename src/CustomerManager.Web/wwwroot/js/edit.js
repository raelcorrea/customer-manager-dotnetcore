/// <reference path="event-subscriber.js" />
$(function () {
    // Instancio o List View
    const listView = ListView();

    const eventName = {
        update_list_view: "update_list_view"
    }

    // Instancio o Event Subscriber
    const eventSub = new EventSubscriber();

    // Abstraio os elementos #addressResult e #addressListHidenField
    const controls = (() => {
        const addressResult = document.querySelector("#addressResult");
        const addressList = document.querySelector("#addressListHidenField")
        return {
            addressResult: () => addressResult,
            updateAddressList: (addresses) => addressList.value = addresses,
            clearAddressResult: () => addressResult.innerHTML = "",
            addressList: () => {
                return JSON.parse(addressList.value);
            },

        }
    })();

    // Obtenho a lista de endereço previamente cadastrado, que carrego dentro de um hidden field;
    const addressList = controls.addressList();

    // Percorro o resultado da liste e adiciono a instancia do do List View
    addressList.forEach(address => listView.addItem(address));

    // Template string para exibir os items da lista e limpar a lista
    const template = (() => {
        return {
            itemList: (item) => `<tr>
                                    <td>${item.Street}</td>
                                    <td>${item.City}</td>
                                    <td>${item.ZipCode}</td>
                                    <td>
                                        <a href="#" class="btn link-button btn-sm btn-edit text-success" data-bs-toggle="modal" data-bs-target="#modalAddressRegisterForm" data-id="${item.Id}" data-customerId="${item.CustomerId}" title="Editar endereço"><i class="bi bi-pencil-square"></i></a>
                                        <a href="#" class="btn link-button btn-sm btn-remove text-danger" data-id="${item.Id}" data-customerId="${item.CustomerId}" title="Remover endereço"><i class="bi bi-trash"></i></a>
                                    </td>
                                </tr>`,
            clearList: () => `<tr>
                                <td colspan="4">
                                    <p class="text-center mb-0">Nenhum endereço cadastrado.</p>
                                </td>
                              </tr>`
        }
    })();

    const bindEvents = (addresses) => {
        editAddress(addresses);
        removeAddress((addresses) => {
            listView.clear();
            controls.updateAddressList(addresses);
            addresses.forEach(address => listView.addItem(address));
            eventSub.notify(eventName.update_list_view);
        });
    }

    // Atualizar a lista de endereço, sempre que for notificado pelo EventSubscriber
    const updateListViewListener = () => {
        // Limpamos a tela de resultado

        controls.clearAddressResult();

        const addresses = listView.getAllItems();
        const addressResult = controls.addressResult();
        let addressItems = "";

        // Interpolamos o resultado em um template e adicionamos em uma variavel
        addresses.forEach(address => addressItems += template.itemList(address));

        // Jogamos o resultado a interpolação na tabela de resultado
        addressResult.insertAdjacentHTML('afterbegin', addressItems);


        // Vinculando eventos
        bindEvents(addresses);


        // Se a lista de endereço for vazia, exibimos a mensagem de Nenhum endereço foi encontrado
        if (addresses.length == 0) {
            addressResult.insertAdjacentHTML('afterbegin', template.clearList());
        }
    }

    /* 
        Realizo a inscrição do metodo updateListViewListener ao EventSuscriber, 
        que será executado assim que o evento udpate_list_view for notificado.
    */
    eventSub.subscribe(eventName.update_list_view, updateListViewListener)
    const allAddresses = listView.getAllItems();
    bindEvents(allAddresses)

    // Vinculo evento de submit ao formulário
    const addressForm = document.querySelector("#addressForm");
    addressForm.addEventListener('submit', (e) => {
        e.preventDefault();
        var form = e.target;
        addAddress(form, (result, method) => {
            if (method == "POST") {
                listView.addItem(result);
            }

            if (method == "PUT") {
                listView.editItem(result);
            }

            // Notifico que o list view precisa ser atualizado
            eventSub.notify(eventName.update_list_view)
        });
    });

})