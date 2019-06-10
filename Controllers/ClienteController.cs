using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MgnWebApi.Context;
using MgnWebApi.Interface;
using MgnWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MgnWebApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase  {

        private readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository clienteRepository) {
            this._ClienteRepository = clienteRepository;
        }

        // GET: Api/Cliente
        /// <summary>
        /// Retorna uma lista de todas os clientes cadastradas no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos do tipo Cliente</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> clientes = this._ClienteRepository.GetAll();

            return new OkObjectResult(clientes);
        }

        // GET: Api/Cliente/5
        /// <summary>
        /// Filtra os clientes através do ID informado.
        /// </summary>
        /// <param name="id">ID da Cliente</param>
        /// <returns>Objeto do tipo Cliente</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Int32 id)
        {
            Cliente cliente = this._ClienteRepository.GetById(id);

            return new OkObjectResult(cliente);
        }

        // POST: Api/Cliente
        /// <summary>
        /// Efetua o cadastro de um novo cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto do tipo Cliente</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                this._ClienteRepository.Insert(cliente);
                scope.Complete();

                return this.CreatedAtAction(nameof(Get), new { id = cliente.IdCliente }, cliente);
            }
        }

        // PUT: Api/Cliente/5
        /// <summary>
        /// Atualiza os dados de um cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto do tipo Cliente</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    this._ClienteRepository.Update(cliente);
                    scope.Complete();

                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE: Api/ApiWithActions/5
        /// <summary>
        /// Exclui um cliente do banco de dados.
        /// </summary>
        /// <param name="id">IP do cliente a ser excluída</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Int32 id)
        {
            this._ClienteRepository.Delete(id);

            return new OkResult();
        }
 
    }
}