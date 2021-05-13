using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        [Column("USR_CPF")]
        [MaxLength(50)]
        [Display(Name ="CPF")]
        public string CPF { get; set; }

        [Column("USR_IDADE")]
        [Display(Name ="Idade")]
        public int Idade { get; set; }

        [Column("USR_NOME")]
        [MaxLength(255)]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Column("USR_CEP")]
        [MaxLength(15)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("USR_ENDERECO")]
        [MaxLength(255)]
        [Display(Name = "Endereço")]
        public string Endereço { get; set; }

        [Column("URS_COMPLEMENTO_ENDERECO")]
        [MaxLength(450)]
        [Display(Name = "Complemento de Endereço")]
        public string ComplementoEndereco { get; set; }

        [Column("USR_CELULAR")]
        [MaxLength(20)]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Column("USR_TELEFONE")]
        [MaxLength(20)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Column("USR_ESTADO")]
        [Display(Name ="Estado")]
        public bool Estado { get; set; }

        [Column("USR_TIPO")]
        [Display(Name = "Tipo")]
        public TipoUsuario? Tipo { get; set; }
    }
}
