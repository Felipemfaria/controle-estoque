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
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int? id)
        {
            if (id != null)
            {
                return Json(_ListaGrupoProduto.Find(x => x.id == id));
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
            if (grupoProdutoModel != null)
            {
                try
                {
                    var grupoProduto = _ListaGrupoProduto.Find(x => x.id == grupoProdutoModel.id);

                    if (grupoProduto == null)
                    {
                        grupoProduto = grupoProdutoModel;
                        grupoProduto.id = _ListaGrupoProduto.Max(x => x.id) + 1;
                        _ListaGrupoProduto.Add(grupoProduto);
                    }
                    else
                    {
                        grupoProduto.Nome = grupoProdutoModel.Nome;
                        grupoProduto.Ativo = grupoProdutoModel.Ativo;
                    }

                    return Json(grupoProduto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Json(grupoProdutoModel.id);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int? id)
        {
            if (id != null)
            {
                var ret = false;
                var grupoProduto = _ListaGrupoProduto.Find(x => x.id == id);

                if (grupoProduto != null)
                {
                    _ListaGrupoProduto.Remove(grupoProduto);
                    ret = true;
                }
                return Json(ret);
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