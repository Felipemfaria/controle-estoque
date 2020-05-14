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
        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(GrupoProdutoModel.findAll());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            if (!id.Equals(null))
            {
                return Json(GrupoProdutoModel.findById(id));
            }
            else
            {
                return Json("erro: 'ID inválido'");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel grupoProdutoModel)
        {
            var mensagensAviso = new List<string>();
            if (ModelState.IsValid)
            {
                try
                {
                    var id = grupoProdutoModel.save();
                    if (!id.Equals(null)){
                        return Json(new { id });
                    }
                    else
                    {
                        return Json(new { MensagemErro = "Erro ao recuperar id do item salvo!" });
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { MensagemErro = "Exception gerada!" });
                }
            }
            else
            {
                mensagensAviso = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return Json(new {grupoProdutoModel.id, MensagensAviso = mensagensAviso});
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            if (!id.Equals(null))
            {
                return Json(GrupoProdutoModel.remove(id));
            }
            else
            {
                return Json("erro: 'ID inválido'");
            } 
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