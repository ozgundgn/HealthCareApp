var grid;
var DonorApplicationList = {
    init: function () {
        DonorApplicationList.GridGetir();
        DonorApplicationList.EnterArama();
    },
    GridGetir: function () {
        grid = $("#grid").grid({
            dataKey: "Id",
            dataSource: '/Application/GetDonorList',
            fixedHeader: true,
            height: 500,
            columns: [
                { field: "Id", hidden: true },
                { field: "UserId", hidden:true },
                { field: "Name", title: " Adı", sortable: true },
                { field: "Surname", title: "Soy Adı" },
                { field: "Mail", title: "Mail"},
                { field: "Phone", title: "Telefon"},
                { field: "TransferTypeString", title: "TransferType" },
                { width: 64, tmpl: '<span class="material-icons md-18 gj-cursor-pointer">edit</span>', align: 'center', events: { "click": DonorApplicationList.Edit } },
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
        $(".modal-body label.mail-to").html(e.data.record.Name + " " + e.data.record.Surname);
        $("#mailModal").modal("show");
    },
    EnterArama: function () {
        $("#search").on('keyup', function (e) {
            if (e.key === 'Enter' || e.keyCode === 13) {
                DonorApplicationList.Search();
            }
        });
    }
};

$(document).ready(function () {
    DonorApplicationList.init();
});