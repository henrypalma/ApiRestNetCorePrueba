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
    public class MovimientosController : ControllerBase
    {
        private readonly IGenericRepository<Movimientos> _genericRepository;


        private readonly IUnitOfWork _unitOfWork;
        public MovimientosController(IGenericRepository<Movimientos> genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            return await _unitOfWork.MovimientoRepository.GetMovimientos();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movimientos movimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cuenta = _unitOfWork.CuentasUsuarioRepository.GetConditionWhere(c => c.IdCuentaUsuario == movimiento.IdCuentaUsuario);
            var ultMovimiento = _unitOfWork.MovimientoRepository.GetConditionWhere(m => m.IdCuentaUsuario == movimiento.IdCuentaUsuario).Result;
            var saldoDisponible = cuenta.Result.First().SaldoInicial;
            if (ultMovimiento.Any())
            {
                saldoDisponible = ultMovimiento.OrderByDescending(o => o.IdMovimiento).First().SaldoDisponible;
            }

            if (movimiento.ValorMovimiento > saldoDisponible)
            {
                return BadRequest("Saldo No Disponible");
            }

            if (movimiento.TipoMovimiento == "Retiro")
            {
                movimiento.ValorMovimiento = movimiento.ValorMovimiento * -1;
            }

            movimiento.SaldoDisponible = saldoDisponible + movimiento.ValorMovimiento;
            var created = await _unitOfWork.MovimientoRepository.Add(movimiento);

            if (created)
                _unitOfWork.Commit();

            return Ok();
        }

        
    }
}
