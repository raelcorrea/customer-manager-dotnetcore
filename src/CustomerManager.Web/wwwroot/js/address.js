function AddressList() {

    let addressList = [];

    return {
        load: (addresses) => {
            addresses.forEach(address => addressList.push(address));
        },
        getAddresses: () => {
            return addressList;
        },
        add: (address) => {
            addressList.push(address);
        },
        edit: (address) => {
            var _address = addressList.filter(adr => adr.Id == address.Id)[0]
            _address.ZipCode = address.ZipCode;
            _address.Street = address.Street;
            _address.City = address.City;
            _address.State = address.State;
        },
        clear: () => {
            addressList = [];
        }
    }
}
