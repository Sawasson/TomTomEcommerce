using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

namespace TomTomEcommerce.Helpers
{
    public class StringHelper
    {

        /// <summary>
        /// The string extensions.
        /// </summary>
        public static class StringExtensions
        {
            /// <summary>
            /// The remove from end.
            /// </summary>
            /// <param name="s">
            /// The s.
            /// </param>
            /// <param name="suffix">
            /// The suffix.
            /// </param>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public static string RemoveAfterLast(this string s, string suffix)
            {
                var index = s.LastIndexOf(suffix, StringComparison.InvariantCulture);
                if (index > 0)
                {
                    s = s.Substring(0, index);
                }

                return s;
            }

            /// <summary>
            /// Removed invalid xml characters.
            /// </summary>
            /// <param name="text">
            /// The text.
            /// </param>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            public static string RemoveInvalidXmlChars(this string text)
            {
                if (text == null)
                {
                    return null;
                }

                var validXmlChars = text.Where(XmlConvert.IsXmlChar).ToArray();
                return new string(validXmlChars);
            }

            public static string Slugify(this string phrase)
            {
                string str = phrase.RemoveAccent().ToLower();
                str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non valid chars          
                str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
                str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
                return str;
            }

            public static string RemoveAccent(this string txt)
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
                return System.Text.Encoding.ASCII.GetString(bytes);
            }
            public static string ToURL(this string s)
            {
                if (string.IsNullOrEmpty(s)) return "";
                if (s.Length > 80)
                    s = s.Substring(0, 80);
                s = s.Replace("ş", "s");
                s = s.Replace("Ş", "S");
                s = s.Replace("ğ", "g");
                s = s.Replace("Ğ", "G");
                s = s.Replace("İ", "I");
                s = s.Replace("ı", "i");
                s = s.Replace("ç", "c");
                s = s.Replace("Ç", "C");
                s = s.Replace("ö", "o");
                s = s.Replace("Ö", "O");
                s = s.Replace("ü", "u");
                s = s.Replace("Ü", "U");
                s = s.Replace("'", "");
                s = s.Replace("\"", "");
                Regex r = new Regex("[^a-zA-Z0-9_-]");
                //if (r.IsMatch(s))
                s = r.Replace(s, "-");
                if (!string.IsNullOrEmpty(s))
                    while (s.IndexOf("--") > -1)
                        s = s.Replace("--", "-");
                if (s.StartsWith("-")) s = s.Substring(1);
                if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
                return s;
            }
        }
    }
}
