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
        public string Text { get; set; }
        public string Id { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "SearchButtonTag";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat(@"<div class='form-group search-form'><div class='form-control card-header'><input id ='{0}' type='text' placeholder='{1}'></div></div>", this.Id,this.Text);

            output.PreContent.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
