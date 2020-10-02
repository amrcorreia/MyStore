using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyStore.Web.Data;

namespace MyStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build(); //contruo o conteiner
            RunSeeding(host); //crio a base de dados e meto lá o seed
            host.Run(); // e só depois é que corro
        }

        private static void RunSeeding(IWebHost host)
        {
            //estou a dizer que vai haver um serviço específico que vai utilizar uma seedDb 
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope()) //vou criar outro da mma familia para acrescentar ao que já existe
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait(); //corres o seeder async e esperas, qdo acabares 
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
