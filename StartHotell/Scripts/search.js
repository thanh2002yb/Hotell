$('#keyword').keyup(function () {
    var searchField = $('#keyword').val().toLowerCase();

    if (searchField.length > 100) {
        searchField = searchField.substring(0, 100);
        $('#keyword').val(searchField);
    }

    $('.tt-dataset').remove();
    $.ajax({
        type: "GET",
        url: "/Home/Search",
        success: function (response) {
            var data = JSON.parse(response);

            if (searchField != "") {
                var filteredData = data.filter(function (item) {
                    var productName = item.Name.toLowerCase();
                    var productDescription = item.Description.toLowerCase();
                    return productName.includes(searchField) || productDescription.includes(searchField);
                });

                console.log(filteredData)


                var html_body = `<div class="tt-dataset tt-dataset-states"></div>`;
                $('.tt-menu').append(html_body);


                $.each(filteredData, function (key, item) {
                    var html_search = `<div class="man-section tt-suggestion tt-selectable" data-product-id="${item.ID}">
                      <div class="image-section">
                        <img src="${item.Image}">
                      </div>
                      <div class="description-section">
                        <h1>${item.Name}</h1>
                        <p>${item.Description}</p>
                      </div>
                    </div>`;
                    $('.tt-dataset').append(html_search);

                    $('.tt-dataset').on('click', '.tt-suggestion', function () {
                        var selectedProductId = $(this).data('product-id')
                        window.location.href = '/chi-tiet/' + selectedProductId;
                    });

                });
            }
        }
    });
});





