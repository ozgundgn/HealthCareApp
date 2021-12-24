var grid;
var DonorApplicationList = {
    init: function () {
        DonorApplicationList.GridGetir();
        DonorApplicationList.EnterArama();
    },
    GridGetir: function () {
        grid = $("#grid").grid({
            dataKey: "Id",
            //uiLibrary: "bootstrap4",
            dataSource: '/Application/GetDonorList',
            fixedHeader: true,
            height: 500,
            columns: [
                { field: "Id", hidden: true },
                { field: "UserId", hidden:true },
                { field: "name", title: " Adı", sortable: true },
                { field: "surname", title: "Soy Adı" },
                { field: "Mail", title: "Mail"},
                { field: "Phone", title: "Telefon"},
                { field: "TransferType", title: "TransferType" }
                /*{ title: "vvv", field: "Edit", width: 35, tooltip: "Mail Gönder", events: { "click": DonorApplicationList.Edit } }*/
            ],
            pager: { enable: true, limit: 20, sizes: [2, 5, 10, 20] }
        });

        $("#btnSearch").on("click", DonorApplicationList.Search);
    },
    Search: function () {
        grid.reload({
            Name: $("#search").val()
        });
    },
    Edit: function (e) {
        $(".modal-body #id").val(e.data.record.Id);
        $(".modal-body label.mail-to").append(e.data.record.UserId + " " + e.data.record.Surname);
        $("#mailModal").modal("show");
    },
    EnterArama: function () {
        $(".nameara").on('keyup', function (e) {
            if (e.key === 'Enter' || e.keyCode === 13) {
                DonorApplicationList.Search();
            }
        });
    }
};

$(document).ready(function () {
    DonorApplicationList.init();
});