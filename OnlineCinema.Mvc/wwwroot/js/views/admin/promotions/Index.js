const getPromotions = filters => axios.post("/admin/promotions/getAll", filters)
    .then(response => response.data)
    .catch(console.error);

const getPromotionById = promotionId => axios.get(`/admin/promotions/get?id=${promotionId}`)
    .then(response => response.data)
    .catch(console.error);

const deletePromotion = promotionId => axios.delete("/admin/promotions/delete?id=" + promotionId)
    .then(() => table.ajax.reload())
    .catch(console.error);

const updatePromotion = updatedData => axios.put("/admin/promotions/update", updatedData)
    .then(response => response.data)
    .catch(console.error);

const onDelete = btn => {
    const id = +btn.dataset.id;
    const name = btn.dataset.name;
    Swal.fire({
        title: "Вы уверены?",
        text: `Акция "${name}" будет удалена!`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "Нет",
        confirmButtonText: "Удалить"
    }).then((result) => {
        if (result.isConfirmed) {
            deletePromotion(id);
        }
    });
};

document.addEventListener("click", (event) => {
    const target = event.target;
    if (target.closest(".edit")) {
        event.preventDefault();

        const promotionId = +target.closest(".edit").dataset.id;
        const promotionNameInput = document.getElementById("EditPromotionName");
        const promotionDescInput = document.getElementById("EditPromotionDesc");
        const promotionImageInput = document.getElementById("EditPromotionImage");
        const promotionDateInput = document.getElementById("EditPromotionDate");
        const promotionMethodInput = document.getElementById("EditPromotionMethodName");
        const promotionBtnInput = document.getElementById("EditPromotionBtnName");
        const promotionUrlInput = document.getElementById("EditPromotionUrl");

        const editModal = new bootstrap.Modal(document.getElementById("PromotionEditModal"));

        editModal.show();

        getPromotionById(promotionId)
            .then(promotion => {
                promotionNameInput.value = promotion.displayName;
                promotionDescInput.value = promotion.description;
                promotionImageInput.value = promotion.imagePath;
                promotionDateInput.value = promotion.dateTime;
                promotionMethodInput.value = promotion.name;
                promotionBtnInput.value = promotion.buttonText;
                promotionUrlInput.value = promotion.link;

                document.getElementById("EditSavePromotionBtn").removeEventListener("click", saveHandler);
                document.getElementById("EditSavePromotionBtn").addEventListener("click", saveHandler);

                function saveHandler() {
                    const promotionName = promotionNameInput.value;
                    const promotionDesc = promotionDescInput.value;
                    const promotionImage = promotionImageInput.value;
                    const promotionDate = promotionDateInput.value;
                    const promotionMethod = promotionMethodInput.value;
                    const promotionBtn = promotionBtnInput.value;
                    const promotionUrl = promotionUrlInput.value;

                    const updatedData = {
                        id: promotionId,
                        name: promotionMethod,
                        displayname: promotionName,
                        description: promotionDesc,
                        imagepath: promotionImage,
                        datetime: promotionDate,
                        buttontext: promotionBtn,
                        link: promotionUrl
                    }
                    updatePromotion(updatedData)
                        .then(data => {
                            editModal.hide();
                            table.ajax.reload();
                        });
                }
            })
            .catch(console.error);
    }
    else if (target.closest(".delete")) {
        event.preventDefault();
        onDelete(target.closest(".delete"));
    };
});

let table = new DataTable("#PromotionsTable", {
    serverSide: true,
    ajax: async (request, drawCallback, settings) => {
        const pageSize = request.length;
        const skipCount = request.start;
        let filter = {};

        filter.pageSize = pageSize;
        filter.skipCount = skipCount;

        const result = await getPromotions(filter);

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
                                <button class="btn btn-sm text-secondary edit" data-id="${row.id}" data-toggle="modal" data-target="#PromotionEditModal">
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
