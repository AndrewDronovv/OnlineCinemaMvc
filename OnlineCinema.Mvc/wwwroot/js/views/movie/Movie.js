//* Функция получения всех сеансов */
const getAllSessions = (input) => {
    return axios.get('/Movies/GetAllSessions', {
        params: input
    })
        .then(response => response.data)
        .catch(error => {
            console.error('Ошибка получения сессий:', error);
        });
};

/* Функция для обработки результата и обновления сеансов */
const handleSessionsUpdate = (input) => {
    getAllSessions(input)
        .then((movies) => {
            if (!movies || movies.length === 0) {
                updateSessions([]);
                return;
            }
            const movie = movies[0];
            updateSessions(movie.sessions);
        });
};

/* Начальная загрузка сеансов */
document.addEventListener('DOMContentLoaded', () => {
    const movieIdElement = document.getElementById('MovieId');
    if (movieIdElement) {
        handleSessionsUpdate({
            movieId: +movieIdElement.value,
            date: dayjs().format('DD.MM.YYYY')
        });
    }

    /* Кнопка для всех видов холлов */
    const allHallButton = document.getElementById('btnAllHalls');
    if (allHallButton) {
        allHallButton.addEventListener('click', function () {
            const hallButtons = document.querySelectorAll('.hall__other__btn');
            hallButtons.forEach(btn => btn.classList.remove('active'));
            this.classList.add('active');

            handleSessionsUpdate({
                movieId: +movieIdElement.value,
                date: document.querySelector('.movie__session__btn.active')?.getAttribute('data-date')
            });
        });
    }

    /* Обработчики для кнопок залов */
    const hallButtons = document.querySelectorAll('.hall__other__btn');
    hallButtons.forEach(button => {
        button.addEventListener('click', function () {
            hallButtons.forEach(btn => btn.classList.remove('active'));
            document.getElementById('btnAllHalls').classList.remove('active');
            this.classList.add('active');

            handleSessionsUpdate({
                movieId: +movieIdElement.value,
                hallId: this.getAttribute('data-hall-id'),
                date: document.querySelector('.movie__session__btn.active')?.getAttribute('data-date')
            });
        });
    });

    /* Обработчики событий для кнопок фильтрации сессий */
    const sessionFilterButtons = document.querySelectorAll('.movie__session__btn');
    sessionFilterButtons.forEach(button => {
        button.addEventListener('click', function () {
            sessionFilterButtons.forEach(btn => btn.classList.remove('active'));
            this.classList.add('active');

            const hallId = document.querySelector('.hall__other__btn.active')?.getAttribute('data-hall-id');

            handleSessionsUpdate({
                movieId: +movieIdElement.value,
                date: this.getAttribute('data-date'),
                hallId: hallId
            });
        });
    });
});

/* Отрисовка сессий фильма и вида зала */
function updateSessions(sessions) {
    const sessionsContainer = document.getElementById('sessions-container');
    sessionsContainer.innerHTML = '';

    sessions.forEach(session => {
        const movieTime = dayjs(session.dateStart).format('HH:mm');
        const movieHall = session.hall.name;

        /* Отрисовка кнопок сессий и видов зала */
        const sessionHtml = `
            <div class="col-1 ms-2">
                <a class="btn btn-outline-primary btn-session-time" href="#">
                    ${movieTime}
                </a>
                <div class="movie-info ms-2">
                    <p>${movieHall ? movieHall : 'Unknown Hall'}</p>
                </div>
            </div>
        `;
        sessionsContainer.insertAdjacentHTML('beforeend', sessionHtml);
    });
}