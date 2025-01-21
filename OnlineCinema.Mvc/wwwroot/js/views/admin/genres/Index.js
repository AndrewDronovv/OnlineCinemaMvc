const getGenres = filters => {
    return axios.post("/admin/genres/getAll", filters)
        .then(function (response) {
            return response.data;
        })
        .catch(function (error) {
            console.log(error);
        });
};


const deleteGenre = (genreId) => {
    return axios.delete('/admin/genres/delete?id=' + genreId,
    )
        .then(function (response) {
            table.ajax.reload();
        })
        .catch(function (error) {
            console.log(error);
        });
}


const onDelete = (btn) => {
    const id = +btn.dataset.id;
    const name = btn.dataset.name;
    Swal.fire({
        title: "Вы уверены?",
        text: `Жанр "${name}" будет удален!`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "Нет",
        confirmButtonText: "Удалить"
    }).then((result) => {
        if (!result.isConfirmed) {
            return;
        }

        deleteGenre(id);
    });
}


const updateGenre = (updatedData) => {
    return axios.put('/admin/genres/update', updatedData, {
    })
        .then(function (response) {
            return response.data;
        })
        .catch(function (error) {
            console.log(error);
        })
}


document.addEventListener('click', (event) => {
    const target = event.target;
    if (target.closest('.edit')) {
        event.preventDefault();

        const genreId = +target.closest('.edit').dataset.id;
        const genreNameInput = document.getElementById("GenreName");

        const editModal = new bootstrap.Modal("#GenreEditModal");
        editModal.show();

        genreNameInput.value = target.closest(".edit").dataset.name;

        document.getElementById("SaveGenreBtn").addEventListener("click", saveHandler);

        function saveHandler() {
            const genreName = genreNameInput.value;

            const updatedData = {
                id: genreId,
                name: genreName
            }
            updateGenre(updatedData)
                .then(data => {
                    editModal.hide();
                    table.ajax.reload();
                })
        }
    }
});


document.addEventListener('click', (event) => {
    const target = event.target;
    if (target.closest('.delete')) {
        event.preventDefault();
        onDelete(target.closest('.delete'));

    }
})


let table = new DataTable("#GenresTable", {
    serverSide: true,
    ajax: async (request, drawCallback, settings) => {
        const pageSize = request.length;
        const skipCount = request.start;
        let filter = {};

        filter.pageSize = pageSize;
        filter.skipCount = skipCount;

        const result = await getGenres(filter);

        drawCallback({
            recordsTotal: result.totalCount,
            recordsFiltered: result.totalCount,
            data: result.items
        })
    },
    columns: [
        { data: "name", orderable: false },
        {
            data: null, orderable: false, render: function (data, type, row, meta) {
                return `<div class="d-flex"> 
                            <span data-toggle="tooltip" data-title="Изменить">
                                <button class="btn btn-sm text-secondary edit" data-id="${row.id}" data-toggle="modal" data-target="#GenreEditModal">
                                    <i class="fas fa-pencil-alt"></i>
                                </button>
                            </span>
                            <span data-toggle="tooltip" data-title="Удалить">
                                <button class="btn btn-sm text-danger delete" data-id="${row.id}" data-name="${row.name}">
                                    <i class="fas fa-trash"></i>
                                </button>
                            </span>
                        </div>`;
            }
        }
    ],
    order: [[1, "asc"]],
    drawCallback: (e, settings) => {
        const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
        tooltipTriggerList.forEach(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl, { trigger: "hover" }));
    }
});


