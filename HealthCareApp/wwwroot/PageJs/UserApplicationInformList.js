var grid;
var donorgrid;
var donorAppId = 0; var donorUserId=0;
var UserApplicationInformList = {
    init: function () {
        UserApplicationInformList.GridGetir();
        UserApplicationInformList.EnterArama();
        UserApplicationInformList.SatateTypeChange();
        UserApplicationInformList.StatusSave();
    },
    GridGetir: function () {
        grid = $("#grid").grid({
            dataKey: "Id",
            fixedHeader: true,
            height: 500,
            columns: [
                { field: "Id", hidden: true },
                { field: "Name", title: " Adı", sortable: true },
                { field: "Surname", title: "Soy Adı" },
                { field: "ApplicationDateTime", title: "Oluşturma Tarihi", type: "date", format: 'yyyy/mm/dd' },
                { field: "Description", title: "Açıklama" },
                { field: "RelativesName", title: "Yakın Adı" },
                { field: "RelativesSurname", title: "Yakın Soyadı" },
                { field: "RelativesPhone", title: "Yakın Telefon" },
                { field: "UpdateDateTime", title: "Güncelleme Tarihi", type: "date", format: 'yyyy/mm/dd' },
                { field: "TransferTypeString", title: "Nakil Tipi" },
                { width: 70, tmpl: '<span class="material-icons md-18 gj-cursor-pointer orange600">edit</span>', align: 'center', events: { "click": UserApplicationInformList.Edit } },
                { width: 70,field:"Durum", title:"" ,tmpl: '<span class="material-icons md-18 gj-cursor-pointer blue600">edit_note</span>', align: 'center', events: { "click": UserApplicationInformList.StateUpdate } },
                { width: 70, tmpl: '<span class="material-icons md-18 gj-cursor-pointer red600">picture_as_pdf</span>', align: 'center', events: { "click": UserApplicationInformList.PdfViewer } }
            ],
            pager: { enable: true, limit: 20, sizes: [2, 5, 10, 20] }
        });

        $("#btnSearch").on("click", UserApplicationInformList.Search);
    },
    Search: function () {
        grid.reload({
            Filter: $("#search").val(),
            TransferType: $("#transferType").val(),
            Status: $("#statuType").val()
        });
    },
    Edit: function (e) {
        $.ajax({
            url: "/Application/ApplicationCreate",
                type: "POST",
                data: { basvuruId: e.data.record.Id },
                dataType: 'json'
            })
            .done(function(data) {


            });
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
                UserApplicationInformList.Search();
            }
        });
        $("#searchdonor").on('keyup', function (e) {
            if (e.key === 'Enter' || e.keyCode === 13) {
                UserApplicationInformList.SearchDonor();
            }
        });
        $("#transferType").change(function () {
            UserApplicationInformList.Search();
        });
        $("#statuType").change(function () {
            if ($("#statuType") == 1) {
                grid.showColumn('Durum');
            } else {
                grid.hideColumn('Durum');
            }
      
            UserApplicationInformList.Search();
        });
    },
    StateUpdate:function(e) {
        $('#statemodal').modal("show");
        $('#basvuruid').val(e.data.record.Id );
    },
    SatateTypeChange: function () {
        $('#statetype').change(function () {
            var id = $(this).val();
            if (id == 0) {
                $("#platform").attr("hidden", true);
                $("#buplatform").attr("hidden", true);
                $("#modalicerikiptal").removeAttr("hidden");
            }
            else if (id == 2) {
                UserApplicationInformList.PlatformTypeChange();
                $("#platform").removeAttr("hidden");
                $("#modalicerikiptal").attr("hidden", true);
            }
        });

    },
    PlatformTypeChange: function () {
        $('#platformtype').change(function () {
            var id = $(this).val();
            if (id == 3) {
                $("#buplatform").attr("hidden", true);
            }
            else if (id == 2) {
                $("#buplatform").removeAttr("hidden");
                UserApplicationInformList.DonorGridGetir();
                UserApplicationInformList.SearchDonor();
            }
        });

    },
    SearchDonor: function () {
        donorgrid.reload({
            TransferType: $("#transferType").val(),
            Filter: $("#searchdonor").val(),
            Status:1
        });
    },
    DonorGridGetir: function () {
        donorgrid = $("#donorgrid").grid({
            dataKey: "Id",
            dataSource: '/Application/GetDonorList/?TransferType=' + $("#transferType").val()+"&Status=1",
            fixedHeader: true,
            height: 250,
            selectionMethod: 'checkbox',
            selectionType: 'single',
            uiLibrary: 'materialdesign',
            columns: [
                { field: "Id", hidden: true },
                { field: "UserId", hidden: true },
                { field: "Name", title: " Adı", sortable: true },
                { field: "Surname", title: "Soy Adı" },
                { field: "Mail", title: "Mail" },
                { field: "Phone", title: "Telefon" },
                { field: "TransferTypeString", title: "TransferType" }
            ],
            pager: { enable: true, limit: 20, sizes: [2, 5, 10, 20] }

        });
        donorgrid.on('rowSelect', function (e, $row, id, record) {
            donorUserId = record.UserId;
            donorAppId = record.Id;
        });
       
    },
    StatusSave:function() {
        $('#bulundukaydet').click(function () {
            var platformType= $("#platformtype").val();
            var basvuruId = $('#basvuruid').val();
            if (platformType == 2 && donorUserId == 0) {
                alert("Lütfen Donör Seçiniz");
                return false;
            }
            var machdata = { PlatformType: platformType, AppId: basvuruId  };
            $.ajax({
                    url: "/Application/StateSave",
                    type: "POST",
                    data: machdata,
                    dataType: 'json'
                })
                .done(function (data) {
                    if (platformType == 2) {
                        var machdata = { DonorUserId: donorUserId, DonorAppId: donorAppId, UserAppId: basvuruId };
                        $.ajax({
                                url: "/Application/DonorUserMach",
                                type: "POST",
                                data: machdata,
                                dataType: 'json'
                            })
                            .done(function (data) {
                                UserApplicationInformList.ModalClose();

                            });

                    }
                    else {
                        UserApplicationInformList.ModalClose();
                    }

                });
        });
        $('#iptalkaydet').click(function () {

            if ($("#desc").val()=="") {
                alert("Lütfen Açıklama Giriniz");
                return false;
            }
            var iptaldata = { PlatFormType: 0, Description: $("#desc").val(), AppId: $('#basvuruid').val() };
            $.ajax({
                    url: "/Application/StateSave",
                    type: "POST",
                    data: iptaldata,
                    dataType: 'json'
                })
                .done(function (data) {
                    UserApplicationInformList.ModalClose();
                });

        });
    },
    ModalClose:function() {
        $('#statemodal').modal("hide");
        UserApplicationInformList.Search();
        $("#platform").attr("hidden", true);
        $("#buplatform").attr("hidden", true);
        $("#modalicerikiptal").attr("hidden", true);
        $('#statetype').val(3).change();
    },
    ModalCloseButton:function() {
        $(".closemodal").click(function() {
            UserApplicationInformList.ModalClose();
        });
    }
};

$(document).ready(function () {
    UserApplicationInformList.init();
});