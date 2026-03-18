// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // When clicking a menu link
    $('.navbar-nav li a').click(function () {
        // Remove active class from all items
        $('.navbar-nav li').removeClass('active');
        // Add active class to clicked item's parent <li>
        $(this).parent().addClass('active');
    });

    // Optional: highlight menu item on scroll
    $(window).scroll(function () {
        var scrollDistance = $(window).scrollTop();

        // Iterate over each section
        $('section').each(function (i) {
            if ($(this).position().top <= scrollDistance + 100) {
                $('.navbar-nav li').removeClass('active');
                $('.navbar-nav li a[href="#' + $(this).attr('id') + '"]').parent().addClass('active');
            }
        });
    }).scroll();
});