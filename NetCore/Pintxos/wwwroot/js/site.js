// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    $('.active-button').on('click', function(e) {
        markActive(e.target);
    });
});

function markActive(button) {
    var form = button.closest('form');
    form.submit();
}