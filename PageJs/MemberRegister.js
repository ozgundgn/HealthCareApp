var grid;
var MemberRegister = {
    init: function () {
        MemberRegister.DistrictList();
    },
    DistrictList: function () {
		$('#CityId').change(function () {
            var id = $(this).val();
            var ilceid = $("#DistrictId");
            ilceid.empty();
            $.ajax({
                url: 'DistrictList',
                type: 'POST',
                dataType: 'json',
                data: { 'id': id },
                success: function (data) {
                    $.each(data.Object,
                        function (index, option) {
                            ilceid.append('<option value=' + option.id + '>' + option.districtName + '</option>');
                        });
                }
            });
        });
    }
};
$(document).ready(function () {
    MemberRegister.init();
});