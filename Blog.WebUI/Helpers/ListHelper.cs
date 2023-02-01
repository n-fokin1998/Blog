using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Helpers
{
    /// <summary>
    /// HTML-helper for ul list.
    /// </summary>
    public static class ListHelper
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, string[] items, string type, string name)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                TagBuilder input = new TagBuilder("input");
                input.MergeAttribute("type", type);
                input.MergeAttribute("name", name);
                input.MergeAttribute("value", item);
                input.MergeAttribute("id", item.GetHashCode().ToString());
                TagBuilder label = new TagBuilder("label");
                label.MergeAttribute("for", item.GetHashCode().ToString());
                label.SetInnerText(item.ToString());
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml += input.ToString(TagRenderMode.SelfClosing);
                li.InnerHtml += label.ToString();
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}