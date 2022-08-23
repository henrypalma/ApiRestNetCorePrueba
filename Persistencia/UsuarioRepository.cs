using ApiRestNetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiRestNetCore.Persistencia
{
    public class UsuarioRepository
    {
        private readonly ApiRestNetCoreContext _context;
        public UsuarioRepository(ApiRestNetCoreContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            try
            {
                var created = false;
                var save = _context.Usuario.Add(usuario);
                if (save != null)
                    created = true;

                return created;
            }
            catch(Exception e)
            {
                throw;
            }
            
        }

        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                var modified = false;
                var save = _context.Usuario.Update(usuario);
                if (save != null)
                    modified = true;

                return modified;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<bool> Delete(Usuario usuario)
        {
            try
            {
                var delete = false;
                var save = _context.Usuario.Remove(usuario);
                if (save != null)
                    delete = true;

                return delete;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<IEnumerable<Usuario>> GetConditionWhere(Expression<Func<Usuario, bool>> whereCondition)
        {
            return _context.Usuario.Where(whereCondition);

        }
    }
}
