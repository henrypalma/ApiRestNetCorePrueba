using ApiRestNetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace ApiRestNetCore.Persistencia
{
    public class CuentasUsuarioRepository
    {
        private readonly ApiRestNetCoreContext _context;
        public CuentasUsuarioRepository(ApiRestNetCoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(CuentasUsuario cuenta)
        {
            try
            {
                var created = false;
                var save = _context.CuentasUsuario.Add(cuenta);
                if (save != null)
                    created = true;

                return created;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<bool> Update(CuentasUsuario cuenta)
        {
            try
            {
                var modified = false;
                var save = _context.CuentasUsuario.Update(cuenta);
                if (save != null)
                    modified = true;

                return modified;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<bool> Delete(CuentasUsuario cuenta)
        {
            try
            {
                var delete = false;
                var save = _context.CuentasUsuario.Remove(cuenta);
                if (save != null)
                    delete = true;

                return delete;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<IEnumerable<CuentasUsuario>> GetConditionWhere(Expression<Func<CuentasUsuario, bool>> whereCondition)
        {
            return _context.CuentasUsuario.Where(whereCondition);

        }
    }
}
