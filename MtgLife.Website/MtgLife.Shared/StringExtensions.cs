using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgLife.Shared
{
    public static class StringExtensions
    {
        public static int ConvertToInt32(this string value) {
            var output = 0;
            int.TryParse(value, out output);
            return output;
        }
    }
}
