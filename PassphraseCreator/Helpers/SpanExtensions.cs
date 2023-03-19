using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator
{
    public static class SpanExtensions
    {
        public static bool Any<T>(this Span<T> span, Func<T, bool> selector)
            => span.Any(selector, out int _);

        public static bool Any<T>(this Span<T> span, Func<T, bool> selector, out T? result)
        {
            if (span.Any(selector, out int index))
            {
                result = span[index];
                return true;
            }
            result = default;
            return false;
        }

        public static bool Any<T>(this Span<T> span, Func<T, bool> selector, out int index)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if (selector(span[i]))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public static bool Any<T>(this ReadOnlySpan<T> span, Func<T, bool> selector)
            => span.Any(selector, out int _);

        public static bool Any<T>(this ReadOnlySpan<T> span, Func<T, bool> selector, out T? result)
        {
            if (span.Any(selector, out int index))
            {
                result = span[index];
                return true;
            }
            result = default; 
            return false;
        }

        public static bool Any<T>(this ReadOnlySpan<T> span, Func<T, bool> selector, out int index)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if (selector(span[i]))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
    }
}
