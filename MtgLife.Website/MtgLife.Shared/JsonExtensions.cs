using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgLife.Shared
{
    public static class JsonExtensions
    {
        public static string JsonSerialize(this object objectToSerialize)
        {
            var json = JsonConvert.SerializeObject(objectToSerialize);
            return json;
        }
    }
}
