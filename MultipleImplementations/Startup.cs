using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MultipleImplementations
{
    class Startup
    {
        IEnumerable<IService> services;
        
        public Startup(IEnumerable<IService> services, IConfiguration configuration)
        {
            
            this.services = services;
        }

        



        public void Run()
        {  
            var service = services.First(o => o.Name.Equals("A"));
            Console.WriteLine(service.hello());

            service = services.First(o => o.Name.Equals("B"));
            Console.WriteLine(service.hello());

            service = services.First(o => o.Name.Equals("C"));
            Console.WriteLine(service.hello());

        }
    }
}
