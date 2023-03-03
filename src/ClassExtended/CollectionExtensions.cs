using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yx.Utils.ClassExtended
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                return !enumerable.GetEnumerator().MoveNext();
            }

            return true;
        }
    }
}
