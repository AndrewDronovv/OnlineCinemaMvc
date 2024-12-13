const hallButtons = document.querySelectorAll('.hall-filter-btn');
hallButtons.forEach(button => {
    button.addEventListener('click', function () {
        const hallId = this.getAttribute('data-hall-id');

        axios.get('/Movies/GetAllSessions', {
            params: { HallId: hallId }
        })
            .then(response => {
                updateSessions(response.data);
            })
            .catch(error => {
                console.error('Ошибка получения сессий:', error);
            });
    });
});

const allMoviesButton = document.getElementById('btnAllMovie');
allMoviesButton.addEventListener('click', function () {
    axios
        .get('/Movies/GetAllSessions', {
            params: {
                MovieId: +document.getElementById('MovieId').value
            }
        })
        .then(response => {
            if (response.data.length > 0) {
                updateSessions(response.data[0].sessions);
            }

        })
        .catch(error => {
            console.error('Ошибка получения сессий:', error);
        });
});

function updateSessions(sessions) {
    const sessionsContainer = document.getElementById('sessions-container');
    sessionsContainer.innerHTML = '';

    sessions.forEach(session => {
        //const sessionHtml = `
        //    <div class="col-4">
        //        <div class="card mb-3">
        //            <a href="/News/GetNewsById/${session.Movie.Id}">
        //                <img src="${session.Movie.ImagePath}" class="card-img-top" alt="Some picture">
        //            </a>
        //            <div class="card-body background-card-color">
        //                <a class="card-news-text" href="/News/GetNewsById/${session.Movie.Id}">
        //                    <h5 class="card-title">${session.Movie.Name}</h5>
        //                </a>
        //                <p>${session.Description}</p>
        //                <p class="card-text"><small class="text-body-secondary">${new Date(session.DateStart).toLocaleString()}</small></p>
        //            </div>
        //        </div>
        //    </div>
        //    `;

        const sessionHtml = `
            <div class="col-4">
                <a class="btn btn-outline-primary" href="#">
                    ${new Date(session.dateStart).toLocaleString()}
                </a>
            </div>
            `;
        sessionsContainer.insertAdjacentHTML('beforeend', sessionHtml);
    });
}