using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiRestNetCore.Entidades;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Reflection;
using ApiRestNetCore.Interfaces;

namespace ApiRestNetCore.Persistencia
{
    public class ApiRestNetCoreContext : DbContext
    {
        public ApiRestNetCoreContext(DbContextOptions<ApiRestNetCoreContext> options)
            : base(options)  {}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CuentasUsuario> CuentasUsuario { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

       

       
    }
}
