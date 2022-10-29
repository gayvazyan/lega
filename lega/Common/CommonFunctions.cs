using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lega.Common
{
    public class CommonFunctions
    {
        public static string Filter(string str)
        {
            char[] removeChar = { ' ', '(', ')' };
            foreach (var c in removeChar)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }
            return str;
        }
        
        public static string GetArmenianDateString(DateTime electionDay)
        {
            CultureInfo culture = new CultureInfo("hy-AM");

            return electionDay.Year + " թվականի " + electionDay.ToString("MMMM", culture) + "ի " + electionDay.Day + "`";
        }

        public static string GetDateString(DateTime? day)
        {
            if (day != null)
            {
                CultureInfo culture = new CultureInfo("hy-AM");

                DateTime noNullDay = (DateTime)day;

                return noNullDay.Day + " " + noNullDay.ToString("MMMM", culture) + ", " + noNullDay.Year;
            }
            else
            {
                return "";
            }

        }
        public static string GetEngDateString(DateTime? day)
        {
            if (day != null)
            {
                CultureInfo culture = new CultureInfo("en-EN");

                DateTime noNullDay = (DateTime)day;

                return noNullDay.Day + " " + noNullDay.ToString("MMMM", culture) + ", " + noNullDay.Year;
            }
            else
            {
                return "";
            }

        }

        public static string GetVODFileNameFromURL(string url)
        {
            string file = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                int firstStringPosition; ;
                int secondStringPosition;
                if (url.StartsWith("http"))
                {
                    firstStringPosition = url.IndexOf("/vod/mp4:") + "/vod/mp4:".Length;
                    secondStringPosition = url.IndexOf("/playlist.m3u8");
                    file = url.Substring(firstStringPosition, secondStringPosition - firstStringPosition);
                }
                else
                {
                    firstStringPosition = url.IndexOf("/vod/") + "/vod/".Length;
                    file = url.Substring(firstStringPosition);
                }
            }
            return file;
        }
        public static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        public static string GetIPAddress()
        {
            var strHostName = Dns.GetHostName();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            return address[1].ToString();
        }

        public static string RemovePrubel(string text)
        {
            return text.Replace("&nbsp", string.Empty);
        }
    }
}
