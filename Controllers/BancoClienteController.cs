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
    public class BancoClienteController : ControllerBase
    {

        private readonly BaseDeDatosBancoContext _contextService;
        /// <summary>
        /// Constructor para Inyección de dependencias
        /// </summary>
        /// <param name="service"></param>
        public BancoClienteController(BaseDeDatosBancoContext service)
        {
            _contextService = service;
        }
        // GET: api/BancoCliente/Clientes
        [HttpGet("Clientes")]
        public IEnumerable<ClientesTable> Get()
        {
            List<ClientesTable> oCliente = new List<ClientesTable>();

            foreach (ClientesTable Cliente in _contextService.ClientesTable.ToList())
            {
                oCliente.Add(Cliente);
            }

            return oCliente;
        }

        // GET api/BancoCliente/Clientes/id
        [HttpGet("Clientes/{id}")]
        public ActionResult<ClientesTable>GetEspecifico(int id)
        {
            return _contextService.ClientesTable.Find(id);
        }

        // POST api/BancoCliente/Clientes/Registros
        [HttpPost("Clientes/Registros")]
        public void Post([FromBody] ClientesTable oclientesTable)
        {
            var addClienteRegistro = new ClientesTable();
            addClienteRegistro.Nombre = oclientesTable.Nombre;
            addClienteRegistro.Direccion = oclientesTable.Direccion;
            addClienteRegistro.Telefono = oclientesTable.Telefono;
            addClienteRegistro.Clave = oclientesTable.Clave;
            addClienteRegistro.Estado = oclientesTable.Estado;
            _contextService.ClientesTable.Add(addClienteRegistro);
            _contextService.SaveChanges();
        }

        // PUT api/BancoCliente/Clientes/Actualizar/Clientes/id
        [HttpPut("Clientes/Actualizar/Clientes/{id}")]
        public void Put([FromBody] ClientesTable oclientesTable, int id)
        {
            var addClienteRegistro = _contextService.ClientesTable.Find(id);
            addClienteRegistro.Nombre = oclientesTable.Nombre;
            addClienteRegistro.Direccion = oclientesTable.Direccion;
            addClienteRegistro.Telefono = oclientesTable.Telefono;
            addClienteRegistro.Clave = oclientesTable.Clave;
            addClienteRegistro.Estado = oclientesTable.Estado;
            _contextService.Entry(addClienteRegistro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contextService.SaveChanges();
        }

        // DELETE api/BancoCliente/Clientes/Eliminar/Clientes/{id}
        [HttpDelete("Clientes/Eliminar/Clientes/{id}")]
        public void Delete(int id)
        {
            var oEliminar = _contextService.ClientesTable.Find(id);
            _contextService.Remove(oEliminar);
            _contextService.SaveChanges();
        }
    }
}
