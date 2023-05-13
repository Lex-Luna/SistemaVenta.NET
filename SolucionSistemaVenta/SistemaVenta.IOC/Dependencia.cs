using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.DAL.Implementacion;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.BLL.Implementacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {


        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuracion)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            services.AddDbContext<DbventaContext>(options =>
            {
                options.UseMySql(configuracion.GetConnectionString("CadenSQL"), serverVersion);
            });
        }


    }
}
