var contactForm = contactForm || {
    init: function () {
        this.listeners();

    },
    listeners: function () {
        $(document).on('click', '.contact-submit', function (e) {
            e.preventDefault();
            var form = $(this).closest('form');
            $(form).submit();
        })

    },
    showResult: function () {
        $('#form-outer').hide();
        $('#form-result').show();
    }
}

$("#contact-button").click(function (e) {
    e.preventDefault();
    $("html, body").animate({ scrollTop: document.body.scrollHeight }, "slow");
    $('body').removeClass("is-menu-visible");
    setTimeout(function () { $("#contact-form-container").fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100); }, 500);

});

contactForm.init();