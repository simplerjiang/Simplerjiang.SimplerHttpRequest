using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Simplerjiang.SimpleHttpRequest.Model
{
    public class HttpResult
    {
        internal HttpStatusCode stat { get; set; }
        internal string result { get; set; }
        internal string errorMessage { get; set; }
    }
}
