using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleImplementations
{
    class ServiceB : IService
    {
        public string Name => "B";

        public string hello()
        {
            return "ServiceB";
        }
    }
}
