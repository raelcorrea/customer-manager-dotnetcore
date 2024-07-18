$(function () {

    $('.cpf-mask').mask("000.000.000-00");
    $('.cep-mask').mask('00000-000');
    var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
        spOptions = {
            onKeyPress: function (val, e, field, options) {
                field.mask(SPMaskBehavior.apply({}, arguments), options);
            }
        };

    $('.tel-mask').mask(SPMaskBehavior, spOptions);
});