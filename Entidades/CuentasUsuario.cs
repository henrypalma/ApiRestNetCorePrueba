using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestNetCore.Entidades
{
    public class CuentasUsuario
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdCuentaUsuario { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int IdUsuario { get; set; }
    }
}
