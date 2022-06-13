using BancoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoCuentasController : ControllerBase
    {
        private readonly BaseDeDatosBancoContext _contextService;
        /// <summary>
        /// Constructor para Inyección de dependencias
        /// </summary>
        /// <param name="service"></param>
        public BancoCuentasController(BaseDeDatosBancoContext service)
        {
            _contextService = service;
        }
        // GET: api/BancoCuentas/Cuentas
        [HttpGet("Cuentas")]
        public IEnumerable<CuentaTable> Get()
        {
            List<CuentaTable> oCuentaTable = new List<CuentaTable>();

            foreach (CuentaTable Cuenta in _contextService.CuentaTable.ToList())
            {
                oCuentaTable.Add(Cuenta);
            }

            return oCuentaTable;
        }


        // GET api/BancoCuentas/Cuentas/id
        [HttpGet("Cuentas/{id}")]
        public ActionResult<CuentaTable> GetEspecifico(int id)
        {
            return _contextService.CuentaTable.Find(id);
        }

        // POST api/BancoCuentas/Cuentas/Nuevas/Cuentas
        [HttpPost("Cuentas/Nuevas/Cuentas")]
        public void Post([FromBody] CuentaTable ocuentaTable)
        {
            var addCuenta = new CuentaTable();
            addCuenta.ClienteId = ocuentaTable.ClienteId;
            addCuenta.NumeroCuenta = ocuentaTable.NumeroCuenta;
            addCuenta.TipoCuenta = ocuentaTable.TipoCuenta;
            addCuenta.SaldoInicial = ocuentaTable.SaldoInicial;
            addCuenta.Estado = ocuentaTable.Estado;
            addCuenta.Cliente = ocuentaTable.Cliente;

            _contextService.CuentaTable.Add(addCuenta);
            _contextService.SaveChanges();
        }

        // PUT api/BancoCuentas/Cuentas/Editar/Cuentas/{id}
        [HttpPut("Cuentas/Editar/Cuentas/{id}")]
        public void Put([FromBody] CuentaTable ocuentaTable, int id)
        {
            var addCuenta = _contextService.CuentaTable.Find(id);
            addCuenta.ClienteId = ocuentaTable.ClienteId;
            addCuenta.NumeroCuenta = ocuentaTable.NumeroCuenta;
            addCuenta.TipoCuenta = ocuentaTable.TipoCuenta;
            addCuenta.SaldoInicial = ocuentaTable.SaldoInicial;
            addCuenta.Estado = ocuentaTable.Estado;
            addCuenta.Cliente = ocuentaTable.Cliente;
            _contextService.Entry(addCuenta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contextService.SaveChanges();
        }

        // DELETE api/BancoCuentas/Cuentas/Eliminar/Cuentas/{id}
        [HttpDelete("Cuentas/Eliminar/Cuentas/{id}")]
        public void Delete(int id)
        {
            var oEliminar = _contextService.CuentaTable.Find(id);
            _contextService.Remove(oEliminar);
            _contextService.SaveChanges();
        }
    }
}
