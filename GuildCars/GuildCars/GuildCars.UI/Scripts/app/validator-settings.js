$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.input-group-sm').removeClass('has-success').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.input-group-sm').removeClass('has-error').addClass('has-success');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});