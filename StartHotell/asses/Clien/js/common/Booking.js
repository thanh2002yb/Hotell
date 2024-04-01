var booking = {
    innt: function () {
        booking.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $(".quantity");
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data("id")
                    }
                });
            });
            $.ajax({
                url: '/Booking/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'JSON',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/danh-sach";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Booking/DeleteAll',
                dataType: 'JSON',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/danh-sach";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                url: '/Booking/Delete',
                data: { id: $(this).data("id") },
                dataType: 'JSON',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/danh-sach";
                    }
                }
            })
        });

    }
}
booking.innt();
