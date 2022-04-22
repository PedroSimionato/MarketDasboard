using System;
using System.Linq;
using marketproject.Data;
using marketproject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marketproject.Controllers
{
    public class GestaoController : Controller
    {

        private readonly ApplicationDbContext _database;

        public GestaoController(ApplicationDbContext database)
        {

            _database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorias()
        {
            var categorias = _database.Categorias.Where(c => c.Status == true).ToList();
            return View(categorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = _database.Categorias.First(c => c.Id == id);
            CategoriaDTO categoriaDTO = new CategoriaDTO();
            categoriaDTO.Nome = categoria.Nome;
            categoriaDTO.Id = categoriaDTO.Id;
            return View(categoriaDTO);
        }

        public IActionResult Fornecedor()
        {
            var fornecedores = _database.Fornecedores.Where(f => f.Status == true).ToList();
            return View(fornecedores);
        }

        public IActionResult NovoFornecedor()
        {
            return View();
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = _database.Fornecedores.First(f => f.Id == id);
            FornecedorDTO fornecedorDTO = new FornecedorDTO();
            fornecedorDTO.Id = fornecedor.Id;
            fornecedorDTO.Nome = fornecedor.Nome;
            fornecedorDTO.Email = fornecedor.Email;
            fornecedorDTO.Telefone = fornecedor.Telefone;
            return View(fornecedorDTO);
        }

        public IActionResult Produtos()
        {
            var produtos = _database.Produtos.Include(p => p.Categoria).
            Include(p => p.Forncedor).Where(p => p.Status ==true).ToList();
            return View(produtos);
        }

        public IActionResult NovoProduto()
        {
            ViewBag.Categorias = _database.Categorias.ToList();
            ViewBag.Fornecedores = _database.Fornecedores.ToList();
            return View();
        }

        public IActionResult EditarProduto(int id)
        {
            var produto = _database.Produtos.Include(p => p.Categoria).Include(p => p.Forncedor).First(p => p.Id == id);
            ProdutoDTO produtoDTO = new ProdutoDTO();
            produtoDTO.Id = produto.Id;
            produtoDTO.Nome = produto.Nome;
            produtoDTO.PrecoDeCusto = produto.PrecoDeCusto;
            produtoDTO.PrecoDeVenda = produto.PrecoDeVenda;
            produtoDTO.CategoriaId = produto.Categoria.Id;
            produtoDTO.FornecedorId = produto.Forncedor.Id;
            produtoDTO.Medicao = produto.Medicao;
            ViewBag.Categorias = _database.Categorias.ToList();
            ViewBag.Fornecedores = _database.Fornecedores.ToList();
            return View(produtoDTO);
        }

        public IActionResult Promocao()
        {
            var promocoes = _database.Promocoes.Include(promo => promo.Produto).
            Where(promo => promo.Status == true).ToList();
            return View(promocoes);
        }

        public IActionResult NovaPromocao()
        {
            ViewBag.Produtos = _database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarPromocao(int id)
        {
            var promocao = _database.Promocoes.Include(promo => promo.Produto).First(promo => promo.Id == id);
            PromocaoDTO promocaoDTO = new PromocaoDTO();
            promocaoDTO.Id = promocao.Id;
            promocaoDTO.ProdutoId = promocao.Produto.Id;
            promocaoDTO.Nome = promocao.Nome;
            promocaoDTO.Porcentagem = promocao.Porcentagem;
            ViewBag.Produtos = _database.Produtos.ToList();
            return View(promocaoDTO);
        }

        public IActionResult Estoque()
        {
            return View();
        }

        public IActionResult NovoEstoque()
        {
            return View();
        }
    }
}