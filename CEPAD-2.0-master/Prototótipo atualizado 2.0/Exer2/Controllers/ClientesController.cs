using Exer2.Models;
using Mvc_Pesquisa.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Mvc_Pesquisa.Controllers
{
    public class ClientesController : Controller
    {
        private CEPAD_IIIEntities db = new CEPAD_IIIEntities();
        public ActionResult Pesquisa()
        {


            if (Session["usuarioLogadoID"] != null)
            {
                using (var db = new CEPAD_IIIEntities())
                {
                    var _cliente = db.Municipe.ToList();
                    var data = new ClienteVM()
                    {
                        Clientes = _cliente
                    };
                    return View(data);
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }




        }



        [HttpPost]
        public ActionResult Pesquisa(ClienteVM _clientevm)
        {
            using (var db = new CEPAD_IIIEntities())
            {
                var clientePesquisa = from clienterec in db.Municipe
                                      where ((_clientevm.Nome == null) || (clienterec.Nome == _clientevm.Nome.Trim()))

                                    && ((_clientevm.CPF == null) || (clienterec.CPF + "" == _clientevm.CPF.Trim()))
                                      select new
                                      {
                                          Id = clienterec.ID_Municipe,
                                          clienterec.Nome,
                                          clienterec.Cidade,
                                          clienterec.CPF,
                                          clienterec.Rua,
                                          Rg = clienterec.RG,
                                          Uf = clienterec.UF,
                                          clienterec.Email,




                                      };
                List<Municipe> listaClientes = new List<Municipe>();
                foreach (var reg in clientePesquisa)
                {
                    Municipe clientevalor = new Municipe();
                    clientevalor.ID_Municipe = reg.Id;
                    clientevalor.Nome = reg.Nome;
                    clientevalor.Cidade = reg.Cidade;
                    clientevalor.CPF = reg.CPF;
                    clientevalor.Rua = reg.Rua;
                    clientevalor.RG = reg.Rg;
                    clientevalor.UF = reg.Uf;
                    clientevalor.Email = reg.Email;




                    listaClientes.Add(clientevalor);
                }
                _clientevm.Clientes = listaClientes;
                return View(_clientevm);
            }
        }
    }
}