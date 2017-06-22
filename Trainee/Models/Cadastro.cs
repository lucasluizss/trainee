using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trainee.Models
{
    public class cadastro
    {
        public int RA { get; set; }

        public DateTime DataNasc { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Curso { get; set; }

        public string Semestre { get; set; }

        public string CEP { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Sexo { get; set; }

        public bool Interno { get; set; }
    }
}