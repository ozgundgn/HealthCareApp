using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Extentions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Models.Enums;

namespace HealthCareApp.ViewComponents
{
    [HtmlTargetElement("search-field")]
    public class SearchFieldTagHelper : TagHelper
    {
        public string PlaceHolder { get; set; }
        public IEnumerable<TransferType> TransferItems { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "SearchButtonTag";
            output.TagMode = TagMode.StartTagAndEndTag;
            var trasferType = new StringBuilder();
            foreach(var item in TransferItems)
            {
                trasferType.Append("<option value="+Convert.ToInt32(item)+">"+item.GetDescription()+"</option>");

            }
            var sb = new StringBuilder();
            sb.AppendFormat(@"
            <div class='row'>
              <div class='col-md-3'>
                <select name='select' id='statuType' class='form-control'>
                <option  selected value='1'>Bekliyor</option>
                <option value ='0'>İptal</option>
                <option value ='2'>Platformdan Bulundu</option>
                <option value ='3'>Başka Platformdan Bulundu </option>
                </select>
              </div>
              <div class='col-md-3'>
                 <select name='select' id='transferType' class='form-control'>
                   {1}
                 </select>
            </div>
            <div class='col-md-3'>
             <input type='text' id='search' class='form-control' placeholder='{0}'>
            </div>
            <div class='col-md-3'>
             <button type='button' id='btnSearch' class='btn btn-primary'>Ara</button>
            </div>
        </div>", this.PlaceHolder,trasferType);

            output.PreContent.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
