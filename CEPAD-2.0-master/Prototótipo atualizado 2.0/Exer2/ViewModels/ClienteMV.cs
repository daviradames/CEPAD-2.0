
using Exer2.Models;
using System.Collections.Generic;
namespace Mvc_Pesquisa.ViewModels
{
    public class ClienteVM
    {
        public int ID_Municipe { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public System.DateTime DT_Nasc { get; set; }
        public string Tel_Fixo { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string NR_Casa { get; set; }
        public string Rua { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
       
        public List<Municipe> Clientes { get; set; }
    }
}