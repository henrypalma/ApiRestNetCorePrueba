using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestNetCore.Entidades
{
    public class Movimientos
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public bool Estado { get; set; }
        public int IdCuentaUsuario { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
