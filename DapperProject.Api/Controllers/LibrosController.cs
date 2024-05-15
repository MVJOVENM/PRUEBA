using Dapper;
using DapperProject.Data;
using DapperProject.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DapperProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _LibroRepository;
        public LibrosController(ILibroRepository LibroRepositor)
        {
            _LibroRepository = LibroRepositor;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Libros getFilter = await _LibroRepository.GetFilter(a => a.Id == id);
            Libros Libros = await _LibroRepository.FindByIdAsync(id);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            int Id = 3;
            List<Libros> getQueryAll = await _LibroRepository.GetQueryAll($"select * from Libro(nolock) where Id>{Id}");
            List<Libros> getFilterAll = await _LibroRepository.GetFilterAll(a => a.Id > 2);
            List<Libros> getAll = await _LibroRepository.FindAllAsync();
            return Ok(getAll);
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Libros Libros)
        {
            var p = new DynamicParameters();
            p.Add("@Titulo", "Saat");
            p.Add("@LibroContador", 25);
            p.Add("@CreateDate", DateTime.Now);
            var _return = await _LibroRepository.LibrosStoredProcedure("Sp_Libro", p);

            await _LibroRepository.CreateAsync(Libros);
            return Ok(Libros.Titulo);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _LibroRepository.DeleteAsync(id);
            return Ok("");
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Libros Libros)
        {
            Libros getLibro = await _LibroRepository.FindByIdAsync(Libros.Id);
            if (getLibro != null)
            {
                await _LibroRepository.UpdateAsync(Libros);
            }
            return Ok("");
        }
    }
}
