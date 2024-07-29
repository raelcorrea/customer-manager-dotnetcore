using System.ComponentModel.DataAnnotations;

namespace CustomerManager.Core.Models
{
	public class Address
	{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo 'Endereço' é obrigatório")]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo 'CEP' é obrigatório")]
        public string ZipCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo 'Cidade' é obrigatório")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo 'Estado' é obrigatório")]
        public string State { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
