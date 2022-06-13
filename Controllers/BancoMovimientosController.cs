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
    public class BancoMovimientosController : ControllerBase
    {
        private readonly BaseDeDatosBancoContext _contextService;
        /// <summary>
        /// Constructor para Inyección de dependencias
        /// </summary>
        /// <param name="service"></param>
        public BancoMovimientosController(BaseDeDatosBancoContext service)
        {
            _contextService = service;
        }

        // GET: api/BancoMovimientos/Movimientos
        [HttpGet("Movimientos")]
        public IEnumerable<MovimientosTable> Get()
        {
            List<MovimientosTable> oMovimientosTable = new List<MovimientosTable>();

            foreach (MovimientosTable Movimientos in _contextService.MovimientosTable.ToList())
            {
                oMovimientosTable.Add(Movimientos);
            }

            return oMovimientosTable;
        }

        // GET api/BancoMovimientos/Movimientos/id
        [HttpGet("Movimientos/{id}")]
        public ActionResult<MovimientosTable> GetEspecifico(int id)
        {
            return _contextService.MovimientosTable.Find(id);
        }

        // GET api/BancoMovimientos/MovimientosFechas
        [HttpGet("MovimientosFechas")]
        public IEnumerable<MovimientoFecha> GetFechas()
        {
            List<MovimientoFecha> oMovimientoFecha = new List<MovimientoFecha>();

            foreach (MovimientoFecha Movimiento in _contextService.MovimientoFecha.ToList())
            {
                oMovimientoFecha.Add(Movimiento);
            }

            return oMovimientoFecha;
        }

        // GET api/BancoMovimientos/MovimientosFechas/fechas
        [HttpGet("MovimientosFechas/{fechas}/Clientes/{cliente}")]
        public IEnumerable<MovimientoFecha> GetFechaEspecifico(string fechas, string cliente)
        {
            List<MovimientoFecha> oMovimientoFecha = new List<MovimientoFecha>();

            foreach (MovimientoFecha Movimiento in _contextService.MovimientoFecha.ToList())
            {
                if (Movimiento.Fecha == fechas && Movimiento.Cliente == cliente)
                {
                    oMovimientoFecha.Add(Movimiento);
                }
                
            }

            return oMovimientoFecha;
        }

        // POST api/BancoMovimientos/Movimientos/Nuevos/Movimientos
        [HttpPost("Movimientos/Nuevos/Movimientos")]
        public void Post([FromBody] MovimientosTable oMovimiento)
        {
            var addMovimiento = new MovimientosTable();
            addMovimiento.CuentaId = oMovimiento.CuentaId;
            addMovimiento.NumeroCuenta = oMovimiento.NumeroCuenta;
            addMovimiento.Tipo = oMovimiento.Tipo;
            addMovimiento.SaldoInicial = oMovimiento.SaldoInicial;
            addMovimiento.Estado = oMovimiento.Estado;
            addMovimiento.Movimiento = oMovimiento.Movimiento;
            addMovimiento.Fecha = DateTime.Now.ToString("dd-MM-yyyy");
            _contextService.MovimientosTable.Add(addMovimiento);
            _contextService.SaveChanges();
        }

        // PUT api/BancoMovimientos/Movimientos/Editar/Movimientos/{id}
        [HttpPut("Movimientos/Editar/Movimientos/{id}")]
        public OkObjectResult Put([FromBody] MovimientosTable oMovimiento, int id)
        {
            var addMovimiento = _contextService.MovimientosTable.Find(id);
            addMovimiento.CuentaId = oMovimiento.CuentaId;
            var addCuenta = _contextService.CuentaTable.Find(addMovimiento.CuentaId);

            addMovimiento.NumeroCuenta = oMovimiento.NumeroCuenta;
            addMovimiento.Tipo = oMovimiento.Tipo;
            addMovimiento.SaldoInicial = addCuenta.SaldoInicial;
            addMovimiento.Estado = oMovimiento.Estado;
            addMovimiento.Movimiento = oMovimiento.Movimiento;

            var addMovimientoFecha = new MovimientoFecha();
            addMovimientoFecha.MovimientosId = addMovimiento.MovimientosId;
            addMovimientoFecha.Fecha = addMovimiento.Fecha;
            addMovimientoFecha.Cliente = addCuenta.Cliente;
            addMovimientoFecha.NumeroCuenta = addCuenta.NumeroCuenta;
            addMovimientoFecha.Tipo = addCuenta.TipoCuenta;
            addMovimientoFecha.SaldoInicial = addCuenta.SaldoInicial;
            addMovimientoFecha.Estado = addCuenta.Estado;
            addMovimientoFecha.Movimiento = addMovimiento.Movimiento;
            addMovimientoFecha.SaldoDisponible = addCuenta.SaldoInicial + addMovimiento.Movimiento;
            if (addMovimientoFecha.SaldoDisponible<0)
            {
                return Ok("Saldo no disponible");
            }
            else
            {
                if (addMovimientoFecha.Movimiento > 1000)
                {
                    return Ok("Cupo diario Excedido");
                }
                else
                {
                    _contextService.Entry(addMovimiento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _contextService.MovimientoFecha.Add(addMovimientoFecha);
                    _contextService.SaveChanges();
                }
               
            }       
            return Ok("Operación Correcta");

        }

        // DELETE api/BancoMovimientos/Movimientos/Eliminar/Movimientos/{id}
        [HttpDelete("Movimientos/Eliminar/Movimientos/{id}")]
        public void Delete(int id)
        {
            var oEliminar = _contextService.MovimientosTable.Find(id);
            _contextService.Remove(oEliminar);
            _contextService.SaveChanges();
        }
    }
}
