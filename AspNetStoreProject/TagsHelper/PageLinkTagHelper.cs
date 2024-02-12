using AspNetStoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetStoreProject.TagsHelper
{

	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PageLinkTagHelper : TagHelper
	{
		private IUrlHelperFactory _urlHelperFactory;

		public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
		{
			_urlHelperFactory = urlHelperFactory;
		}

		[ViewContext]
		public ViewContext? ViewContext { get; set; }
		public PagingInfo? PageModel { get; set; }
		public string? PageAction { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (ViewContext != null && PageModel != null)
			{
				IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

				var result = new TagBuilder("div");

				for (int i = 1; i <= PageModel.TotalPages(); i++)
				{
					var tag = new TagBuilder("a");

					tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageProduct = i });
					tag.InnerHtml.Append(i.ToString());
					result.InnerHtml.AppendHtml(tag);

				}

				output.Content.AppendHtml(result.InnerHtml);
			}




		}

	}

}
