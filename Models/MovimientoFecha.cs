using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    public partial class MovimientoFecha
    {
        public int MovimientoFechaId { get; set; }
        public int? MovimientosId { get; set; }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public int? Estado { get; set; }
        public decimal? Movimiento { get; set; }
        public decimal? SaldoDisponible { get; set; }

        public virtual MovimientosTable Movimientos { get; set; }
    }
}
