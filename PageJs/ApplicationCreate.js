var grid;
var ApplicationCreate = {
    init: function () {
        ApplicationCreate.Save();
    },

    Save: function () {
        $("#kaydet").click(function () {

            var data = [];
            $("table > tbody > tr").each(function (key) {
                var questionId = $(this).find('td').eq(0).text();

                data.push({ Id: $('input[name="hidden+' + questionId + '"]').val(), QuestionId: $(this).find('td').eq(0).text(), QuestionResult: $('input[name="radio+' + questionId + '"]:checked').val() });
            });
            if ($("#transfertype").val() == 0) {
                notif({
                    type: "error",
                    msg: "Lütfen Nakil Tipi Seçiniz",
                    width: 300,
                    height: 20,
                    position: "center"
                });
                return false;
            }
            if ($("#relativesname").val() == "") {
                notif({
                    type: "error",
                    msg: "Lütfen Yakın Adı Giriniz",
                    width: 300,
                    height: 20,
                    position: "center"
                });
                return false;
            }
            if ($("#relativessurname").val() == "") {
                notif({
                    type: "error",
                    msg: "Lütfen Yakın Soyadı Giriniz",
                    width: 300,
                    height: 20,
                    position: "center"
                });
                return false;
            }
            if ($("#relativesphone").val() == "") {
                notif({
                    type: "error",
                    msg: "Lütfen Yakın Telefonu Giriniz..",
                    width: 300,
                    height: 20,
                    position: "center"
                });
                return false;
            }


            var myfile = $('#reportfile').get(0).files[0];
            var formData = new FormData();
            formData.append('ReportResult', myfile);
            formData.append('TransferType', $("#transfertype").val());
            formData.append('RelativesName', $("#relativesname").val());
            formData.append('RelativesSurname', $("#relativessurname").val());
            formData.append('RelativesPhone', $("#relativesphone").val());
            formData.append('SickDate', $("#sickdate").val());
            formData.append('SickDesc', $("#sickdesc").val());
            formData.append('QuestionResultListString', JSON.stringify(data));
            formData.append('Id', $("#basvuruid").val());
            formData.append('SicknessDetailId', $("#sicknessdetailid").val());
            console.log(formData);
            $.ajax({
                    url: "/Application/ApplicationSave",
                    type: "POST",
                    data: formData,
                    processData: false,
                    contentType: false
                })
                .done(function (data) {
                    notif({
                        type: "error",
                        msg: data.message,
                        width: 300,
                        height: 20,
                        position: "center"
                    });
                })
                .fail(function () {
                });
        });
    }

};

$(document).ready(function () {
    ApplicationCreate.init();
});