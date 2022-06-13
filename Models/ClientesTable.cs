using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BancoCodigo.Models
{
    public partial class ClientesTable
    {
        public ClientesTable()
        {
            CuentaTable = new HashSet<CuentaTable>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<CuentaTable> CuentaTable { get; set; }
    }
}
