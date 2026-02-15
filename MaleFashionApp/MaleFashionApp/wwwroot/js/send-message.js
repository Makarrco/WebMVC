(() => {

    $('#sendBtn').on('click', function () {

        let isValid = true;

        const name = $('[name="Title"]');
        const email = $('[name="Email"]');
        const message = $('[name="Message"]');

        // очистка старих помилок
        $('input, textarea').removeClass('input-error');

        if (name.val().trim() === '') {
            name.addClass('input-error');
            isValid = false;
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

        if (!emailRegex.test(email.val().trim())) {
            email.addClass('input-error');
            isValid = false;
        }

        if (message.val().trim().length < 10) {
            message.addClass('input-error');
            isValid = false;
        }

        if (isValid) {
            $('#send-message-form').submit();
        }

    });

    $('#Title, #Email, #Message').on('input', function () {
        $(this).removeClass('input-error');
    });

})();
