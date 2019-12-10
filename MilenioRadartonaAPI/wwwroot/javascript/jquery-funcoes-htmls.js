$('document').ready(function () {
    var janela = $(window).width();

    var cont = 1;

    if (janela < 992) {
        $('.quad4').css('display', 'none');
    }


    setInterval(function () {
        if (cont < 0) {
            janela = $(window).width();
            if (janela < 992) {
                $('.quad4').css('display', 'none');
            } else {
                $('.quad4').css('display', 'block');
            }
            cont = 1;
        }
        cont--;

    }, 10);

    $('.quad').css('top', '0px');

    $('#prod').mouseenter(function () {
        $('.quad4').css('top', '0px');
    });
    $('.quad4').mouseleave(function () {
        $(this).css('top', '-1000px');
    });

   
    $('#myCarousel').carousel({
        interval: 5000
    });

    $('#carousel-text').html($('#slide-content-0').html());

    //Handles the carousel thumbnails
    $('[id^=carousel-selector-]').click(function () {
        var id = this.id.substr(this.id.lastIndexOf("-") + 1);
        var id = parseInt(id);
        $('#myCarousel').carousel(id);
    });


    // QUANDO DA O SLIDE O CARROUSEK ATUALIZA
    $('#myCarousel').on('slid.bs.carousel', function (e) {
        var id = $('.item.active').data('slide-number');
        $('#carousel-text').html($('#slide-content-' + id).html());
    });


});

/*terminar tds os htmls e organizar estrutura das pastas (USE CTRL F PRA REPLACE)*/
/*FAZER A HOME DA INTRA NET*/
