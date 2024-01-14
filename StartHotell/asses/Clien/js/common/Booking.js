var booking = {
    innt: function () {
        booking.regEvents();
    },
    regEvents: function () {
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
    }
}
booking.innt();