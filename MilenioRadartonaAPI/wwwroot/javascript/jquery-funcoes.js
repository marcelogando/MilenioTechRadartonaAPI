jQuery(document).ready(function () {
    var janela = $(window).width();

    //nav
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
            if (janela < 992) {
                $('.quad').css('top', '0px');
            }
            cont = 1;
        }
        cont--;

    }, 100);

    $('.navbar').mouseenter(function () {
        $('.quad').css('top', '0px');
    }).mouseleave(function () {
        if (janela < 992) {
            $('.quad').css('top', '0px');
        } else {
            $('.quad').css('top', '-100px');

        }

    });

    $('#prod').mouseenter(function () {
        $('.quad4').css('top', '0px');
    });
    $('.quad4').mouseenter(function () {
        $('.quad').css('top', '0px');
    });
    $('.quad4').mouseleave(function () {
        $(this).css('top', '-1000px');
        $('.quad').css('top', '-100px');

    });


    // Carroucel / cores da page
    $('.car-img').css({ 'bottom': '-200px', 'transition-duration': '1000ms' });
    $('.car-listra').css({ 'bottom': '-300px', 'transition-duration': '2000ms' });
    $('.h-car').css({ 'bottom': '-600px', 'transition-duration': '2000ms' });
    $('p.car').css({ 'bottom': '-600px', 'transition-duration': '2000ms' });

    var idx = 0;

    $('.quad').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
    $('.quad4').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
    $('#navbarTogglerDemo03').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
    $('.nav-link').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' });
    $('a').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' });
    $('h1.navbar-brand').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' })
    $('h5.nav-link').css({ 'color': '#112640', 'transition-duration': '1000ms' });
    $('.escuro').css({ 'color': '#112640', 'transition-duration': '1000ms' });


    $('#carouselExampleFade').on('slid.bs.carousel', function () {
        $('p.car').css({ 'bottom': '40px', 'transition-duration': '2000ms' });
        $('div.quad3').css('margin-left', '0px');
        $('.car-img').css({ 'bottom': '5px', 'transition-duration': '1000ms' });
        $('.h-car').css({ 'bottom': '140px', 'transition-duration': '2000ms' });
        $('.car-listra').css({ 'bottom': '0px', 'transition-duration': '2000ms' });
        $('.quad').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
        $('.quad4').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
        $('h5.nav-link').css({ 'color': '#112640', 'transition-duration': '1000ms' });
        $('.escuro').css({ 'background': '#112640', 'transition-duration': '1000ms' });

        $('#navbarTogglerDemo03').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
        $('p.car').css({ 'bottom': '40px', 'transition-duration': '2000ms' });
        janela = $(window).width();
        if (janela < 991) {
            $('#login').css({ 'margin-top': '10px', 'transition-duration': '1000ms' });
        }

        if (idx == 0) {
            $('#navbarTogglerDemo03').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
            $('.nav-link').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' });
            $('a').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' });
            $('h1.navbar-brand').css({ 'color': '#d1e2ff', 'transition-duration': '1000ms' });
            $('.quad').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
            $('.quad4').css({ 'background-color': '#112640cc', 'transition-duration': '1000ms' });
            $('h5.nav-link').css({ 'color': '#112640', 'transition-duration': '1000ms' });
            $('.escuro').css({ 'background': '#112640', 'transition-duration': '1000ms' });
        }

        if (idx == 1) {
            janela = $(window).width();
            $('.navbar-brand').css({ 'color': '#6bff81', 'transition-duration': '1000ms' })
            $('#navbarTogglerDemo03').css({ 'background-color': '#06360dbb', 'transition-duration': '1000ms' });
            $('.quad').css({ 'background-color': '#06360dbb', 'transition-duration': '1000ms' });
            $('.quad4').css({ 'background-color': '#06360dbb', 'transition-duration': '1000ms' });
            $('.nav-link').css({ 'color': '#6bff81', 'transition-duration': '1000ms' });
            $('#login a').css({ 'color': '#6bff81', 'transition-duration': '1000ms' });
            $('h5.nav-link').css({ 'color': '#06360d', 'transition-duration': '1000ms' });
            $('.escuro').css({ 'background': '#06360d', 'transition-duration': '1000ms' });
        }

        if (idx == 2) {
            $('.quad').css({ 'background-color': '#330000cc', 'transition-duration': '1000ms' });
            $('.quad4').css({ 'background-color': '#330000cc', 'transition-duration': '1000ms' });
            $('#navbarTogglerDemo03').css({ 'background-color': '#330000cc', 'transition-duration': '1000ms' });
            $('.nav-link').css({ 'color': '#ffffff', 'transition-duration': '1000ms' });
            $('a').css({ 'color': '#ffffff', 'transition-duration': '1000ms' });
            $('h1.navbar-brand').css({ 'color': '#ffffff', 'transition-duration': '1000ms' });
            $('h5.nav-link').css({ 'color': '#330000', 'transition-duration': '1000ms' });
            $('.escuro').css({ 'background': '#330000', 'transition-duration': '1000ms' });
            idx = -1;
        }

    });

    $('#carouselExampleFade').on('slide.bs.carousel', function () {
        $('div.quad3').css('margin-left', '-5000px');
        $('.car-img').css({ 'bottom': '-210px', 'transition-duration': '1000ms' });
        $('p.car').css({ 'bottom': '-600px', 'transition-duration': '2000ms' });
        $('.h-car').css({ 'bottom': '-600px', 'transition-duration': '2000ms' });
        $('.car-listra').css({ 'bottom': '-300px', 'transition-duration': '2000ms' });
        idx++;
    });

    $('.car-img').css({ 'bottom': '5px', 'transition-duration': '1000ms' });
    $('.h-car').css({ 'bottom': '140px', 'transition-duration': '2000ms' });
    $('.car-listra').css({ 'bottom': '0px', 'transition-duration': '2000ms' });
    $('p.car').css({ 'bottom': '40px', 'transition-duration': '2000ms' });

    $('#wd').hover(function () {
        $('#prod-img').attr('src', 'images/products/wed2.png');
    });

    $('#bk').hover(function () {
        $('#prod-img').attr('src', 'images/products/bk3.png');
    });

    $('#vc').hover(function () {
        $('#prod-img').attr('src', 'images/products/vd1.png');
    });

    $('#tn').hover(function () {
        $('#prod-img').attr('src', 'images/products/bk1.png');
    });

});
