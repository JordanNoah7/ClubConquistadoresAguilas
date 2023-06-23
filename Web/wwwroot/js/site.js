// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const allSideMenu = document.querySelectorAll('#sidebar .side-menu li a');

allSideMenu.forEach(item => {
    const li = item.parentElement;
    item.addEventListener('click', function () {
        allSideMenu.forEach(i => { 
            i.parentElement.classList.remove('active');
        })
        li.classList.add('active');
    })
});