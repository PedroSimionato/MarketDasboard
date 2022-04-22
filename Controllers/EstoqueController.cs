using marketproject.Data;
using marketproject.DTO;
using marketproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketproject.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ApplicationDbContext _database;

        public EstoqueController(ApplicationDbContext database)
        {
            _database = database;
        }

        public IActionResult Salvar(EstoqueDTO estoqueDTO)
        {
            if(ModelState.IsValid)
        {
            Estoque estoque = new Estoque();
            estoque.Produto = estoqueDTO.Produto;
            estoque.Quantidade = estoqueDTO.Quantidade;
            _database.Estoques.Add(estoque);
            _database.SaveChanges();
            return RedirectToAction("Estoque", "Gestao");
        }
        else
        return View("../Gestao/NovoEstoque");
        }
        
    }
}