using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entidades;
using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Servico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            //Criando Banco de Dados
            static LiteDatabase CreateDB()
            {
            LiteDatabase db = new LiteDatabase("BancoDeDadosLiteDb.db");
            return db;
            }
            var db = CreateDB();
            */
                        
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
