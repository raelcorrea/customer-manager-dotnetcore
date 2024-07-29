$(function () {
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
                });
            });
        } else {
            el.prop('disabled', false);
            alert('Insira um valor no CEP');
        }
    });
});