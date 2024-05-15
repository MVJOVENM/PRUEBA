using Dapper;
using DapperProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperProject.Data
{
    public interface ILibroRepository : IRepository<Libros>
    {
        Task<IEnumerable<Libros>> GetLibrosAsync();
        Task<Libros> GetLibrosByIdAsync(int id);
        Task<bool> InsertLibrosAsync(Libros Libro);
        Task<bool> UpdateLibrosAsync(Libros Libro);
        Task<bool> DeleteLibrosAsync(int id);


        Task<List<Libros>> GetFilterLibrosAll(Expression<Func<Libros, bool>> filter);
        Task<Libros> GetFilterLibros(Expression<Func<Libros, bool>> filter);
        Task<int> LibrosStoredProcedure(string storedProcedure, DynamicParameters dynamicParameters);
        Task<List<Libros>> GetQueryLibros(string query);
    }
}
