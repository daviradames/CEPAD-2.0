using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exer2.Models;

namespace Exer2.Controllers
{
    public class HomeController : Controller
    {
        public class UsuarioDAL
        {
            public static bool VerificaSenha(string SENHA)
            {
                using (CEPAD_IIIEntities dc = new CEPAD_IIIEntities())
                {
                    var existeSENHA = (from u in dc.Usuarios
                                       where u.Senha == SENHA
                                       select u).FirstOrDefault();
                    if (existeSENHA != null)
                        return true;
                    else
                        return false;
                }
            }
        }
        // GET: Home

        //DDL   | | |
        //      V V V
        public ActionResult Principal()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Registros()
        {
            return View();
        }
        public ActionResult Fale()
        {
            return View();
        }
        public ActionResult QuemSomos()
        {
            return View();
        }
        public ActionResult Teste()
        {
            return View();
        }
        public ActionResult Tela()
        {
            return View();
        }
        public ActionResult Local()
        {
            return View();
        }
        public ActionResult haha()
        {
            return View();
        }
        public ActionResult verificar()
        {
            return View();
        }
        public ActionResult verdade()
        {
            return View();
        }

        public ActionResult teste2()
        {
            return View();
        }
                                //Penta Tec | | |
                                //          V V V

        public ActionResult Agendados()
        {
            return View();
        }

        public ActionResult Dados()
        {
            return View();
        }

        public ActionResult Protocolo()
        {
            return View();
        }

        public ActionResult Resumo()
        {
            return View();
        }

        public ActionResult IndexPentaTec()
        {
            return View();
        }


                               //Winx  | | |
                               //      V V V

        

        public ActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using(CEPAD_IIIEntities dc = new CEPAD_IIIEntities())
                {
                    var v = dc.Usuarios.Where(a => a.USuario1.Equals(u.USuario1) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.ID_Usuario.ToString();
                        Session["nomeUsuarioLogado"] = v.USuario1.ToString();
                        return RedirectToAction("Pesquisa", "Clientes");
                    }
                }
            }
            return View(u);
        }


        public ActionResult cadastro1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cadastro1(Usuario _usuario)
        {
            if (ModelState.IsValid)
            {
                using (CEPAD_IIIEntities dc = new CEPAD_IIIEntities()) 
                //verifica duplicidade
                if (!UsuarioDAL.VerificaSenha(_usuario.Senha))
                {
                    dc.Usuarios.Add(_usuario);
                    dc.SaveChanges();
                    ModelState.Clear();
                    _usuario = null;
                    ViewBag.Message = "Usuário registrado sucesso.";
                }
                else
                {
                    ViewBag.Message = "Email já cadastrado.";
                }


            }
            return View(_usuario);
        }

        public ActionResult Agenda()
        {
            return View();
        }

        public ActionResult Nvtable()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }
        public ActionResult IndexWinx()
        {
            return View();
        }
    }
}