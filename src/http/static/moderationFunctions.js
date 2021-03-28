'use strict';

const modal = document.querySelector('modal');
const overlay = document.querySelector('overlay');

overlay.addEventListener('click', () => {
  modal.classList.remove('active');
  overlay.classList.remove('active');
  document.querySelector('table') ? document.querySelector('table').remove() : 0;
  document.querySelector('.filmForm') ? document.querySelector('.filmForm').remove() : 0;
});

async function removeFilm(id) {
  await makeRequest(JSON.stringify({ id }), 'POST', '/removeFilm');
  document.querySelector(`#film_${id}`).remove();

}

function showFilms() {
  makeRequest('', 'POST', '/showFilms').then(res => {
    const data = JSON.parse(res);
    const tableHead = `
                <thead>
                    <tr>
                        <th>ID фильма</th>
                        <th>Название</th>
                        <th>Год</th>
                        <th>Рейтинг</th>
                        <th>Просмотры</th>
                        <th>Постер</th>
                        <th>Жанр</th>
                        <th>Премиум</th>
                        <th>Ссылка</th>
                        <th></th>
                    </tr>
                </thead>`;

    let tableBody = '';
    for (let i = 0; i < data.length; i++) {
      const id = data[i].filmid;
      tableBody += `
                <tr id="film_${id}">
                    <td>${id}</td>
                    <td>${data[i].title}</td>
                    <td>${data[i].year}</td>
                    <td>${data[i].rating}</td>
                    <td>${data[i].views}</td>
                    <td>${data[i].poster}</td>
                    <td>${data[i].genre}</td>
                    <td>${data[i].free}</td>
                    <td>${data[i].url}</td>
                    <td class="removeBtn" onclick="removeFilm(${id})">X</td>
                </tr>`;
    }

    const table = document.createElement('table');
    table.innerHTML += tableHead + tableBody;

    modal.appendChild(table);
    modal.classList.add('active');
    overlay.classList.add('active');
  });
}

async function addFilm() {
  const genres = [];

  await makeRequest('', 'POST', '/genres').then(res => {
    res = JSON.parse(res);
    res.map(element => {
      genres.push(element['lable']);
    });
  });

  let options = '';

  for (let i = 0; i < genres.length; i++) {
    options += `<option>${genres[i]}</option>`;
  }

  const filmForm = document.createElement('div');
  filmForm.className = 'filmForm';
  filmForm.innerHTML = `
        <form action="/addFilm" method="post" enctype="multipart/form-data" target="dummy">
            <div class="container">
                <h1>Добавить фильм</h1>
                <hr>
                <label for="title"><b>Название</b></label>
                <input type="text" placeholder="" name="title" class="ins" required>
    
                <label for="year"><b>Год выпуска</b></label>
                <input type="number" placeholder="" name="year" class="ins" required>
                
                <select name="genre" class="select-css" >
                    <option value="" selected disabled hidden>Жанр</option>
                    ${options}
                </select>
                
                <label for="poster"><b>\nПостер</b></label>
                <input type="file"  name="poster" class="ins" required>
                
                <label for="url"><b>Фильм</b></label>
                <input type="file"  name="url" class="ins" required>
                
                <label class="checkbox-inline" for="free">
                    <input type="checkbox" id="inlineCheckbox2" name="free"> Бесплатный просмотр?
                </label>
               
 
                <button type="submit" class="addBtn">Добавить фильм</button>
            </div>
        </form>`;

  modal.appendChild(filmForm);
  modal.classList.add('active');
  overlay.classList.add('active');
}

async function approveComment(id) {
  await makeRequest(JSON.stringify({ id }), 'POST', '/approveComment')
  const el = document.querySelector(`#approveBtn_${id}`);
  el.style.color = 'green';
  el.onclick = '';
  el.innerHTML = 'Подтвержден';

}

async function removeComment(id) {
  await makeRequest(JSON.stringify({ id }), 'POST', '/removeComment')
  document.querySelector(`#comment_${id}`).remove();

}

function showComments() {
  makeRequest('', 'POST', '/showComments').then(res => {
    const data = JSON.parse(res);
    const tableHead = `
                <thead>
                    <tr>
                        <th>ID комментария</th>
                        <th>ID фильма</th>
                        <th>ID пользователя</th>
                        <th>Комментарий</th>
                        <th>Подтвержден</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>`;

    let tableBody = '';
    for (let i = 0; i < data.length; i++) {
      const id = data[i].commentid;

      let approved = '';

      if (data[i].approved) {
        approved = '<td style="color:green;">Подтвержден</td>';
      } else {
        approved = `<td class="approveBtn" id="approveBtn_${id}" onclick="approveComment(${id})">Подтвердить</td>`;

      }

      tableBody += `
                <tr id="comment_${id}">
                    <td>${id}</td>
                    <td>${data[i].filmid}</td>
                    <td>${data[i].userid}</td>
                    <td>${data[i].textdata}</td>
                    <td>${data[i].approved}</td>
                    ${approved}
                    <td class="removeBtn" onclick="removeComment(${id})">X</td>
                </tr>`;
    }

    const table = document.createElement('table');
    table.innerHTML += tableHead + tableBody;

    modal.appendChild(table);
    modal.classList.add('active');
    overlay.classList.add('active');
  });
}
