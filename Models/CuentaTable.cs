using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    public partial class CuentaTable
    {
        public CuentaTable()
        {
            MovimientosTable = new HashSet<MovimientosTable>();
        }

        public int CuentaId { get; set; }
        public int? ClienteId { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public int? Estado { get; set; }
        public string Cliente { get; set; }

        public virtual ClientesTable ClienteNavigation { get; set; }
        public virtual ICollection<MovimientosTable> MovimientosTable { get; set; }
    }
}
