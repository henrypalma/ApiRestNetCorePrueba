using ApiRestNetCore.Entidades;
using ApiRestNetCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiRestNetCore.Persistencia
{
    public class MovimientoRepository
    {
        private readonly ApiRestNetCoreContext _context;
        public MovimientoRepository(ApiRestNetCoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Movimientos movimiento)
        {
            try
            {
                var created = false;
                var save = _context.Movimientos.Add(movimiento);
                if (save != null)
                    created = true;

                return created;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<IEnumerable<object>> GetMovimientos()
        {
            var mov = (from a in _context.Movimientos
                       join c in _context.CuentasUsuario
                            on a.IdCuentaUsuario equals c.IdCuentaUsuario
                       join b in _context.Usuario
                             on c.IdUsuario equals b.IdUsuario
                       select new
                       {
                           Fecha = a.Fecha,
                           Cliente = b.Nombres,
                           NumeroCuenta = c.NumeroCuenta,
                           Tipo = c.TipoCuenta,
                           SaldoInicial = c.SaldoInicial,
                           Estado = c.Estado,
                           Movimiento = a.ValorMovimiento,
                           SaldoDisponible = a.SaldoDisponible

                       }).ToList();

            return mov;
           
        }

        public async Task<IEnumerable<Movimientos>> GetConditionWhere(Expression<Func<Movimientos, bool>> whereCondition)
        {
            return _context.Movimientos.Where(whereCondition);

        }
    }
}
