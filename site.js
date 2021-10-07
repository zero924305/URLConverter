// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Use Regex to filter the url format
$("#url").keyup(function () {
    var expression = /^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$/gi;
    var regex = new RegExp(expression);
    if ($(this).val() == "") {
        $("#convertBtn").prop("disabled", true);
        $("#match").hide();
        $("#error").hide();
    }
    else {
        if ($(this).val().match(regex)) {
            $("#error").hide();
            $("#match").show();
            $("#convertBtn").prop("disabled", false);
        }
        else {
            $("#convertBtn").prop("disabled", true);
            $("#error").show();
            $("#match").hide();
        }
    }   
}).keyup();


$('.copyBtn').click(function () {
    copyToClipboard($(this).siblings(".copyUrl"));
});

function copyToClipboard(element) {
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).val()).select();
    document.execCommand("copy");
    $temp.remove();
}