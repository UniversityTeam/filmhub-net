'use strict';

class Page {
  constructor(arrayOfFilms) {
    this.data = arrayOfFilms;
  }
}

let filmCatalog = new Array();

const ShowPage = page => {
  if (filmCatalog[page] === undefined) {
    return;
  }

  const catalog = document.getElementById('catalog');
  catalog.innerHTML = '';
  for (const film of filmCatalog[page].data) {
    catalog.appendChild(film);
  }

  // Set up pages pagination
  const pages = document.getElementById('pagination');
  pages.innerHTML = '';
  const activeLi = document.createElement('li');
  activeLi.className = 'active';
  let i = 0;
  const len = filmCatalog.length;

  while (i < len) {
    const li = document.createElement('li');
    if (i === page) {
      activeLi.innerHTML = `<span>${i + 1}</span>`;
      pages.appendChild(activeLi);
    } else {
      li.innerHTML = `<a onclick="ShowPage(${i})" style="cursor:pointer;">${i + 1}</a>`;
      pages.appendChild(li);
    }
    i++;
  }
};

const FilmHtml = film => `
            <a class="image-block" href="/player?id=${film.filmid}">
				<span class="year-block">${film.year}</span>
				<img src="/posters/${film.poster}" alt="${film.title}">
			</a>
			<div class="anime-column-info">
				<a class="anime-title" href="/player?id=${film.filmid}">${film.title}</a>
				<div class="icons-row">
					<div title="Количество просмотров"><i class="fa fa-eye"></i>${film.views}</div>
				</div>
			</div>
			<div class="rating-info" title=".хак//Вернувшийся">
				<span class="fa fa-star rating-star" data-id="4124" data-modal="rating-modal"></span>
				<span class="main-rating-block">
					<span class="main-rating">${film.rating}</span>
				</span>
			</div>`;

const Paginate = res => {
  let i = 0;
  let page = new Page(new Array());
  filmCatalog = new Array();
  for (const film of res) {
    if (i === 12) {
      filmCatalog.push(page);
      page = new Page(new Array());
      i = 0;
    }
    const htmlFilm = document.createElement('div');
    htmlFilm.className = 'anime-column';
    htmlFilm.innerHTML = FilmHtml(film);
    page.data.push(htmlFilm);
    i++;
  }
  if (page.data.length > 0) {
    filmCatalog.push(page);
  }
};

const Filter = event => {
  const data = new Object();
  data.genre = event.target[0].value;
  data.year_from = event.target[1].value;
  data.year_up = event.target[2].value;
  data.sort = event.target[3].value;
  const promise = makeRequest(JSON.stringify(data), 'POST', '/filter');
  promise.then(res => {
    if (res === undefined) {
      return;
    }
    res = JSON.parse(res);

    Paginate(res);
    if (filmCatalog[0] === undefined) {
      return;
    }

    // Show first page
    ShowPage(0);

  }).catch(err => console.log(err));
};

const GetTop = () => {
  const promise = makeRequest('', 'POST', '/catalog?top=""');
  promise.then(res => {
    if (res === undefined) {
      return;
    }
    res = JSON.parse(res);

    Paginate(res);
    if (filmCatalog[0] === undefined) {
      return;
    }

    // Show first page
    ShowPage(0);

  }).catch(err => console.log(err));
};

const Search = event => {
  const promise = makeRequest('', 'POST', `/catalog?word=${event.target[0].value}`);
  promise.then(res => {
    if (res === undefined) {
      return;
    }
    res = JSON.parse(res);

    Paginate(res);
    if (filmCatalog[0] === undefined) {
      return;
    }

    // Show first page
    ShowPage(0);

  }).catch(err => console.log(err));
};

const LoadRecomendations = () => {
  const promise = makeRequest('', 'POST', '/recomendations');
  promise.then(res => {
    if (res === undefined) {
      return;
    }
    res = JSON.parse(res);

    const recomendations = document.getElementById('recomendations');
    recomendations.innerHTML = '';
    for (const film of res) {
      const htmlFilm = document.createElement('div');
      htmlFilm.className = 'anime-column';
      htmlFilm.innerHTML = FilmHtml(film);
      recomendations.appendChild(htmlFilm);
    }

  }).catch(err => console.log(err));
};

const LoadCatalog = () => {
  const promise = makeRequest('{}', 'POST', '/catalog');
  promise.then(res => {
    if (res === undefined) {
      return;
    }
    res = JSON.parse(res);

    Paginate(res);
    if (filmCatalog[0] === undefined) {
      return;
    }

    // Show first page
    ShowPage(0);

  }).catch(err => console.log(err));

  const promise_genres = makeRequest('{}', 'POST', '/genres');
  promise_genres.then(genres => {
    if (genres === undefined) {
      return;
    }
    genres = JSON.parse(genres);
    const selecttag = document.getElementById('selected_category');
    selecttag.innerHTML = '';
    let i = 1;
    for (const genre of genres) {
      const option = document.createElement('option');
      option.value = `${i}`;
      option.innerHTML = genre.lable;
      selecttag.appendChild(option);
      i++;
    }
  });
};

const LoadRecoms = async () => {
  const promise = makeRequest('{}', 'POST', '/islogin');
  promise.then(res => {
    if (res === 'true') {
      LoadRecomendations();
    }
  }).catch(err => console.log(err));
};

const rand = () => {
  const promise = makeRequest('', 'POST', '/random');
  promise.then(res => {
    if (res === undefined) {
      return;
    }

    window.location.href = `/player?id=${res}`;

  }).catch(err => console.log(err));

};
