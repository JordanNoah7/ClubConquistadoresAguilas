// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*const UserModel={
    username:"",
    password:""
}

$("#btnIngresar").click(()=>{
    UserModel["username"]=$("#username").val();
    UserModel["password"]=$("#password").val();
})*/

function hideErrorMessage(){
    var errorMessageElement = document.getElementById('message');
    errorMessageElement.style.display = 'none';
}
setTimeout(hideErrorMessage, 5000);