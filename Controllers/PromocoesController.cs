using System.Linq;
using marketproject.Data;
using marketproject.DTO;
using marketproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace marketproject.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext _database;

        public PromocoesController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoDTO)
        {
            if(ModelState.IsValid)
            {
                var promocao = new Promocao();
                promocao.Id = promocaoDTO.Id;
                promocao.Nome = promocaoDTO.Nome;
                promocao.Produto = _database.Produtos.First(prod => prod.Id == promocaoDTO.ProdutoId);
                promocao.Porcentagem = promocaoDTO.Porcentagem;
                promocao.Status = true;
                _database.Promocoes.Add(promocao);
                _database.SaveChanges();
                return RedirectToAction("Promocao", "Gestao");
            }
            else
            {
                ViewBag.Produtos = _database.Produtos.ToList();
                return View();
            }
        }

        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO promocaoDTO)
        {
            if(ModelState.IsValid)
            {
                var promocao = _database.Promocoes.First(promo => promo.Id == promocaoDTO.Id);
                promocao.Id = promocaoDTO.Id;
                promocao.Nome = promocaoDTO.Nome;
                promocao.Produto = _database.Produtos.First(prod => prod.Id == promocaoDTO.ProdutoId);
                promocao.Porcentagem = promocaoDTO.Porcentagem;
                _database.SaveChanges();
            }
            return RedirectToAction("Promocao", "Gestao");    
        }  

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id>0)
            {
                var promocao = _database.Promocoes.First(promo => promo.Id == id);
                promocao.Status = false;
                _database.SaveChanges();
            }
            return RedirectToAction("Promocao", "Gestao");
        }  
    }
}