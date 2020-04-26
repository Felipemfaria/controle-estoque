using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControleEstoque.Web.Models;

namespace ControleEstoque.Web.Controllers
{
    public class CadastroController : Controller
    {
        private static List<GrupoProdutoModel> _ListaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel(){ id=1, Nome="Canetas", Ativo=true },
            new GrupoProdutoModel(){ id=2, Nome="Livros", Ativo=true },
            new GrupoProdutoModel(){ id=3, Nome="Mouses", Ativo=false }       
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(_ListaGrupoProduto);
        }

        [HttpPost]
        public ActionResult RecuperarGrupoProduto(int? id)
        {
            if (id != null)
            {
                return Json(_ListaGrupoProduto.Find(x => x.id == id));
            }

            return Json("erro: 'ID inválido'");
        }

        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }
    }
}