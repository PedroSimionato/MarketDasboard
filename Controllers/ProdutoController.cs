using System.Linq;
using marketproject.Data;
using marketproject.DTO;
using marketproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketproject.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ProdutoController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                Produto produto = new Produto();
                produto.Nome = produtoDTO.Nome;
                produto.Categoria = _database.Categorias.First(cat => cat.Id == produtoDTO.CategoriaId);
                produto.Forncedor = _database.Fornecedores.First(f => f.Id == produtoDTO.FornecedorId);
                produto.PrecoDeCusto = produtoDTO.PrecoDeCusto;
                produto.PrecoDeVenda = produtoDTO.PrecoDeVenda;
                produto.Medicao = produtoDTO.Medicao;
                produto.Status = true;
                _database.Produtos.Add(produto);
                _database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }
            else
            {
                ViewBag.Categorias = _database.Categorias.ToList();
                ViewBag.Fornecedores = _database.Fornecedores.ToList();
                return View("../Gestao/NovoProduto");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(ProdutoDTO produtoDTO)
        {
            if(ModelState.IsValid)
            {
                var produto = _database.Produtos.First(p => p.Id == produtoDTO.Id);
                produto.Nome = produtoDTO.Nome;
                produto.Categoria = _database.Categorias.First(c => c.Id == produtoDTO.CategoriaId);
                produto.Forncedor = _database.Fornecedores.First(f => f.Id == produtoDTO.FornecedorId);
                produto.PrecoDeCusto = produtoDTO.PrecoDeCusto;
                produto.PrecoDeVenda = produtoDTO.PrecoDeVenda;
                produto.Medicao = produtoDTO.Medicao;
                _database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }
            else
            {
                return RedirectToAction("Produtos", "Gestao");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id>0)
            {
                var produto = _database.Produtos.First(p => p.Id == id);
                produto.Status= false;
                _database.SaveChanges();
            }
            return RedirectToAction("Produtos", "Gestao");
        }

    }
}