using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayCode2012Quiz.Helpers
{
    public static class HtmlExtension
    {
        public static IHtmlString Markdown<T>(this HtmlHelper<T> helper, string markdownText)
        {
            return helper.Raw(
                new MarkdownSharp.Markdown(loadOptionsFromConfigFile: true)
                    .Transform(markdownText)
                );
        }
    }
}