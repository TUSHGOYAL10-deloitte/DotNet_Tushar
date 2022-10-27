using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound
{
    public static class SD
    {
        public static string OrderAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }


    }
}
