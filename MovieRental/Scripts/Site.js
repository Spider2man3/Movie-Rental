$(document).ready(function () {
    $('.carousel-item')
        .eq(0).addClass('active').end();
    $('li.active').removeClass('active');
    $('a[href="' + location.pathname + '"]').closest('li').addClass('active');

    $('button#searchButton').click(function () {
        $.ajax({
            url: '/Movie/Search',
            type: 'post',
            //dataType: 'json',
            data: {
                search: $('#searchText').val(),
            },
            success: function (data) {
                document.open();
                document.write(data);
                document.close();
            }
        });
    });
});