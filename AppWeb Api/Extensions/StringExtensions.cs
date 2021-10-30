using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string text)
        {
            static IEnumerable<char> Convert(CharEnumerator e)
            {
                if (!e.MoveNext()) yield break;
                if (char.IsUpper(e.Current))
                    yield return char.ToLower(e.Current);
                while (e.MoveNext())
                {
                    if (char.IsUpper(e.Current))
                    {
                        yield return '_';
                        yield return char.ToLower(e.Current);
                    }
                    else
                    {
                        yield return e.Current;
                    }
                }
            }
            return new string(Convert(text.GetEnumerator()).ToArray());
        }
    }
}
