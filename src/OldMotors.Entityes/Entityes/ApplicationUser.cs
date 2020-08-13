using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Identity;
using OldMotors.Entityes.Entityes.Enum;

namespace OldMotors.Entityes.Entityes
{
   public class ApplicationUser: IdentityUser
    {
        [MaxLength(50)]
        public string CPF { get; set; }

        public int Idade { get; set; }

        [MaxLength(150)]
        public string Nome { get; set; }
        public string CEP { get; set; }
        [MaxLength(250)]
        public string Endereco { get; set; }
        [MaxLength(250)]
        public string EnderecoComplemento { get; set; }
        [MaxLength(20)]
        public string Telefone { get; set; }
        [MaxLength(20)]
        public string TelefoneCelular { get; set; }
        [MaxLength(50)]
        public bool Estado { get; set; }

        public TipoUsuario? Tipo { get; set; }
    }
}
