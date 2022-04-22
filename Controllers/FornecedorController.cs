using System.Linq;
using marketproject.Data;
using marketproject.DTO;
using marketproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketproject.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext _database;

        public FornecedorController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO forncedeorDTO)
        {
            if (ModelState.IsValid)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = forncedeorDTO.Nome;
                fornecedor.Email = forncedeorDTO.Email;
                fornecedor.Telefone = forncedeorDTO.Telefone;
                fornecedor.Status = true;
                _database.Fornecedores.Add(fornecedor);
                _database.SaveChanges();
                return RedirectToAction("Fornecedor", "Gestao"); 
            }
            else
            return View("../Gestao/NovoFornecedor");
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorDTO)
        {  
            if (ModelState.IsValid)
            {
                var fornecedor = _database.Fornecedores.First(f => f.Id == fornecedorDTO.Id);
                fornecedor.Nome = fornecedorDTO.Nome;
                fornecedor.Email = fornecedorDTO.Email;
                fornecedor.Telefone = fornecedorDTO.Telefone;
                _database.SaveChanges();
                return RedirectToAction("Fornecedor", "Gestao");
            }
            else
            {
                return View("../Gestao/EditarFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id>0)
            {
                var fornecedor = _database.Fornecedores.First(f => f.Id == id);
                fornecedor.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Fornecedor", "Gestao");
        }
    }
}