using CustomerManager.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'Nome Completo' é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo 'Telefone' é obrigatório")]
        public string Phone { get; set; } = string.Empty;

        [CpfValidate]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; } = null;
    }
}
