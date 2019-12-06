using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleImplementations
{
    class ServiceC : IService
    {
        public string Name => "C";
        public string hello()
        {
            return "ServiceC";
        }
    }
}
