using Microsoft.Extensions.DependencyInjection;
using System;


namespace MultipleImplementations
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddLogging()
                .AddConfig()
                .AddSingleton<Startup>()
                .AddSingleton<IService, ServiceA>()
                .AddSingleton<IService, ServiceB>()
                .AddSingleton<IService, ServiceC>();

                

            var serviceProvider = services.BuildServiceProvider();


            serviceProvider.GetService<Startup>().Run();
        }
    }
}
