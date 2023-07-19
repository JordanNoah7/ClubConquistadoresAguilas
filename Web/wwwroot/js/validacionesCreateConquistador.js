var campoDNI = document.getElementById("dni");
var mensajeAdvertenciaDNI = document.getElementById("mensajeAdvertenciaDNI");

campoDNI.addEventListener("input", function () {
    var valor = this.value;

    if (!/^\d{8}$/.test(valor)) {
        mensajeAdvertenciaDNI.style.display = "inline";
    } else {
        mensajeAdvertenciaDNI.style.display = "none";
    }
});

var campoNombre = document.getElementById("nombre");
var mensajeAdvertenciaNombre = document.getElementById("mensajeAdvertenciaNombre");

campoNombre.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaNombre.innerText = "Como mínimo 3 caracteres";
        mensajeAdvertenciaNombre.style.display = "inline";
    } else if (valor.length > 30 || !/^([a-zA-Z]+\s?)+$/.test(valor)) {
        mensajeAdvertenciaNombre.innerText = "Ingrese un máximo de 30 letras.";
        mensajeAdvertenciaNombre.style.display = "inline";
    } else {
        mensajeAdvertenciaNombre.style.display = "none";
    }
});


var campoApellidoPaterno = document.getElementById("apellidoPaterno");
var mensajeAdvertenciaApellido = document.getElementById("mensajeAdvertenciaApellido");

campoApellidoPaterno.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaApellido.innerText = "Como mínimo 3 caracteres";
        mensajeAdvertenciaApellido.style.display = "inline";
    } else if (/\d/.test(valor)) {
        mensajeAdvertenciaApellido.innerText = "No se permiten números";
        mensajeAdvertenciaApellido.style.display = "inline";
    } else {
        mensajeAdvertenciaApellido.style.display = "none";
    }
});

var campoApellidoMaterno = document.getElementById("apellidoMaterno");
var mensajeAdvertenciaMaterno = document.getElementById("mensajeAdvertenciaMaterno");

campoApellidoMaterno.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaMaterno.innerText = "Como mínimo 3 caracteres";
        mensajeAdvertenciaMaterno.style.display = "inline";
    } else if (/\d/.test(valor)) {
        mensajeAdvertenciaMaterno.innerText = "No se permiten números";
        mensajeAdvertenciaMaterno.style.display = "inline";
    } else {
        mensajeAdvertenciaMaterno.style.display = "none";
    }
});

var fechaMinima = new Date("@fechaMinimaString");

document.getElementById("fechaNacimiento").addEventListener("change", function () {
    var fechaNacimiento = new Date(this.value);
    var edad = new Date().getFullYear() - fechaNacimiento.getFullYear();

    if (edad < 10) {
        document.getElementById("mensajeAdvertencia").style.display = "inline";
    } else {
        document.getElementById("mensajeAdvertencia").style.display = "none";
    }
});


var campoTelefono = document.getElementById("telefono");
var mensajeAdvertenciaTelefono = document.getElementById("mensajeAdvertenciaTelefono");

campoTelefono.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length !== 9) {
        mensajeAdvertenciaTelefono.style.display = "inline";
    } else {
        mensajeAdvertenciaTelefono.style.display = "none";
    }
});

var campoDireccion = document.getElementById("direccion");
var mensajeAdvertenciaDireccion = document.getElementById("mensajeAdvertenciaDireccion");

campoDireccion.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length > 50) {
        mensajeAdvertenciaDireccion.style.display = "inline";
    } else {
        mensajeAdvertenciaDireccion.style.display = "none";
    }
});

var campoUsuario = document.getElementById("usuario");
var mensajeAdvertenciaUsuario = document.getElementById("mensajeAdvertenciaUsuario");

campoUsuario.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 6 || /\s/.test(valor) || /[^a-zA-Z0-9]/.test(valor)) {
        mensajeAdvertenciaUsuario.style.display = "inline";
    } else {
        mensajeAdvertenciaUsuario.style.display = "none";
    }
});

var campoContrasena = document.getElementById("contrasena");
var mensajeAdvertenciaContrasena = document.getElementById("mensajeAdvertenciaContrasena");

campoContrasena.addEventListener("input", function () {
    var valor = this.value;

    var regexMayuscula = /[A-Z]/;
    var regexCaracterEspecial = /[^a-zA-Z0-9]/;
    var regexNumero = /[0-9]/;

    if (
        valor.length < 8 ||
        !regexMayuscula.test(valor) ||
        !regexCaracterEspecial.test(valor) ||
        !regexNumero.test(valor)
    ) {
        mensajeAdvertenciaContrasena.innerHTML = "Formato de contraseña inválido. Debe contener al menos 8 caracteres, una mayúscula, un carácter especial y un número.";
        mensajeAdvertenciaContrasena.style.display = "inline";
    } else {
        mensajeAdvertenciaContrasena.style.display = "none";
    }
});