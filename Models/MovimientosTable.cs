using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    public partial class MovimientosTable
    {
        public MovimientosTable()
        {
            MovimientoFecha = new HashSet<MovimientoFecha>();
        }

        public int MovimientosId { get; set; }
        public int? CuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public int? Estado { get; set; }
        public int? Movimiento { get; set; }
        public string Fecha { get; set; }

        public virtual CuentaTable Cuenta { get; set; }
        public virtual ICollection<MovimientoFecha> MovimientoFecha { get; set; }
    }
}
