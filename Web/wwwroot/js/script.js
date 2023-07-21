const searchcontainer = document.querySelector('.buscar')
const inputsearch = searchcontainer.querySelector('input')
const boxsugerencias = document.querySelector('.listaPadres')

inputsearch.onkeyup = e => {
    let userdata = e.target.value;
    let emptyArray = [];
    if (userdata) {
        emptyArray = suggestions.filter(data => {
            return data
                .toLocaleLowerCase()
                .startsWith(userdata.toLocaleLowerCase());

        });
        emptyArray = emptyArray.map(data => {
            return (data = `<li>${data}</li>`);
        });
        searchcontainer.classList.add('active')
        mostrarpadres(emptyArray);


        let allList = boxsugerencias.querySelectorAll('li');

        allList.forEach(li => {
            li.setAttribute('onclick', 'select(this)');
        });
    } else {
        searchcontainer.classList.remove('active');
    }
};

function select(element) {
    let selectUserData = element.textContent;
    inputsearch.value = selectUserData;
    searchcontainer.classList.remove('active');
}


const mostrarpadres = list => {
    let listData;

    if (!list.length) {

        //muestra el mismo valor que estaba buscando..
        //userValue = inputsearch.value;
        //listData = `<li>${userValue}</li>`;
        listData = `<li>"coincidencia no encontrada"</li>`;
    } else {
        listData = list.join(' ');
    }

    boxsugerencias.innerHTML = listData;
}


