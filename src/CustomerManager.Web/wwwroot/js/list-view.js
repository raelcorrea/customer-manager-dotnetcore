function ListView() {
    let items = [];

    const addItem = (item) => items.push(item);
    const editItem = (item) => {
        var _item = items.filter(adr => adr.Id == item.Id)[0]
        _item.ZipCode = item.ZipCode;
        _item.Street = item.Street;
        _item.City = item.City;
        _item.State = item.State;
    };
    const getItem = (item) => items.forEach(i => i == item);
    const getAllItems = () => items;
    const clear = () => items = [];

    return {
        addItem,
        editItem,
        getAllItems,
        getItem,
        clear
    };
}