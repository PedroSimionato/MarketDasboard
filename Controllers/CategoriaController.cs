using System.Linq;
using marketproject.Data;
using marketproject.DTO;
using marketproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketproject.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly ApplicationDbContext _database;

        public CategoriaController(ApplicationDbContext database)
        {
            _database = database;
        } 

        [HttpPost]
        public IActionResult Salvar(CategoriaDTO categoriaTemporario)
        {
            if(ModelState.IsValid)
            {
                Categoria categoria = new Categoria();
                categoria.Nome = categoriaTemporario.Nome;
                categoria.Status = true;
                _database.Categorias.Add(categoria);
                _database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }
            else
            return View("../Gestao/NovaCategoria");
        }

        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO categoriaDTO)
        {  
            if (ModelState.IsValid)
            {
                var categoria = _database.Categorias.First(c => c.Id == categoriaDTO.Id);
                categoria.Nome = categoriaDTO.Nome;
                _database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }
            else
            {
                return View("../Gestao/EditarCategoria");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id>0)
            {
                var categoria = _database.Categorias.First(c => c.Id == id);
                categoria.Status = false;
                _database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }
            return Content(id.ToString());
        }
    }
}