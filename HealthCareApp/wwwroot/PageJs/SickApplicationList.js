var grid;
var SickApplicationList = {
    init: function () {
        SickApplicationList.GridGetir();
        SickApplicationList.EnterArama();
    },
    GridGetir: function () {
        grid = $("#grid").grid({
            dataKey: "Id",
            fixedHeader: true,
            height: 500,
            columns: [
                { field: "Id", hidden: true },
                { field: "UserId", hidden:true },
                { field: "Name", title: " Adı", sortable: true },
                { field: "Surname", title: "Soyadı" },
                { field: "Mail", title: "Mail"},
                { field: "Phone", title: "Telefon"},
                { field: "TransferTypeString", title: "Nakil Tipi" },
                { width: 64, tmpl: '<span class="material-icons md-18 gj-cursor-pointer orange600">mail</span>', align: 'center', events: { "click": SickApplicationList.Mail }, tooltip: "Mail Gönder" },
                { width: 64, tmpl: '<span class="material-icons md-18 gj-cursor-pointer red600">picture_as_pdf</span>', align: 'center', events: { "click": SickApplicationList.PdfViewer }, tooltip: "Pdf Görüntüle" },
            ],
            pager: { enable: true, limit: 20, sizes: [2, 5, 10, 20] }
        });

        $("#btnSearch").on("click", SickApplicationList.Search);
    },
    Search: function () {
        grid.reload({
            Filter: $("#search").val(),
            TransferType: $("#transferType").val(),
            Status: $("#statuType").val()
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
                SickApplicationList.Search();
            }
        });
        $("#transferType").change(function() {
            SickApplicationList.Search();
        });
        $("#statuType").change(function () {
            SickApplicationList.Search();
        });
    }
};

$(document).ready(function () {
    SickApplicationList.init();
});