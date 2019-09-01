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
        $('#form-outer').hide("fast");
        $('#form-result').show("slow");
        setTimeout(function () {
            $('#form-outer').show("slow");
            $('#form-result').hide("fast");
        }, 5000);
    }
}

$("#contact-button").click(function (e) {
    e.preventDefault();
    $("html, body").animate({ scrollTop: ($("#contactarea").offset().top) - 100 }, "fast");
    $('body').removeClass("is-menu-visible");
    setTimeout(function () { $("#contact-form-container").fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100).fadeOut(100).fadeIn(100); }, 500);
});

contactForm.init();