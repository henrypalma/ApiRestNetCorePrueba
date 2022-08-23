using ApiRestNetCore.Entidades;
using ApiRestNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasUsuarioController : ControllerBase
    {
        private readonly IGenericRepository<CuentasUsuario> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CuentasUsuarioController(IGenericRepository<CuentasUsuario> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<CuentasUsuario>> Get()
        {
            return await _genericRepository.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CuentasUsuario cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _unitOfWork.CuentasUsuarioRepository.Add(cuenta);

            if (created)
                _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CuentasUsuario cuenta)
        {
            if (id != cuenta.IdCuentaUsuario)
            {
                return BadRequest("No existe");
            }

            var modified = await _unitOfWork.CuentasUsuarioRepository.Update(cuenta);

            if (modified)
                _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cuenta = await _genericRepository.GetAsync(a => a.IdCuentaUsuario == id);
            var delete = await _unitOfWork.CuentasUsuarioRepository.Delete(cuenta.First());

            if (delete)
                _unitOfWork.Commit();

            return Ok();
        }
    }


}
