const getGenres = (filters) => {
    return axios.post('/admin/genres/getAll',
        filters,
    )
        .then(function (response) {
            return response.data;
        })
        .catch(function (error) {
            console.log(error);
        });
}

let table = new DataTable('#GenresTable', {
    serverSide: true,
    ajax: async (request, drawCallback, settings) => {
        const maxCountOnPage = request.length;
        const skipCount = request.start;

        filter.maxCountOnPage = maxCountOnPage;
        filter.skipCount = skipCount;

        const result = await getGenres(filter);

        drawCallback({
            recordsTotal: result.totalCount,
            recordsFiltered: result.totalCount,
            data: result.items
        })
    },
    columns: [
        { data: 'name', orderable: false },
        {
            data: null, orderable: false, render: function (data, type, row, meta) {
                return `<div class="d-flex"> 
                            <span data-toggle="tooltip" data-title="Изменить">
                                <button class="btn btn-sm text-secondary edit" data-id="${row.id}" data-toggle="modal" data-target="#UserEditModal">
                                    <i class="fas fa-pencil-alt"></i>
                                </button>
                            </span>
                            <span data-toggle="tooltip" data-title="Удалить">
                                <button class="btn btn-sm text-danger delete" data-id="${row.id}" data-user-name="${row.userName}">
                                    <i class="fas fa-trash"></i>
                                </button>
                            </span>
                        </div>`;
            }
        }
    ],
    order: [[1, 'asc']],
    drawCallback: (e, settings) => {
        const tooltipTriggerList = document.querySelectorAll('[data-toggle="tooltip"]');
        tooltipTriggerList.forEach(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl, { trigger: "hover" }));
    }
});
