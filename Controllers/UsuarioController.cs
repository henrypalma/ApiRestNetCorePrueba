using ApiRestNetCore.Entidades;
using ApiRestNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericRepository<Usuario> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IGenericRepository<Usuario> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _genericRepository.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _unitOfWork.UsuarioRepository.Add(usuario);

            if (created)
                _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            var modified = await _unitOfWork.UsuarioRepository.Update(usuario);

            if (modified)
                _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _genericRepository.GetAsync(a => a.IdUsuario == id);
            var delete = await _unitOfWork.UsuarioRepository.Delete(usuario.First());

            if (delete)
                _unitOfWork.Commit();

            return Ok();
        }
    }
}
