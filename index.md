@using Repository.Helpers
@using Models.Enums
@using Core.Extentions
@model List<Models.Application.DonorApplicationListModel>
@{
    <style>
        .modal-backdrop {
            display: none !important;
        }
    </style>

    <div class="col-lg-12">
        <div class="main-card mb-3 card">

            <div class="card-header">
                <input id="myInput" type="text" placeholder="Search..">
            </div>
            <div class="card-body">
                <h5 class="card-title">Donör Listesi</h5>
                <table id="donorAppTable" class="mb-0 table table-hover">
                    <thead>
                    <tr>
                        <th>Adı</th>
                        <th>Soyadı</th>
                        <th>Telefon</th>
                        <th>Mail</th>
                        <th>Nakil Tipi</th>
                        @{
                            if (SessionHelper.DefaultSession.Id != 0)
                            {
                                <th>Donöre Mail Gönder</th>
                            }
                        }
                    </tr>
                    </thead>
                    <tbody>
                    @foreach (var item in Model)
                    {
                        <tr>
                            <th scope="row">@item.Name</th>
                            <td>@item.Surname</td>
                            <td>@item.Phone</td>
                            <td>@item.Mail</td>
                            <td>@(((TransferType) item.TransferType).GetDescription())</td>
                            @{
                                if (SessionHelper.DefaultSession.Id != 0)
                                {
                                    <td><button type="button" onclick="openMailModal(@item.UserId, '@item.Name' + ' ' + '@item.Surname')"><i class="pe-7s-mail-open-file"></i></button></td>
                                }
                            }
                        </tr>
                    }
                    </tbody>
                </table>
            </div>
        </div>
    </div>

}
<!-- Modal -->
<div class="modal fade" id="mailModal" style="margin-top: 10%;" tabindex="-1" role="dialog" aria-labelledby="mailModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <form method="post" enctype="multipart/form-data" asp-controller="Home" asp-action="SendMail">
                <div class="modal-body">
                    <input type="hidden" name="id" id="id" />
                    <input type="hidden" name="donorPage" value="true" id="donorPage" />
                    <label class="col-form-label-lg mail-to"></label><br />
                    <label for="message"><b>Mesaj</b></label>
                    <textarea id="w3review" class="form-control" name="message" rows="4" required>
                    </textarea>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary btn-shadow p-2">Gönder</button>
                    <button type="button" class="btn btn-danger btn-shadow p-2" data-dismiss="modal">Kapat</button>
                </div>
            </form>
        </div>
    </div>
</div>

<script>
    function openMailModal(donorId, donorName) {

        $(".modal-body #id").val(donorId);
        $(".modal-body label.mail-to").html(donorName);
        $("#mailModal").modal("show");
    }

    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#donorAppTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
</script>