using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestApi.Models
{
    public class Investor
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } // Permitindo nulo
        public string? Email { get; set; } // Permitindo nulo
        public ICollection<Investment>? Investments { get; set; } // Permitindo nulo
    }
}
