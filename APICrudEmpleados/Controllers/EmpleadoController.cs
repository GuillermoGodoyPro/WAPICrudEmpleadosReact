using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using APICrudEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace APICrudEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DbcrudEmpleadosContext dbContext;

        public EmpleadoController(DbcrudEmpleadosContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Get()
        {
            var listaEmpleado = await dbContext.Empleados.ToListAsync();

            return StatusCode(StatusCodes.Status200OK, listaEmpleado);
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var empleado = await dbContext.Empleados.FirstOrDefaultAsync(e=>e.IdEmpleado == id);

            return StatusCode(StatusCodes.Status200OK, empleado);
        }

        
        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Post([FromBody] Empleado objetoEmpleado)
        {
            await dbContext.Empleados.AddAsync(objetoEmpleado);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new {mensaje = "Empleado Agregado" });
        }


        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Put([FromBody] Empleado objetoEmpleado)
        {
            dbContext.Empleados.Update(objetoEmpleado);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Empleado Modificado" });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await dbContext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
            dbContext.Empleados.Remove(empleado);

            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Empleado Eliminado" });
        }


    }
}
