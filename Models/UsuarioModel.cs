using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda_Lieraria2._0.Models
{
    public class UsuarioModel
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        [Required(ErrorMessage = "O Nome é obrigatório. ")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O Nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }
        /// <summary>
        /// Data de nascimento do usuário
        /// </summary>
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida.")]
        [AgeValidation(ErrorMessage = "O usuário deve ter pelo menos 18 anos.")]
        public DateTime Datanasc { get; set; }
        /// <summary>
        /// Nome de usuário escolhido
        /// </summary>
        [Required(ErrorMessage = "O Nome de usuário é obrigatório. " )]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O Nome de usuário deve ter no minimo 3 caracteres")]
        public string NomeUsuario { get; set; }
        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage ="E-mail é obrigatório. ")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "Senha é obrigatório. ")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

    }

    #region Validação de idade 
    public class AgeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dataNascimento)
            {
                var idade = DateTime.Today.Year - dataNascimento.Year;
                if (dataNascimento > DateTime.Today.AddYears(-idade)) idade--;
                return idade >= 18; 
            }
            return false;
        }
    }
    #endregion
}