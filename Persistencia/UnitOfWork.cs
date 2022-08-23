using ApiRestNetCore.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiRestNetCore.Persistencia
{
    public class UnitOfWork : Interfaces.IUnitOfWork
    {
        public ApiRestNetCoreContext Context { get; }
        private MovimientoRepository _movimientoRepository;
        private UsuarioRepository _usuarioRepository;
        private CuentasUsuarioRepository _cuentasUsuarioRepository;

        public UnitOfWork(ApiRestNetCoreContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public MovimientoRepository MovimientoRepository
        {
            get
            {
                if(_movimientoRepository == null)
                {
                    _movimientoRepository = new MovimientoRepository(Context);
                }
                return _movimientoRepository;
            }
        }

        public UsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository(Context);
                }
                return _usuarioRepository;
            }
        }

        public CuentasUsuarioRepository CuentasUsuarioRepository
        {
            get
            {
                if (_cuentasUsuarioRepository == null)
                {
                    _cuentasUsuarioRepository = new CuentasUsuarioRepository(Context);
                }
                return _cuentasUsuarioRepository;
            }
        }
    }
}
