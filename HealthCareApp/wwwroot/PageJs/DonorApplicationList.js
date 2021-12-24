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
                { width: 64, tmpl: '<span class="material-icons md-18 gj-cursor-pointer orange600">mail</span>', align: 'center', events: { "click": DonorApplicationList.Mail } },
                { width: 64, tmpl: '<span class="material-icons md-18 gj-cursor-pointer red600">picture_as_pdf</span>', align: 'center', events: { "click": DonorApplicationList.PdfViewer } },
            ],
            pager: { enable: true, limit: 20, sizes: [2, 5, 10, 20] }
        });

        $("#btnSearch").on("click", DonorApplicationList.Search);
    },
    Search: function () {
        grid.reload({
            Filter: $("#search").val(),
            TransferType: $("#transferType").val()
        });
    },
    Mail: function (e) {
        $(".modal-body #id").val(e.data.record.Id);
        $(".modal-body label.mail-to").html(e.data.record.Name + " " + e.data.record.Surname);
        $("#mailModal").modal("show");
    },
    PdfViewer: function (e) {
        $.ajax({
                url: "/Application/AppFileView",
                type: "POST",
                data: { id: e.data.record.Id },
                dataType: 'json'
            })
            .done(function (data) {
                console.log(data);
                $("#modalicerik").html("");
                $("#modalicerik").html("<div'><iframe src='" + data.Object + "' frameborder='0' scrolling='auto' max-height='800' height='700' width='750'></iframe></div>");
                $('#filemodal').modal("show");
            })
            .fail(function () {
            });

    },
    EnterArama: function () {
        $("#search").on('keyup', function (e) {
            if (e.key === 'Enter' || e.keyCode === 13) {
                DonorApplicationList.Search();
            }
        });
        $("#transferType").change(function() {
            DonorApplicationList.Search();
        });
    }
};

$(document).ready(function () {
    DonorApplicationList.init();
});