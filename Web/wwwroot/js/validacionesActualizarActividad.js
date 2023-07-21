var campoNombre = document.getElementById("nombre");
var mensajeNombre = document.getElementById("mensajeNombre");

var campoFechaInicio = document.getElementById("fechaInicio");
var campoFechaFin = document.getElementById("fechaFin");
var mensajeFechaInicio = document.getElementById("mensajeFechaInicio");
var mensajeFechaFin = document.getElementById("mensajeFechaFin");
var fechaActualLocal = new Date();


var offsetHorarioPeru = -5;


var fechaActualPeru = new Date(fechaActualLocal.getTime() + (offsetHorarioPeru * 60 * 60 * 1000));


var btnGuardar = document.getElementById("btnGuardar");

var validaciones = {
    nombre: true,
    fechaInicio: true,
    fechaFin: true
};


campoNombre.addEventListener("input", function () {
    var valor = this.value;

    if (valor.length > 30) {
        mensajeNombre.textContent = "El nombre debe tener como m�ximo 30 letras.";
        mensajeNombre.style.display = "inline";
        validaciones.nombre = false;
    } else if (!/^[a-zA-Z\s]*$/.test(valor)) {
        mensajeNombre.textContent = "El nombre solo puede contener letras y espacios.";
        mensajeNombre.style.display = "inline";
        validaciones.nombre = false;
    } else {
        mensajeNombre.style.display = "none";
        validaciones.nombre = true;
    }

    validarFormulario();
});

campoFechaInicio.addEventListener("input", function () {
    var fechaInicio = new Date(this.value);


    if (fechaInicio <= fechaActualPeru) {
        mensajeFechaInicio.textContent = "La fecha de inicio debe ser mayor a la fecha actual.";
        mensajeFechaInicio.style.display = "inline";
        validaciones.fechaInicio = false;
    } else {
        mensajeFechaInicio.style.display = "none";
        validaciones.fechaInicio = true;
    }


    validarFechaFin();
    validarFormulario();
});

campoFechaFin.addEventListener("input", function () {

    validarFechaFin();
});

function validarFechaFin() {
    var fechaInicio = new Date(campoFechaInicio.value);
    var fechaFin = new Date(campoFechaFin.value);

    if (fechaInicio >= fechaFin) {
        mensajeFechaFin.textContent = "La fecha de fin debe ser mayor que la fecha de inicio.";
        mensajeFechaFin.style.display = "inline";
        validaciones.fechaFin = false;
    } else {
        mensajeFechaFin.style.display = "none";
        validaciones.fechaFin = true;
    }
    validarFormulario();
}


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