using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI
{
    public class Response
    {
        public string message { get; set; }
        public Recipes recipe { get; set; }
        public string required { get; set; }
    }
}
