using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleImplementations
{
    class ServiceA : IService
    {

        public ServiceA(IConfiguration configuration)
        {
            Console.WriteLine(configuration.GetSection("DVConfig").GetSection("TempFileLocation").Value);
        }
        public string Name => "A";
        public string hello()
        {
            return "ServiceA";
        }
    }
}
