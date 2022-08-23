

using System.Collections.Generic;

namespace ApiRestNetCore.Entidades
{
    public class Usuario
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int IdUsuario {get;set;}
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public bool Estado { get; set; }

    }
}
