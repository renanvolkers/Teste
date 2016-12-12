using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tocalivrosMvcWeb.Models
{
    public class ClienteViewModel
    {
        [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string nome { get; set; }

        [MaxLength(11)]
        public string numeroDocumento { get; set; }


        [StringLength(maximumLength: 11, ErrorMessage = "Tamanho Maximo!")]
        public string numeroRegistro;

        [MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        public int telefone { get; set; }

        [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [Required(ErrorMessage = "* Email Obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Somente Números")]
        public int cep { get; set; }
    }
}