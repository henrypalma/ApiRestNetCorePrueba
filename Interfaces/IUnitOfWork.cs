using ApiRestNetCore.Persistencia;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestNetCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApiRestNetCoreContext Context { get; }

        MovimientoRepository MovimientoRepository { get; }
        CuentasUsuarioRepository CuentasUsuarioRepository { get; }
        UsuarioRepository UsuarioRepository { get; }
        void Commit();
    }
}
