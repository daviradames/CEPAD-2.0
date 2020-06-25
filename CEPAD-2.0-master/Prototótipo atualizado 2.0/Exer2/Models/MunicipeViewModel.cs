using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exer2.Models
{
    public class MunicipeViewModel
    {
        public int ID_Municipe { get; set; }
        [Required]
        public string Nome { get; set; }
        public Nullable<int> RG { get; set; }
        public Nullable<System.DateTime> DT_Nasc { get; set; }
        public Nullable<int> Tel_Fixo { get; set; }
        public string UF { get; set; }
        public string Rua { get; set; }
        public Nullable<int> NR_Casa { get; set; }
        public string Bairro { get; set; }
        public Nullable<int> Celular { get; set; }
        public string CPF { get; set; }
        public Nullable<int> ID_Usuario { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Senha { get; set; }

        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }
    }
}