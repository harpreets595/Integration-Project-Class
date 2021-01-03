// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("document").ready(() => {

    grecaptcha.ready(function () {
        $("#contact-btn").on("click", e => {
            console.log("Clicked")
            e.preventDefault()
            grecaptcha.execute('6Ld9oMIUAAAAAOwhmebCmPM2gxLGBs3O4n1X3qOY', { action: 'homepage' }).then(function (token) {
                console.log(token)
                $("#token")[0].value = token
                $("#contact-form").submit()
            });

        })
    });
})

