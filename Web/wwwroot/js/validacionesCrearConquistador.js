var campoDNI = document.getElementById("dni");
var mensajeAdvertenciaDNI = document.getElementById("mensajeAdvertenciaDNI");

var campoNombre = document.getElementById("nombre");
var mensajeAdvertenciaNombre = document.getElementById("mensajeAdvertenciaNombre");

var campoApellidoPaterno = document.getElementById("apellidoPaterno");
var mensajeAdvertenciaApellido = document.getElementById("mensajeAdvertenciaApellido");

var campoApellidoMaterno = document.getElementById("apellidoMaterno");
var mensajeAdvertenciaMaterno = document.getElementById("mensajeAdvertenciaMaterno");

var campoTelefono = document.getElementById("telefono");
var mensajeAdvertenciaTelefono = document.getElementById("mensajeAdvertenciaTelefono");

var campoDireccion = document.getElementById("direccion");
var mensajeAdvertenciaDireccion = document.getElementById("mensajeAdvertenciaDireccion");

var campoUsuario = document.getElementById("usuario");
var mensajeAdvertenciaUsuario = document.getElementById("mensajeAdvertenciaUsuario");

var campoContrasena = document.getElementById("contrasena");
var mensajeAdvertenciaContrasena = document.getElementById("mensajeAdvertenciaContrasena");

var btnGuardar = document.getElementById("btnGuardar");

var validaciones = {
    dni: false,
    nombre: false,
    apellidoPaterno: false,
    apellidoMaterno: false,
    fechaNacimiento: false,
    telefono: false,
    direccion: false,
    usuario: false,
    contrasena: false
};


campoDNI.addEventListener("input", function () {
    var valor = this.value;

    if (!/^\d{8}$/.test(valor)) {
        mensajeAdvertenciaDNI.style.display = "inline";
        validaciones.dni = false;
    } else {
        mensajeAdvertenciaDNI.style.display = "none";
        validaciones.dni = true;
    }

    validarFormulario();
});


campoNombre.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaNombre.innerText = "Como m�nimo 3 caracteres";
        mensajeAdvertenciaNombre.style.display = "inline";
        validaciones.nombre = false;
    } else if (valor.length > 30 || !/^([a-zA-Z]+\s?)+$/.test(valor)) {
        mensajeAdvertenciaNombre.innerText = "Ingrese un m�ximo de 30 letras.";
        mensajeAdvertenciaNombre.style.display = "inline";
        validaciones.nombre = false;
    } else {
        mensajeAdvertenciaNombre.style.display = "none";
        validaciones.nombre = true;
    }

    validarFormulario();
});


campoApellidoPaterno.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaApellido.innerText = "Como m�nimo 3 caracteres";
        mensajeAdvertenciaApellido.style.display = "inline";
        validaciones.apellidoPaterno = false;
    } else if (/\d/.test(valor)) {
        mensajeAdvertenciaApellido.innerText = "No se permiten n�meros";
        mensajeAdvertenciaApellido.style.display = "inline";
        validaciones.apellidoPaterno = false;
    } else {
        mensajeAdvertenciaApellido.style.display = "none";
        validaciones.apellidoPaterno = true;
    }

    validarFormulario();
});


campoApellidoMaterno.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 3) {
        mensajeAdvertenciaMaterno.innerText = "Como m�nimo 3 caracteres";
        mensajeAdvertenciaMaterno.style.display = "inline";
        validaciones.apellidoMaterno = false;
    } else if (/\d/.test(valor)) {
        mensajeAdvertenciaMaterno.innerText = "No se permiten n�meros";
        mensajeAdvertenciaMaterno.style.display = "inline";
        validaciones.apellidoMaterno = false;
    } else {
        mensajeAdvertenciaMaterno.style.display = "none";
        validaciones.apellidoMaterno = true;

    }

    validarFormulario();
});

var fechaMinima = new Date("@fechaMinimaString");

document.getElementById("fechaNacimiento").addEventListener("change", function () {
    var fechaNacimiento = new Date(this.value);
    var edad = new Date().getFullYear() - fechaNacimiento.getFullYear();

    if (edad < 10) {
        document.getElementById("mensajeAdvertencia").style.display = "inline";
        validaciones.fechaNacimiento = false;
    } else {
        document.getElementById("mensajeAdvertencia").style.display = "none";
        validaciones.fechaNacimiento = true;

    }

    validarFormulario();
});


campoTelefono.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length !== 9) {
        mensajeAdvertenciaTelefono.style.display = "inline";
        validaciones.telefono = false;
    } else {
        mensajeAdvertenciaTelefono.style.display = "none";
        validaciones.telefono = true;
    }

    validarFormulario();
});


campoDireccion.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length > 50) {
        mensajeAdvertenciaDireccion.style.display = "inline";
        validaciones.direccion = false;
    } else {
        mensajeAdvertenciaDireccion.style.display = "none";
        validaciones.direccion = true;
    }

    validarFormulario();
});


campoUsuario.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length < 6 || /\s/.test(valor) || /[^a-zA-Z0-9]/.test(valor)) {
        mensajeAdvertenciaUsuario.style.display = "inline";
        validaciones.usuario = false;
    } else {
        mensajeAdvertenciaUsuario.style.display = "none";
        validaciones.usuario = true;
    }
    validarFormulario();
});


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
        mensajeAdvertenciaContrasena.innerHTML = "Formato de contrase�a inv�lido. Debe contener al menos 8 caracteres, una may�scula, un car�cter especial y un n�mero.";
        mensajeAdvertenciaContrasena.style.display = "inline";
        validaciones.contrasena = false;
    } else {
        mensajeAdvertenciaContrasena.style.display = "none";
        validaciones.contrasena = true;
    }

    validarFormulario();
});

function validarFormulario() {
    var formValido = true;

    for (var key in validaciones) {
        if (!validaciones[key]) {
            formValido = false;
            break;
        }
    }


    if (formValido) {
        btnGuardar.disabled = false;
        btnGuardar.style.cursor = "pointer";
        btnGuardar.style.backgroundColor = "red";
        btnGuardar.style.color = "white";
        btnGuardar.style.borderColor = "red";

    } else {
        btnGuardar.disabled = true;
        btnGuardar.style.cursor = "not-allowed";
        btnGuardar.style.backgroundColor = "white";
        btnGuardar.style.color = "#00BF63";
        btnGuardar.style.borderColor = "#00BF63";
    }
}