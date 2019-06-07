using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MgnWebApi.vscode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MgnWebApi.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase  {

        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context) {
            _context = context;

            if (_context.Cliente.Count() == 0)  {
                _context.Cliente.Add(new Cliente { Nome = "Cliente",
                                                    Cpf = 08954744125,
                                                    Rg = 154874589 });
                _context.SaveChanges();
            }
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente() {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetTodoItem(long id) {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null) {
                return NotFound();
            }

            return cliente;
        }
    }
}