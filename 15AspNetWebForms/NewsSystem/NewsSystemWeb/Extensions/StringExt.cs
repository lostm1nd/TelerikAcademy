using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsSystemWeb.Extensions
{
    public static class StringExt
    {
        public static string TrimTo300(this string content)
        {
            if (content.Length > 300)
            {
                return content.Substring(0, 300) + "...";
            }

            return content;
        }
    }
}