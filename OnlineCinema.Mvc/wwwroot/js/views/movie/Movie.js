const getAllSessions = (input) => {
    return axios.get('/Movies/GetAllSessions', {
        params: input
    })
        .then(response => {
            return response.data;
        })
        .catch(error => {
            console.error('Ошибка получения сессий:', error);
        });
};

getAllSessions({
    movieId: +document.getElementById('MovieId').value,
    date: new Date()
})
    .then((movies) => {
        if (!movies || movies.length == 0) {
            return;
        }
        const movie = movies[0];
        updateSessions(movie.sessions);
    });


//Все остальные кнопки, которые отвечают за виды холлов
//const hallButtons = document.querySelectorAll('.btn-hall-other');
//hallButtons.forEach(button => {
//    button.addEventListener('click', function () {
//        const hallId = this.getAttribute('data-hall-id');

//        getAllSessions({
//            movieId: +document.getElementById('MovieId').value,
//            hallId: hallid,
//            //date: new Date()
//        })
//            .then((movies) => {
//                if (!movies || movies.length == 0) {
//                    return;
//                }
//                const movie = movies[0];
//                updateSessions(movie.sessions);
//            });
//    });
//});

//Кнопка, которая отвечает за все виды холлов
const allHallButtons = document.getElementById('btnAllHalls');
allHallButtons.addEventListener('click', function () {
    getAllSessions({
        movieId: +document.getElementById('MovieId').value,
        date: new Date()
    })
        .then((movies) => {
            if (!movies || movies.length == 0) {
                return;
            }
            const movie = movies[0];
            updateSessions(movie.sessions);
        });
});

//Отрисовка сессий фильма и вида зала
function updateSessions(sessions) {
    const sessionsContainer = document.getElementById('sessions-container');
    sessionsContainer.innerHTML = '';

    sessions.forEach(session => {
        const movieTime = dayjs(session.dateStart).format('HH:mm');
        const movieHall = session.hall.name;

        // Отрисовка кнопок сессий и видов зала
        const sessionHtml = `
            <div class="col-1 ms-2">
                <a class="btn btn-outline-primary" href="#">
                    ${movieTime}
                </a>
                <div class="movie-info ms-2">
                    <p>${movieHall ? movieHall : 'Unknown Hall'}</p>
                </div>
            </div>
        `;
        sessionsContainer.insertAdjacentHTML('beforeend', sessionHtml);
    });

    const sessionButtons = document.querySelectorAll('.btn-movie-session');
    sessionButtons.forEach(button => {
        button.addEventListener('click', function () {
            sessionButtons.forEach(btn => btn.classList.remove('active'));

            this.classList.add('active');
        })
    })
}