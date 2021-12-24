using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HealthCareApp.ViewComponents
{
    [HtmlTargetElement("search-field")]
    public class SearchFieldTagHelper:TagHelper
    {
        public string PlaceHolder { get; set; }
        public string Id { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "SearchButtonTag";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                <div class='row'>
                    <div class='col-md-9'>
                        <input type='text' id='{0}' class='form-control' placeholder='{1}'>
                    </div>
                    <div class='col-md-3'>
                        <button type='button' id='btnSearch' class='btn btn-primary'><span class='glyphicon glyphicon-search'></span>Ara</button>
                    </div>
                </div>", this.Id,this.PlaceHolder);

            output.PreContent.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
