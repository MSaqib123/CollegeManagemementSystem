using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace CMS.Data
{
    [HtmlTargetElement("*", Attributes = "asp-display-for")]
    public class DisplayForTagHelper : TagHelper
    {
        //private const string ForAttributeName = "asp-for";

        [HtmlAttributeName("asp-display-for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var text = For.ModelExplorer.GetSimpleDisplayText();

            output.Content.SetContent(text);
        }

    }
}
