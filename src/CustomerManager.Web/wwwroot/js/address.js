/// <reference path="subscriber.js" />
function AddressList() {

    const addressList = [];

    return {
        load: (addresses) => {
            addresses.forEach(address => addressList.push(address));
        },
        getAddresses: () => {
            return addressList;
        },
        add: (address) => {
            addressList.push(address);
        }
    }
}
